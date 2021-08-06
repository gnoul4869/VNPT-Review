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
        Task<List<Office>> GetInfiniteOffice(int value);

        Task<List<Office>> GetPaginatedOffice(OfficeListRequest request);

        Task<Office> GetOffice(string id);

        Task<List<Office>> GetAllOffice();

        Task<int> GetOfficeCount();

        Task<Office> CreateOffice(Office office);

        Task<Office> UpdateOffice(Office office);

        Task DeleteOffice(string id);

        Task<List<Review>> GetAllReviewInOffice(string id);

        Task<List<Review>> GetInfiniteReviewInOffice(string id, int value);

        Task<int> GetReviewCountInOffice(string id);

        Task<int> ExistUserReviewInOffice(string userId, string officeId);

    }
}