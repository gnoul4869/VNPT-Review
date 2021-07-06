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
        private DbConnection db;
        public ReviewRepository(IConfiguration configuration)
        {
            this.db = new OracleConnection(configuration.GetConnectionString("Oracle"));
        }
        public async Task<REVIEW> GetReviewByOffice(string rid, string oid)
        {
            var result = await db.QueryAsync<REVIEW>("GET_REVIEW_BY_OFFICE", 
            new 
            { 
                P_RID = rid, 
                P_OID = oid 
            }, commandType: CommandType.StoredProcedure);
            return result.Single();
        }

        public async Task<REVIEW> CreateReview(REVIEW review)
        {
            await db.QueryAsync<REVIEW>("CREATE_REVIEW", 
            new {
                P_OFFICE_ID = review.OFFICE_ID,
                P_RATING = review.RATING,
                P_CONTENT = review.CONTENT
            }, commandType: CommandType.StoredProcedure);
            return review;
        }

        public async Task<REVIEW> UpdateReview(REVIEW review)
        {
            await db.QueryAsync<REVIEW>("UPDATE_REVIEW", 
            new {
                P_ID = review.ID,
                P_RATING = review.RATING,
                P_CONTENT = review.CONTENT
            }, commandType: CommandType.StoredProcedure);
            return review;
        }

        public async Task DeleteReview(string id)
        {
            await db.ExecuteAsync("DELETE_REVIEW", new { P_ID = id }, commandType: CommandType.StoredProcedure);
        }
    }
}