using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNPT_Review.Models;
using VNPT_Review.Repository;

namespace VNPT_Review.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IOfficeRepository _repo;

        public OfficeController(IOfficeRepository repo)
        {
            _repo = repo;
        }

        // GET: Office
        public async Task<IActionResult> Index()
        {
            return View(_repo.GetAllOffice());
        }

        // GET: Office/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = _repo.GetOffice(id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
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
        public async Task<IActionResult> Create([Bind("ID,NAME,NOTE,FATHER_ID,ACTIVE,CREATED_AT,UPDATED_AT")] OFFICE office)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateOffice(office);
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Office/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = _repo.GetOffice(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }

        // POST: Office/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,NAME,NOTE,FATHER_ID,ACTIVE,CREATED_AT,UPDATED_AT")] OFFICE office)
        {
            if (id != office.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.UpdateOffice(office);
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Office/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = _repo.GetOffice(id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // POST: Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _repo.DeleteOffice(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
