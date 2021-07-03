using System.Collections.Generic;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public interface IReviewRepository 
    {
        List<REVIEW> GetAllReviewInOffice(string id);
        REVIEW GetReviewInOffice(string id);
        REVIEW CreateReview(REVIEW review);
        REVIEW UpdateReview(REVIEW review);
        void DeleteReview(string id);
    }
}