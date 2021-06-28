using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNPT.Models;

namespace VNPT_Review.Controllers
{
    public class OfficeController : Controller
    {
        private readonly OfficeContext _context;

        public OfficeController(OfficeContext context)
        {
            _context = context;
        }

        // GET: Office
        public async Task<IActionResult> Index()
        {
            return View(await _context.OFFICE.ToListAsync());
        }

        // GET: Office/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oFFICE = await _context.OFFICE
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oFFICE == null)
            {
                return NotFound();
            }

            return View(oFFICE);
        }

        // GET: Office/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Office/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NAME,NOTE,FATHERID,ACTIVE,CREATED_AT,UPDATED_AT")] OFFICE oFFICE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oFFICE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oFFICE);
        }

        // GET: Office/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oFFICE = await _context.OFFICE.FindAsync(id);
            if (oFFICE == null)
            {
                return NotFound();
            }
            return View(oFFICE);
        }

        // POST: Office/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,NAME,NOTE,FATHERID,ACTIVE,CREATED_AT,UPDATED_AT")] OFFICE oFFICE)
        {
            if (id != oFFICE.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oFFICE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OFFICEExists(oFFICE.ID))
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
            return View(oFFICE);
        }

        // GET: Office/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oFFICE = await _context.OFFICE
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oFFICE == null)
            {
                return NotFound();
            }

            return View(oFFICE);
        }

        // POST: Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var oFFICE = await _context.OFFICE.FindAsync(id);
            _context.OFFICE.Remove(oFFICE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OFFICEExists(string id)
        {
            return _context.OFFICE.Any(e => e.ID == id);
        }
    }
}
