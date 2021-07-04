using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using VNPT_Review.Models;

namespace VNPT_Review.Repository
{
    public class OfficeRepository : IOfficeRepository
    {
        private IDbConnection db;
        public OfficeRepository(IConfiguration configuration)
        {
            this.db = new OracleConnection(configuration.GetConnectionString("Oracle"));
        }

        public async Task<OFFICE> GetOffice(string id)
        {
            var result = await db.QueryAsync<OFFICE>("GET_OFFICE", new { P_ID = id }, commandType: CommandType.StoredProcedure);
            return result.Single();
        }

        public async Task<List<OFFICE>> GetAllOffice()
        { 
            var result = await db.QueryAsync<OFFICE>("GET_ALL_OFFICE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<OFFICE> CreateOffice(OFFICE office)
        {
            var boolActive = 0;
            if(office.ACTIVE.ToString() == "True")
                boolActive = 1;
            await db.ExecuteAsync("CREATE_OFFICE",
            new 
            {
                P_ID = office.ID,
                P_NAME = office.NAME,
                P_NOTE = office.NOTE,
                P_FATHER_ID = office.FATHER_ID,
                P_ACTIVE = boolActive
            }, commandType: CommandType.StoredProcedure);
            return office;
        }

        public async Task<OFFICE> UpdateOffice(OFFICE office)
        {
            var boolActive = 0;
            if(office.ACTIVE.ToString() == "True")
                boolActive = 1;
            await db.ExecuteAsync("UPDATE_OFFICE",
            new 
            {
                P_ID = office.ID,
                P_NAME = office.NAME,
                P_NOTE = office.NOTE,
                P_FATHER_ID = office.FATHER_ID,
                P_ACTIVE = boolActive
            }, commandType: CommandType.StoredProcedure);
            return office;
        }

        public async Task DeleteOffice(string id)
        {
           await db.ExecuteAsync("DELETE_OFFICE", new { P_ID = id }, commandType: CommandType.StoredProcedure);
        }

    }
}