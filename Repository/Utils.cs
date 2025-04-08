using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Utils
    {
        private BaseConfiguration baseConfiguration = new BaseConfiguration();
        private string _connectionString { get; set; }
        public Utils() 
        {
            _connectionString = baseConfiguration.GetDatabaseConnectionString();
        }

        public int SearchId(string table)
        {
            int Id = -1;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = $"DECLARE @next_id AS INT = IDENT_CURRENT( '{table}' ); SELECT @next_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    
                    Id = Convert.ToInt32(cmd.ExecuteScalar());

                    //SqlDataAdapter da = new SqlDataAdapter();
                    //DataTable dt = new DataTable();
                    //da.SelectCommand = cmd;
                    //da.Fill(dt);

                    //if (dt.Rows.Count == 1)
                    //{
                    //    Id = Convert.ToInt32(dt.Rows[0]["íd"]);
                    //}
                }
            }
                return Id;
        }

    }
}
