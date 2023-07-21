using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetAPIIntermediate.Data
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
            return connection.QuerySingle<T>(sql);
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

        public bool ExecuteSqlWithParameters(string sql, List<SqlParameter> sqlParameters)
        {
            SqlCommand commandWithParams = new SqlCommand(sql);
            foreach(SqlParameter param in sqlParameters) { 
                commandWithParams.Parameters.Add(param);
            }

            SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            connection.Open();

            commandWithParams.Connection = connection;
            
            int rowsAffected = commandWithParams.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }
    }
}
