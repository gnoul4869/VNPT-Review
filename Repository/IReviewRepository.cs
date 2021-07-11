using System.Threading.Tasks;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public interface IReviewRepository
    {
        Task<Review> GetReviewByOffice(string rid, string oid);
        Task<Review> CreateReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task DeleteReview(string id);
    }
}