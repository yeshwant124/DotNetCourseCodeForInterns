using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetAPI.Data
{
    public class DataContextDapper
    {
        private IConfiguration _config;

        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return connection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));            
            return connection.QuerySingleOrDefault<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return (connection.Execute(sql) > 0);
        }

        public int ExecuteSqlWithRowcount(string sql)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return connection.Execute(sql);
        }
    }
}
