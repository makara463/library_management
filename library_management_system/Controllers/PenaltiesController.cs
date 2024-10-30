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
    public class PenaltiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PenaltiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Penalties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Penalty.Include(p => p.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Penalties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penalty = await _context.Penalty
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.PenaltyID == id);
            if (penalty == null)
            {
                return NotFound();
            }

            return View(penalty);
        }

        // GET: Penalties/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name");
            return View();
        }

        // POST: Penalties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PenaltyID,Amount,Reason,Date,StudentID")] Penalty penalty)
        {
            _context.Add(penalty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name", penalty.StudentID);
            return View(penalty);
        }

        // GET: Penalties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penalty = await _context.Penalty.FindAsync(id);
            if (penalty == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name", penalty.StudentID);
            return View(penalty);
        }

        // POST: Penalties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PenaltyID,Amount,Reason,Date,StudentID")] Penalty penalty)
        {

            _context.Update(penalty);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Name", penalty.StudentID);
            return View(penalty);
        }

        // GET: Penalties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penalty = await _context.Penalty
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.PenaltyID == id);
            if (penalty == null)
            {
                return NotFound();
            }

            return View(penalty);
        }

        // POST: Penalties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penalty = await _context.Penalty.FindAsync(id);
            if (penalty != null)
            {
                _context.Penalty.Remove(penalty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenaltyExists(int id)
        {
            return _context.Penalty.Any(e => e.PenaltyID == id);
        }
    }
}
