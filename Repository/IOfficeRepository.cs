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
        Task<List<OFFICE>> GetPaginatedOffice();
        Task<OFFICE> GetOffice(string id);
        Task<List<OFFICE>> GetAllOffice();
        Task<OFFICE> CreateOffice(OFFICE office);
        Task<OFFICE> UpdateOffice(OFFICE office);
        Task DeleteOffice(string id);

        // Reviews
        Task<List<REVIEW>> GetAllReviewInOffice(string id);
    }
}