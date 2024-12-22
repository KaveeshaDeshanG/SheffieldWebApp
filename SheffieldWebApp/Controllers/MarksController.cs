
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SheffieldWebApp.Data;
using SheffieldWebApp.Models;

namespace SheffieldWebApp.Controllers
{
    public class MarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mark.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public async Task<IActionResult> Create(int id) // pass data for View
        {
            int subjectId = id;
            var subject = await _context.Subject.FirstOrDefaultAsync(s => s.Id == subjectId);
            if (subject == null)
            {
                return NotFound();
            }

            var assignedStudents = await _context.AssignedStudents.ToListAsync();
            var students = await _context.Student.ToListAsync();
            var grades = await _context.Grade
                .Where(g => g.SubjectName == subject.Title)
                .ToListAsync();
            var allMarks = await _context.Mark.Where(m => m.SubjectId == subjectId).ToListAsync();

            var model = new AddMarksModel
            {
                Subject = subject,
                AssignedStudents = assignedStudents,
                Students = students,
                Grades = grades,
                AllMarks = allMarks
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMarksModel model) // get data 
        {
            int subjectId = model.Marks.SubjectId;

            if (model.Marks == null)
            {
                return BadRequest("Marks cannot be null.");
            }

            var validationContext = new ValidationContext(model.Marks);
            var validationResults = new List<ValidationResult>();

            var subject = await _context.Subject.FirstOrDefaultAsync(s => s.Id == subjectId);
            var grades = await _context.Grade
                .Where(g => g.SubjectName == subject.Title)
                .ToListAsync();


            if (Validator.TryValidateObject(model.Marks, validationContext, validationResults, true))
            {
                string gradeName = GetStudentGrade(model.Marks.MarksObtained, grades);

                var mark = new Mark
                {
                    StudentId = model.Marks.StudentId,
                    SubjectId = model.Marks.SubjectId,
                    MarksObtained = model.Marks.MarksObtained,
                    GradeName = gradeName
                };

                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Marks", new { subjectId });
            }
            else
            {
                foreach (var error in validationResults)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return RedirectToAction("Create", "Marks", new { subjectId });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeMarks(AddMarksModel model)
        {
            int subjectId = model.Marks.SubjectId;

            if (model.Marks == null)
            {
                return BadRequest("Marks cannot be null.");
            }
            var validationContext = new ValidationContext(model.Marks);
            var validationResults = new List<ValidationResult>();

            var subject = await _context.Subject.FirstOrDefaultAsync(s => s.Id == subjectId);
            var grades = await _context.Grade
                .Where(g => g.SubjectName == subject.Title)
                .ToListAsync();

            if (Validator.TryValidateObject(model.Marks, validationContext, validationResults, true))
            {
                string gradeName = GetStudentGrade(model.Marks.MarksObtained, grades);
                var mark = new Mark
                {
                    Id = model.Marks.Id,
                    StudentId = model.Marks.StudentId,
                    SubjectId = model.Marks.SubjectId,
                    MarksObtained = model.Marks.MarksObtained,
                    GradeName = gradeName
                };

                _context.Mark.Update(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Marks", new { id = subjectId });

            }
            else
            {
                foreach (var error in validationResults)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return RedirectToAction("Create", "Marks", new { subjectId });
            }

        }


        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            return View(mark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mark mark)
        {
            if (id != mark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mark);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Mark.FindAsync(id);
            if (mark != null)
            {
                _context.Mark.Remove(mark);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }

        private string GetStudentGrade(decimal marks, List<Grade> grades)
        {
            var sortedGrades = grades.OrderByDescending(g => g.GivenMarks).ToList();

            foreach (var grade in sortedGrades)
            {
                if (marks >= grade.GivenMarks)
                {
                    return grade.GradeName;
                }
            }

            return "Pending";
        }

    }
}
