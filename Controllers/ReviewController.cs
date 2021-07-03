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
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _repo;

        public ReviewController(IReviewRepository repo)
        {
            _repo = repo;
        }

        // GET: Review
        public async Task<IActionResult> Index(string id)
        {
            return View(_repo.GetAllReviewInOffice(id));
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = 1;
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OFFICE_ID,RATING,CONTENT,CREATED_AT,UPDATED_AT")] REVIEW review)
        {
            if (ModelState.IsValid)
            {

            }
            return View(review);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = 1;
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,OFFICE_ID,RATING,CONTENT,CREATED_AT,UPDATED_AT")] REVIEW review)
        {
            if (id != review.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = 1;
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            return RedirectToAction(nameof(Index));
        }

        private bool REVIEWExists(string id)
        {
            return true;
        }
    }
}
