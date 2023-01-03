using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlQuery
    {
        //return object to get the information fro DB
        public delegate object SetDataReader_delegate(SqlDataReader reader);
        //??
        public static SqlDataReader ReadFromDB(string sqlQuery, SetDataReader_delegate func)
        {
            const string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQuery;

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        func(reader);
                    }
                }

            }
            //if error
            return null;
        }
        public static void SendToDB(string sqlQuery)
        {
            const string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQuery;

                connection.Open();
                // Adapter
                using ( SqlCommand command = new SqlCommand(queryString, connection))
                {
                    //Reader
                    command.ExecuteNonQuery();
                }

            }
        }

        
    }
}
