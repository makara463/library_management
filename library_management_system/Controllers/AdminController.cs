using library_management_system.Data;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var branches = _context.Branch.Count();
            var publications = _context.Publication.Count();
            var books = _context.Book.Count();
            var students = _context.Student.Count();
            var issues = _context.Issue.Count();
            var penalties = _context.Penalty.Count();
            ViewBag.branches = branches;
            ViewBag.publications = publications;
            ViewBag.books = books;
            ViewBag.students = students;
            ViewBag.issues = issues;
            ViewBag.penalties = penalties;
            return View();
        }
    }
}
