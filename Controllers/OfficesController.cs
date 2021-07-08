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
    public class OfficesController : Controller
    {
        private readonly IOfficeRepository _repo;

        public OfficesController(IOfficeRepository repo)
        {
            _repo = repo;
        }

        // GET: Office
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetPaginatedOffice());
        }

        // GET: Offices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = new UOfficeReview();
            model.office = await _repo.GetOffice(id);
            if (model.office == null) 
                return NotFound();
            model.review = await _repo.GetAllReviewInOffice(id);

            return View(model);
        }

        // GET: Offices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NAME,NOTE,FATHER_ID,ACTIVE,CREATED_AT,UPDATED_AT")] OFFICE office)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateOffice(office);
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Offices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _repo.GetOffice(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }

        // POST: Offices/Edit/5
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
                await _repo.UpdateOffice(office);
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Offices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _repo.GetOffice(id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // POST: Offices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _repo.DeleteOffice(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
