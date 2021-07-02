using System.Collections.Generic;
using System.Linq;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly OfficeContext _db;

        public OfficeRepository(OfficeContext db)
        {
            _db = db;
        }

        public OFFICE GetOffice(string id)
        {
            return _db.OFFICE.FirstOrDefault(u => u.ID == id);
        }

        public List<OFFICE> GetAllOffice()
        {
            return _db.OFFICE.ToList();
        }

        public OFFICE CreateOffice(OFFICE office)
        {
            _db.OFFICE.Add(office);
            _db.SaveChanges();
            return office;
        }

        public OFFICE UpdateOffice(OFFICE office)
        {
            _db.OFFICE.Update(office);
            _db.SaveChanges();
            return office;
        }

        public void DeleteOffice(string id)
        {
            OFFICE office = _db.OFFICE.FirstOrDefault(u => u.ID == id);
            _db.OFFICE.Remove(office);
            _db.SaveChanges();
            return;
        }

    }
}