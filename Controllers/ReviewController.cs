using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using VNPT_Review.Models;
using VNPT_Review.Repository;
using Microsoft.AspNetCore.Identity;

namespace VNPT_Review.Controllers 
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _repo;

        private readonly UserManager<IdentityUser> _userManager;

        public ReviewController(IReviewRepository repo, UserManager<IdentityUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfficeId,Content,Rating")] Review review, string returnUrl)
        {
            review.UserId = _userManager.GetUserId(User);
            if(ModelState.IsValid) 
            {
                await _repo.CreateReview(review);
                await _repo.UpdateOfficeRating(review.OfficeId);
            }
            return Redirect(returnUrl);
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task Edit([Bind("OfficeId,Content,Rating")] Review review)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         await _repo.UpdateReview(review);      
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, string officeId)
        {
            await _repo.DeleteReview(id);
            await _repo.UpdateOfficeRating(officeId);
            var url = string.Format("/office/{0}", officeId);
            return Redirect(url);
        }

    }
}