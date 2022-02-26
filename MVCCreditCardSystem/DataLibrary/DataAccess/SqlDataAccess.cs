using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        //Get connection string from Web.config
        public static string GetConnectionString(string connectionName = "MVCCreditCardDB") => ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

        //Make connection to database and fetch data
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString()))
            {
                return conn.Query<T>(sql).ToList();
            }
        }

        //Make connection to database and save the supplied information
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString()))
            {
                return conn.Execute(sql, data);
            }
        }

        //Used to determine if the record already exists in the database
        public static object FetchData(string sql)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString()))
            {
                return conn.Query(sql).FirstOrDefault();
            }
        }
    }
}
