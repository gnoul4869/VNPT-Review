using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public class OfficeRepository : IOfficeRepository
    {
        private IDbConnection db;
        public OfficeRepository(IConfiguration configuration)
        {
            this.db = new NpgsqlConnection(configuration.GetConnectionString("PostgreSQL"));
        }

        public async Task<List<Office>> GetInfiniteOffice(int value)
        {
            var result = await db.QueryAsync<Office>("SELECT * FROM GET_INFINITE_OFFICE(@P_Value)", new { P_Value = value });
            return result.ToList();
        } 

        public async Task<List<Office>> GetPaginatedOffice(OfficeListRequest request)
        { 
            var result = await db.QueryAsync<Office>("SELECT * FROM GET_PAGINATED_OFFICE(@P_SearchValue, @P_ValueNo, @P_PageSize, @P_SortColumn, @P_SortDirection)", 
            new 
            { 
                P_SearchValue = request.SearchValue,
                P_ValueNo = request.ValueNo,
                P_PageSize = request.PageSize,
                P_SortColumn = request.SortColumn,
                P_SortDirection = request.SortDirection
            });
            return result.ToList();
        }

        public async Task<Office> GetOffice(string id)
        {
            var result = await db.QueryAsync<Office>("GET_OFFICE", new { P_Id = id }, commandType: CommandType.StoredProcedure);
            return result.Single();
        }

        public async Task<List<Office>> GetAllOffice()
        { 
            var result = await db.QueryAsync<Office>("GET_ALL_OFFICE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> GetOfficeCount()
        {
            var result = await db.QueryAsync<int>("GET_OFFICE_COUNT", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public async Task<Office> CreateOffice(Office office)
        {
            await db.ExecuteAsync("CREATE_OFFICE",
            new 
            {
                P_Id = office.Id,
                P_Name = office.Name,
                P_Note = office.Note,
                P_FatherId = office.FatherId,
                P_Active = office.Active
            }, commandType: CommandType.StoredProcedure);
            return office;
        }

        public async Task<Office> UpdateOffice(Office office)
        {
            await db.ExecuteAsync("UPDATE_OFFICE",
            new 
            {
                P_Id = office.Id,
                P_Name = office.Name,
                P_Note = office.Note,
                P_FatherId = office.FatherId,
                P_Active = office.Active
            }, commandType: CommandType.StoredProcedure);
            return office;
        }

        public async Task DeleteOffice(string id)
        {
            await db.ExecuteAsync("DELETE_OFFICE", new { P_Id = id }, commandType: CommandType.StoredProcedure);
        }
        
        public async Task<List<Review>> GetAllReviewInOffice(string id)
        {
            var result = await db.QueryAsync<Review>("GET_ALL_REVIEW_IN_OFFICE", new { P_Id = id }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Review>> GetInfiniteReviewInOffice(string id, int value)
        {
            var result = await db.QueryAsync<Review>("GET_INFINITE_REVIEW_IN_OFFICE", new { P_Id = id, P_Value = value }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> GetReviewCountInOffice(string id)
        {
            var result = await db.QueryAsync<int>("GET_REVIEW_COUNT_IN_OFFICE", new { P_OfficeId = id }, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> ExistUserReviewInOffice(string userId, string officeId)
        {
            var result = await db.QueryAsync<int>("EXIST_USER_REVIEW_IN_OFFICE", new { P_UserId = userId, P_OfficeId = officeId }, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}