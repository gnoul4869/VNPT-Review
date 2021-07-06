using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OFFICE_ID,RATING,CONTENT")] REVIEW review)
        {
            if(ModelState.IsValid) 
            {
                await _repo.CreateReview(review);
                return RedirectToAction("Index", "OfficesController");
            }
            return RedirectToAction("Index", "OfficesController");
        }
    }
}