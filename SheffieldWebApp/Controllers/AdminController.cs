using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SheffieldWebApp.Data;
using SheffieldWebApp.Models;

namespace SheffieldWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var students = await _context.Student.ToListAsync();
            var grades = await _context.Grade.ToListAsync();
            var subjects = await _context.Subject.ToListAsync();
            var teachers = await _context.Teachers.ToListAsync();

            var data = new AdminModel
            {
                grades = grades,
                subjects = subjects,
                students = students,
                teachers = teachers
            };
            return View(data);
        }

    }
}
