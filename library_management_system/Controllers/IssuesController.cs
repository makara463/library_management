using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using library_management_system.Data;
using library_management_system.Models;

namespace library_management_system.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Issue.Include(i => i.Book).Include(i => i.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .Include(i => i.Book)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.IssueID == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Title");
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name");
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IssueID,IssueDate,ReturnDate,Status,StudentID,BookID")] Issue issue)
        {

            _context.Add(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Title", issue.BookID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name", issue.StudentID);
            return View(issue);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Title", issue.BookID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name", issue.StudentID);
            return View(issue);
        }
        // POST: Issues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IssueID,IssueDate,ReturnDate,Status,StudentID,BookID")] Issue issue)
        {

            _context.Update(issue);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Title", issue.BookID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name", issue.StudentID);
            return View(issue);
        }
        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .Include(i => i.Book)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.IssueID == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.Issue.FindAsync(id);
            if (issue != null)
            {
                _context.Issue.Remove(issue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
            return _context.Issue.Any(e => e.IssueID == id);
        }
    }
}
