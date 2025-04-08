using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class BaseConfiguration
    {
        private string _connectionString { get; set; }
        public BaseConfiguration() 
        {
            _connectionString = GetDatabaseConnectionString();
        }

        public string GetDatabaseConnectionString() 
        {
            _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=JD_JPA_JAL_RegisterData; Integrated Security=True; TrustServerCertificate=True;";
            return _connectionString;
        }
    }
}
