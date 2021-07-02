using System.Collections.Generic;
using System.Data;
using VNPT_Review.Controllers;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public interface IOfficeRepository 
    {
        OFFICE GetOffice(string id);
        List<OFFICE> GetAllOffice();
        OFFICE CreateOffice(OFFICE office);
        OFFICE UpdateOffice(OFFICE office);
        void DeleteOffice(string id);
    }
}