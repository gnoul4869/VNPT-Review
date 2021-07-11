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
                PageNo = request.Start,
                PageSize = request.Length,
                SortColumn = request.Order[0].Column,
                SortDirection = request.Order[0].Dir,
                SearchValue = request.Search != null ? request.Search.Value.Trim() : ""
            };

            var offices = await _repo.GetPaginatedOffice(req);

            return new DataTableResponse<Office>()
            {
                Draw = request.Draw,
                RecordsTotal = offices[0].TotalCount,
                RecordsFiltered = offices[0].FilteredCount,
                Data = offices.ToArray(),
                Error = ""
            };
        }
    }
}