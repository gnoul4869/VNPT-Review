using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VNPT_Review.Models;
using VNPT_Review.Repository;

namespace VNPT_Review.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repo;

        public OfficeService(IOfficeRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<DataTableResponse<Office>> GetPaginatedOffice(DataTableRequest request)
        {
            var req = new OfficeListRequest()
            {
                ValueNo = request.Start,
                PageSize = request.Length,
                SortColumn = request.Order[0].Column,
                SortDirection = request.Order[0].Dir,
                SearchValue = request.Search != null ? request.Search.Value.Trim() : ""
            };

            var offices = await _repo.GetPaginatedOffice(req);
            int TotalCount, FilteredCount;

            if(offices.ToArray().Length == 0)
            {
                TotalCount = 0;
                FilteredCount = 0;
            }
            else
            {
                TotalCount = offices[0].TotalCount;
                FilteredCount = offices[0].FilteredCount;
            }

            return new DataTableResponse<Office>()
            {
                Draw = request.Draw,
                RecordsTotal = TotalCount,
                RecordsFiltered = FilteredCount,
                Data = offices.ToArray(),
                Error = ""
            };
        }
    }
}