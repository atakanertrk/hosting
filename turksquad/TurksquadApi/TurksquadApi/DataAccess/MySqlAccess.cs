using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TurksquadApi.DataAccess
{
    public class MySqlAccess
    {
        private static string connetionString = "server=localhost:3306;database=turksqua_;uid=mysqlDBtest;pwd=@asd123ERT;";
        public bool ConnectionControl()
        {
            MySqlConnection connection = new MySqlConnection(connetionString);
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            
        }
        public string GetPassword()
        {
            string result;
            MySqlConnection connection = new MySqlConnection(connetionString);
            connection.Open();
            string sql = "SELECT Password FROM LoginInfo";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            using (DataTable dataTable = new DataTable())
            {
                dataTable.Load(rdr);
                result = dataTable.Rows[0][0].ToString();
            }
            return result;
        }
    }
}
