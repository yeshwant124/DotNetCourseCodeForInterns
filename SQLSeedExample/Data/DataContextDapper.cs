using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLSeedExample.Data
{
    public class DataContextDapper
    {
        private readonly IConfiguration _config;
        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            using (IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                dbConnection.Open();
                using (IDbTransaction tran = dbConnection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    var holdVal = dbConnection.Query<T>(sql, null, transaction: tran, commandTimeout: 999999999);
                    dbConnection.Close();
                    return holdVal;
                }
            }
        }

        public int ExecuteSQL(string sql)
        {
            using (IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return dbConnection.Execute(sql);
            }
        }

        public void ExecuteProcedureMulti(string sql, IDbConnection dbConnection)
        {
            dbConnection.Execute(sql);
        }

    }
}
