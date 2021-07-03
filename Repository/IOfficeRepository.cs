using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VNPT_Review.Controllers;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public interface IOfficeRepository 
    {
        Task<OFFICE> GetOffice(string id);
        Task<List<OFFICE>> GetAllOffice();
        OFFICE CreateOffice(OFFICE office);
        OFFICE UpdateOffice(OFFICE office);
        void DeleteOffice(string id);
    }
}