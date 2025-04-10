using Microsoft.Data.SqlClient;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientRepository : IClientRepository
    {
        private BaseConfiguration baseConfiguration = new BaseConfiguration();
        private string _connectionString { get; set; }

        public ClientRepository()
        {
            _connectionString = baseConfiguration.GetDatabaseConnectionString();
        }

        public void CreateNewClient(Client client)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Client (firstName, middleName, lastName, birthDate, email, acceptedRGDPT, contactName, contactEmail, contactPhone, contactAddressId) " +
                               "VALUES (@firstname, @middlename, @lastname, @birthdate, @email, @acceptedRGDPT, @contactName, @contactEmail, @contactPhone, @contactAddressId)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = client.FirstName;
                    cmd.Parameters.Add("@middlename", SqlDbType.VarChar).Value = client.MiddleName;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = client.LastName;
                    cmd.Parameters.Add("@birthdate", SqlDbType.DateTime).Value = client.BirtDate;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = client.Email;
                    cmd.Parameters.Add("@acceptedRGDPT", SqlDbType.Bit).Value = client.AcceptedRGDPT;
                    cmd.Parameters.Add("@contactName", SqlDbType.VarChar).Value = client.ContactName;
                    cmd.Parameters.Add("@contactEmail", SqlDbType.VarChar).Value = client.ContactEmail;
                    cmd.Parameters.Add("@contactPhone", SqlDbType.VarChar).Value = client.ContactPhone;
                    cmd.Parameters.Add("@contactAddressId", SqlDbType.Int).Value = client.ContactAddressId;


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClient(Client client)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Client SET firstName = @firstname, middleName = @middlename, lastName = @lastname, " +
                               "birthDate = @birthdate, email = @email, acceptedRGDPT = @acceptedRGDPT, " +
                               "contactName = @contactName, contactEmail = @contactEmail, contactPhone = @contactPhone WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = client.Id;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = client.FirstName;
                    cmd.Parameters.Add("@middlename", SqlDbType.VarChar).Value = client.MiddleName;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = client.LastName;
                    cmd.Parameters.Add("@birthdate", SqlDbType.DateTime).Value = client.BirtDate;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = client.Email;
                    cmd.Parameters.Add("@acceptedRGDPT", SqlDbType.Bit).Value = client.AcceptedRGDPT;
                    cmd.Parameters.Add("@contactName", SqlDbType.VarChar).Value = client.ContactName;
                    cmd.Parameters.Add("@contactEmail", SqlDbType.VarChar).Value = client.ContactEmail;
                    cmd.Parameters.Add("@contactPhone", SqlDbType.VarChar).Value = client.ContactPhone;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Client GetClientById(int id)
        {
            Client client = new Client();
            client.ContactAddress = new Address();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Client WHERE id = @id";
                //using (SqlCommand cmd = new SqlCommand(query, con))
                //{
                //    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                //    con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;


                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client = new Client(reader["firstName"].ToString(), reader["middleName"].ToString(), reader["lastName"].ToString(), 
                            Convert.ToDateTime(reader["birthDate"].ToString()), reader["email"].ToString(), Convert.ToBoolean(reader["acceptedRGDPT"].ToString()), 
                            reader["contactName"].ToString(), reader["contactEmail"].ToString(), reader["contactPhone"].ToString());

                        client.Id = Convert.ToInt32(reader["id"].ToString());
                        client.ContactAddressId = Convert.ToInt32(reader["contactAddressId"].ToString());
                        
                        return client;
                    }
                }
            }
            return null;
        }

        public Client GetClientByEmail(string email)
        {
            Client client = new Client();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Client WHERE email = @email";
                //using (SqlCommand cmd = new SqlCommand(query, con))
                //{
                //    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                //    con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = email;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client = new Client(reader["firstName"].ToString(), reader["middleName"].ToString(), reader["lastName"].ToString(),
                            Convert.ToDateTime(reader["birthDate"].ToString()), reader["email"].ToString(), Convert.ToBoolean(reader["acceptedRGDPT"].ToString()),
                            reader["contactName"].ToString(), reader["contactEmail"].ToString(), reader["contactPhone"].ToString());

                        client.Id = Convert.ToInt32(reader["id"].ToString());
                        client.ContactAddressId = Convert.ToInt32(reader["contactAddressId"].ToString());

                        return client;
                    }
                }
            }
            return null;
        }
        public Client GetClientByContactEmail(string contactEmail)
        {
            Client client = new Client();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Client WHERE contactEmail = @contactEmail";
                //using (SqlCommand cmd = new SqlCommand(query, con))
                //{
                //    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                //    con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@contactEmail", SqlDbType.VarChar);
                    cmd.Parameters["@contactEmail"].Value = contactEmail;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client = new Client(reader["firstName"].ToString(), reader["middleName"].ToString(), reader["lastName"].ToString(),
                            Convert.ToDateTime(reader["birthDate"].ToString()), reader["email"].ToString(), Convert.ToBoolean(reader["acceptedRGDPT"].ToString()),
                            reader["contactName"].ToString(), reader["contactEmail"].ToString(), reader["contactPhone"].ToString());

                        client.Id = Convert.ToInt32(reader["id"].ToString());
                        client.ContactAddressId = Convert.ToInt32(reader["contactAddressId"].ToString());

                        return client;
                    }
                }
            }
            return null;
        }

        public Client GetClientByPhone(string phone)
        {
            Client client = new Client();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Client WHERE contactPhone = @phone";
                //using (SqlCommand cmd = new SqlCommand(query, con))
                //{
                //    cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;

                //    con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                    cmd.Parameters["@phone"].Value = phone;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client = new Client(reader["firstName"].ToString(), reader["middleName"].ToString(), reader["lastName"].ToString(),
                            Convert.ToDateTime(reader["birthDate"].ToString()), reader["email"].ToString(), Convert.ToBoolean(reader["acceptedRGDPT"].ToString()),
                            reader["contactName"].ToString(), reader["contactEmail"].ToString(), reader["contactPhone"].ToString());

                        client.Id = Convert.ToInt32(reader["id"].ToString());
                        client.ContactAddressId = Convert.ToInt32(reader["contactAddressId"].ToString());

                        return client;
                    }
                }
            }
            return null;
        }

        public List<Client> GetAllClients()
        {
            Client client = new Client();
            List<Client> clients = new List<Client>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Client";
                //using (SqlCommand cmd = new SqlCommand(query, con))
                //{
                //    con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client = new Client(reader["firstName"].ToString(), reader["middleName"].ToString(), reader["lastName"].ToString(),
                            Convert.ToDateTime(reader["birthDate"].ToString()), reader["email"].ToString(), Convert.ToBoolean(reader["acceptedRGDPT"].ToString()),
                            reader["contactName"].ToString(), reader["contactEmail"].ToString(), reader["contactPhone"].ToString());

                        client.Id = Convert.ToInt32(reader["id"].ToString());
                        client.ContactAddressId = Convert.ToInt32(reader["contactAddressId"].ToString());

                        clients.Add(client);
                    }
                }
            }
            return clients; // Retorna a lista de clientes
        }

        public void DeleteClient(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Client WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
