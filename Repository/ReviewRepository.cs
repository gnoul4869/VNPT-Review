using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Npgsql;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private IDbConnection db;
        public ReviewRepository(IConfiguration configuration, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                this.db = new NpgsqlConnection(configuration.GetConnectionString("PostgreSQL"));
            }
            else
            {
                var pgUser = Environment.GetEnvironmentVariable("USER");
                var pgPassword = Environment.GetEnvironmentVariable("PASSWORD");
                var pgHost = Environment.GetEnvironmentVariable("HOST");
                var pgPort = Environment.GetEnvironmentVariable("PORT");
                var pgDatabase = Environment.GetEnvironmentVariable("DATABASE");

                var connStr = $"User Id={pgUser}; Password={pgPassword}; Host={pgHost}; Port={pgPort}; Database={pgDatabase}; sslmode=Prefer; Trust Server Certificate=true";
                this.db = new NpgsqlConnection(connStr);
            } 
        }

        public async Task<Review> GetReviewByOffice(string reviewid, string officeid)
        {
            var result = await db.QueryAsync<Review>("SELECT * FROM GET_REVIEW_BY_OFFICE(@P_ReviewId, @P_OfficeId)", 
            new 
            { 
                P_ReviewId = reviewid, 
                P_OfficeId = officeid 
            });
            return result.Single();
        }

        public async Task<Review> CreateReview(Review review)
        {
            await db.QueryAsync<Review>("CALL CREATE_REVIEW(@P_UserId, @P_OfficeId, @P_Rating, @P_Content)", 
            new {
                P_UserId = review.UserId,
                P_OfficeId = review.OfficeId,
                P_RATING = review.Rating,
                P_Content = review.Content
            });
            return review;
        }

        public async Task<Review> UpdateReview(Review review)
        {
            await db.QueryAsync<Review>("CALL UPDATE_REVIEW(@P_Id, @P_Rating, @P_Content)", 
            new {
                P_Id = review.Id,
                P_Rating = review.Rating,
                P_Content = review.Content
            });
            return review;
        }

        public async Task DeleteReview(string id)
        {
            await db.ExecuteAsync("CALL DELETE_REVIEW(@P_Id)", new { P_Id = id });
        }

        public async Task UpdateOfficeRating(string id)
        {
            await db.ExecuteAsync("CALL UPDATE_OFFICE_RATING(@P_Id)", new { P_Id = id });
        }
    }
}