using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VNPT_Review.Controllers;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public interface IOfficeRepository 
    {
        Task<List<Office>> GetPaginatedOffice(OfficeListRequest request);
        Task<Office> GetOffice(string id);
        Task<List<Office>> GetAllOffice();
        Task<Office> CreateOffice(Office office);
        Task<Office> UpdateOffice(Office office);
        Task DeleteOffice(string id);

        // Reviews
        Task<List<Review>> GetAllReviewInOffice(string id);
    }
}