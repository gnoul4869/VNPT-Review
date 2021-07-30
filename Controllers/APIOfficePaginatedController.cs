using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VNPT_Review.Models;
using VNPT_Review.Services;

namespace VNPT_Review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIOfficePaginatedController : ControllerBase
    {
        private readonly IOfficeService _svc;
        public APIOfficePaginatedController(IOfficeService svc)
        {
            _svc = svc;
        }

        [HttpPost]
        public async Task<DataTableResponse<Office>> GetOffices()
        {
            var request = new DataTableRequest();

            request.Draw = Convert.ToInt32(Request.Form["draw"].FirstOrDefault());
            request.Start = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            request.Length = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            
            request.Search = new DataTableSearch()
            {
                Value = Request.Form["search[value]"].FirstOrDefault()
            };
            request.Order = new DataTableOrder[] 
            {
                new DataTableOrder()
                {
                    Dir = Request.Form["order[0][dir]"].FirstOrDefault(),
                    Column = Convert.ToInt32(Request.Form["order[0][column]"].FirstOrDefault())
                }
            };
            return await _svc.GetPaginatedOffice(request);
        }
    }
}