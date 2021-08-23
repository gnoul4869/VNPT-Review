using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNPT_Review.Models;
using VNPT_Review.Repository;
using VNPT_Review.Services;

namespace VNPT_Review.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IOfficeRepository _repo;
        
        private readonly IOfficeService _svc;

        private readonly UserManager<IdentityUser> _userManager;

        public OfficeController(IOfficeRepository repo, IOfficeService svc, UserManager<IdentityUser> userManager)
        {
            _repo = repo; 
            _svc = svc;
            _userManager = userManager;
        }

        [Route("/officelist")]
        public async Task<IActionResult> Index(OfficeListRequest request)
        {
            var model = new UOfficeReview();
            model.offices = await _repo.GetInfiniteOffice(9);

            return View(model);
        }

        [Route("/office/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var model = new UOfficeReview();
            model.office = await _repo.GetOffice(id);

            var userId = _userManager.GetUserId(User);
            model.office.ExistUserReview = await _repo.ExistUserReviewInOffice(userId, id);

            if(model.office == null) 
                return NotFound();
            model.reviews = await _repo.GetInfiniteReviewInOffice(id, 4);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [Route("/office/create")]
        public IActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [Route("/office/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Note,FatherId,Active")] Office office)
        {
            if(ModelState.IsValid)
            {
                await _repo.CreateOffice(office);
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        [Authorize(Roles = "Admin")]
        [Route("/office/edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var office = await _repo.GetOffice(id);
            if(office == null)
            {
                return NotFound();
            }
            return View(office);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [Route("/office/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Note,FatherId,Active")] Office office)
        {
            if(id != office.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                await _repo.UpdateOffice(office);
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var office = await _repo.GetOffice(id);
            if(office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _repo.DeleteOffice(id);
            return RedirectToAction(nameof(Index));
        }

        [Route("InfiniteOffice")]
        [HttpGet]
        public async Task<IActionResult> InfiniteOffice(int value)
        {
            var max = await _repo.GetOfficeCount();
            if(value >= max && (value - 9) > max) 
                return null;

            var model = new UOfficeReview();
            model.offices = await _repo.GetInfiniteOffice(value);

            return PartialView("_OfficeCardPartial", model);
        }

        [Route("InfiniteReviewInOffice")]
        public async Task<IActionResult> InfiniteReviewInOffice(string id, int value)
        {
            var max = await _repo.GetReviewCountInOffice(id);
            if(value >= max && (value - 4) > max) 
                 return null;

            if(id == null)
            {
                return NotFound();
            }

            var model = new UOfficeReview();
            model.office = await _repo.GetOffice(id);
            if(model.office == null) 
                return NotFound();
            model.reviews = await _repo.GetInfiniteReviewInOffice(id, value);

            return PartialView("_ReviewSectionPartial", model);
        }
    }
}
