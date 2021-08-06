using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private IDbConnection db;
        public ReviewRepository(IConfiguration configuration)
        {
            this.db = new OracleConnection(configuration.GetConnectionString("Oracle"));
        }
        public async Task<Review> GetReviewByOffice(string reviewid, string officeid)
        {
            var result = await db.QueryAsync<Review>("GET_REVIEW_BY_OFFICE", 
            new 
            { 
                P_ReviewId = reviewid, 
                P_OfficeId = officeid 
            }, commandType: CommandType.StoredProcedure);
            return result.Single();
        }

        public async Task<Review> CreateReview(Review review)
        {
            await db.QueryAsync<Review>("CREATE_REVIEW", 
            new {
                P_UserId = review.UserId,
                P_OfficeId = review.OfficeId,
                P_RATING = review.Rating,
                P_Content = review.Content
            }, commandType: CommandType.StoredProcedure);
            return review;
        }

        public async Task<Review> UpdateReview(Review review)
        {
            await db.QueryAsync<Review>("UPDATE_REVIEW", 
            new {
                P_Id = review.Id,
                P_Rating = review.Rating,
                P_Content = review.Content
            }, commandType: CommandType.StoredProcedure);
            return review;
        }

        public async Task DeleteReview(string id)
        {
            await db.ExecuteAsync("DELETE_REVIEW", new { P_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOfficeRating(string id)
        {
            await db.ExecuteAsync("UPDATE_OFFICE_RATING", new { P_Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}