using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNPT_Review.Models;

namespace VNPT_Review.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewContext _context;

        public ReviewController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            var reviewContext = _context.REVIEW.Include(r => r.OFFICE);
            return View(await reviewContext.ToListAsync());
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEVIEW = await _context.REVIEW
                .Include(r => r.OFFICE)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rEVIEW == null)
            {
                return NotFound();
            }

            return View(rEVIEW);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            ViewData["OFFICE_ID"] = new SelectList(_context.Set<OFFICE>(), "ID", "ID");
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OFFICE_ID,RATING,CONTENT,CREATED_AT,UPDATED_AT")] REVIEW rEVIEW)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rEVIEW);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OFFICE_ID"] = new SelectList(_context.Set<OFFICE>(), "ID", "ID", rEVIEW.OFFICE_ID);
            return View(rEVIEW);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEVIEW = await _context.REVIEW.FindAsync(id);
            if (rEVIEW == null)
            {
                return NotFound();
            }
            ViewData["OFFICE_ID"] = new SelectList(_context.Set<OFFICE>(), "ID", "ID", rEVIEW.OFFICE_ID);
            return View(rEVIEW);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,OFFICE_ID,RATING,CONTENT,CREATED_AT,UPDATED_AT")] REVIEW rEVIEW)
        {
            if (id != rEVIEW.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rEVIEW);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!REVIEWExists(rEVIEW.ID))
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
            ViewData["OFFICE_ID"] = new SelectList(_context.Set<OFFICE>(), "ID", "ID", rEVIEW.OFFICE_ID);
            return View(rEVIEW);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEVIEW = await _context.REVIEW
                .Include(r => r.OFFICE)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rEVIEW == null)
            {
                return NotFound();
            }

            return View(rEVIEW);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rEVIEW = await _context.REVIEW.FindAsync(id);
            _context.REVIEW.Remove(rEVIEW);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool REVIEWExists(string id)
        {
            return _context.REVIEW.Any(e => e.ID == id);
        }
    }
}
