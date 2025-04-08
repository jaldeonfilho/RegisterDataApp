using Microsoft.Data.SqlClient;
using Models;
using Repository.Interfaces;
using System.Data;

namespace Repository
{
    public class AddressRepository : IAddressRepository
    {
        private Utils _utils = new Utils();
        private BaseConfiguration baseConfiguration = new BaseConfiguration();

        private string _connectionString { get; set; }
        private int _searchId { get; set; }
        private string _addressId = "Address";

        public AddressRepository() 
        {
            _connectionString = baseConfiguration.GetDatabaseConnectionString();
        }

        public int CreateNewAddress(Address address)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Address (street1, street2, number, locale, city, region, postalCode) " +
                               "VALUES (@street1, @street2, @number, @locale, @city, @region, @postalCode)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@street1", address.Street1);
                    cmd.Parameters.AddWithValue("@street2", address.Street2);
                    cmd.Parameters.AddWithValue("@number", address.DoorNumber);
                    cmd.Parameters.AddWithValue("@locale", address.Locale);
                    cmd.Parameters.AddWithValue("@city", address.City);
                    cmd.Parameters.AddWithValue("@region", address.Region);
                    cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                
            }
            address.Id = _utils.SearchId("Address");
            return address.Id;
        }

        public Address GetAddressById(int id)
        {
            Address address = new Address();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Address WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;


                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        DataRow dr = dt.Rows[0];
                        address = new Address(dr["street1"].ToString(), dr["street2"].ToString(), Convert.ToInt32(dr["number"].ToString()),
                            dr["city"].ToString(), dr["postalCode"].ToString(), dr["region"].ToString(), dr["locale"].ToString());
                    }

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    address = new Address(dr["street1"].ToString(), dr["street2"].ToString(), Convert.ToInt32(dr["number"].ToString()),
                    //        dr["city"].ToString(), dr["postalCode"].ToString(), dr["region"].ToString(), dr["locale"].ToString());
                    //}
                    return address;
                }
            }
        }
    }
}
