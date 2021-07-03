using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public OFFICE GetOffice(string id)
        {
            return db.Query<OFFICE>("GET_OFFICE", new { P_ID = id }, commandType: CommandType.StoredProcedure).Single();
        }

        public List<OFFICE> GetAllOffice()
        { 
            return db.Query<OFFICE>("GET_ALL_OFFICE", commandType: CommandType.StoredProcedure).ToList();
        }

        public OFFICE CreateOffice(OFFICE office)
        {
            var boolActive = 0;
            if(office.ACTIVE.ToString() == "True")
                boolActive = 1;
            db.Execute("CREATE_OFFICE",
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

        public OFFICE UpdateOffice(OFFICE office)
        {
            var boolActive = 0;
            if(office.ACTIVE.ToString() == "True")
                boolActive = 1;
            db.Execute("UPDATE_OFFICE",
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

        public void DeleteOffice(string id)
        {
            db.Execute("DELETE_OFFICE", new { P_ID = id }, commandType: CommandType.StoredProcedure);
        }

    }
}