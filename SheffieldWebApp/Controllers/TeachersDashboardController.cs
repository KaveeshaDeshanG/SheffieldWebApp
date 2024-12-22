using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SheffieldWebApp.Data;
using SheffieldWebApp.Models;

namespace SheffieldWebApp.Controllers
{
    public class TeachersDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeachersDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Teacher")]

        public async Task<IActionResult> index()
        {
            var students = await _context.Student.ToListAsync();
            var grades = await _context.Grade.ToListAsync();
            var subjects = await _context.Subject.ToListAsync();
            var teachers = await _context.Teachers.ToListAsync();
            var assings = await _context.AssignedStudents.ToListAsync();
            var marks = await _context.Mark.ToListAsync();

            var data = new TeacherDashboard
            {
                grades = grades,
                subjects = subjects,
                students = students,
                teachers = teachers,
                assignedStudents = assings,
                marks = marks
            };
            return View(data);
        }

        public async Task<IActionResult> AddStudentToSubject(int subjectId, Guid studentId)
        {
            AssignedStudent assign = new AssignedStudent
            {
                StudentId = studentId.ToString(),
                SubjectId = subjectId
            };

            _context.AssignedStudents.Add(assign);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index", "TeachersDashboard");
        }

        
    }

}
