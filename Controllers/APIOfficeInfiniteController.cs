using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VNPT_Review.Models;
using VNPT_Review.Repository;
using VNPT_Review.Services;

namespace VNPT_Review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIOfficeInfiniteController : Controller
    {
        private readonly IOfficeRepository _repo;
        public APIOfficeInfiniteController(IOfficeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetOffice(int value)
        {
            var max = await _repo.GetOfficeCount();
            if(value >= max) 
                return null;

            var model = new UOfficeReview();
            model.offices = await _repo.GetInfiniteOffice(value);
            foreach(var item in model.offices) 
            {
                decimal rate = 0;
                decimal sum = 0;
                model.reviews = await _repo.GetAllReviewInOffice(item.Id);
                
                foreach(var item2 in model.reviews)
                {
                    rate += (decimal)item.Rating;
                    sum++;
                }

                try 
                {
                    item.Rating = rate / sum;
                }
                catch(Exception)
                {   
                    item.Rating = 0;
                }
                
            }
            return PartialView("_OfficeCard", model);
        }
    }
}