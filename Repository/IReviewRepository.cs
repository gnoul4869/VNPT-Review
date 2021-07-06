using System.Threading.Tasks;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public interface IReviewRepository
    {
        Task<REVIEW> GetReviewByOffice(string rid, string oid);
        Task<REVIEW> CreateReview(REVIEW review);
        Task<REVIEW> UpdateReview(REVIEW review);
        Task DeleteReview(string id);
    }
}