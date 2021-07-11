using System.Threading.Tasks;
using VNPT_Review.Models;

namespace VNPT_Review.Services
{
    public interface IOfficeService
    {
        public Task<DataTableResponse<Office>> GetPaginatedOffice(DataTableRequest request);
    }
}