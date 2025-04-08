using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Models;
using Repository.Interfaces;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private Utils _utils = new Utils();
        private BaseConfiguration baseConfiguration = new BaseConfiguration();
        private string _connectionString { get; set; }



        public EmployeeRepository() 
        {
            _connectionString = baseConfiguration.GetDatabaseConnectionString();
        }

        public void CreateNewEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = "INSERT INTO Employees (firstname, middlename, lastname, birthdate, email, acceptedRGDPT, addressId, nib, nif, managerName) " +
                               "VALUES (@firstname, @middlename, @lastname, @birthdate, @email, @acceptedRGDPT, @addressId, @nib, @nif, @managerName)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@firstname", employee.FirstName);
                    cmd.Parameters.AddWithValue("@middlename", employee.MiddleName);
                    cmd.Parameters.AddWithValue("@lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("@birthdate", employee.BirtDate);
                    cmd.Parameters.AddWithValue("@email", employee.Email);
                    cmd.Parameters.AddWithValue("@acceptedRGDPT", employee.AcceptedRGDPT);
                    cmd.Parameters.AddWithValue("@addressId", employee.AddressId);
                    cmd.Parameters.AddWithValue("@nib", employee.NIB);
                    cmd.Parameters.AddWithValue("@nif", employee.NIF);
                    cmd.Parameters.AddWithValue("@managerName", employee.ManagerName);

                    cmd.ExecuteNonQuery();
                }
                string query1 = "INSERT INTO JobInfo (jobRole, JobDescription) " +
                               "VALUES (@jobRole, @jobDescription)";
                using (SqlCommand cmd = new SqlCommand(query1, con))
                {
                    cmd.Parameters.Add("@jobRole", SqlDbType.NVarChar);
                    cmd.Parameters["@jobRole"].Value = employee.JobRole;
                    cmd.Parameters.Add("@jobDescription", SqlDbType.NVarChar);
                    cmd.Parameters["@jobDescription"].Value = employee.JobDescription;

                    cmd.ExecuteNonQuery();
                }

                employee.JobId = _utils.SearchId("JobInfo");
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open(); // Abre a conexão uma vez

                // Atualiza informações do funcionário
                string query = "UPDATE Employees SET firstname = @firstname, middlename = @middlename, lastname = @lastname, " +
                               "birthdate = @birthdate, email = @email, acceptedRGDPT = @acceptedRGDPT, addressId = @addressId, " +
                               "nib = @nib, nif = @nif, managerName = @managerName WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = employee.Id;
                    cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = employee.FirstName;

                    if (employee.MiddleName != null)
                        cmd.Parameters.Add("@middlename", SqlDbType.NVarChar).Value = employee.MiddleName;
                    else
                        cmd.Parameters.Add("@middlename", SqlDbType.NVarChar).Value = "";

                    cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = employee.LastName;
                    cmd.Parameters.Add("@birthdate", SqlDbType.Date).Value = employee.BirtDate;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = employee.Email;
                    cmd.Parameters.Add("@acceptedRGDPT", SqlDbType.Bit).Value = employee.AcceptedRGDPT;
                    cmd.Parameters.Add("@addressId", SqlDbType.Int).Value = employee.AddressId;
                    cmd.Parameters.Add("@nib", SqlDbType.Int).Value = employee.NIB;
                    cmd.Parameters.Add("@nif", SqlDbType.Int).Value = employee.NIF;
                    cmd.Parameters.Add("@managerName", SqlDbType.NVarChar).Value = employee.ManagerName;

                    cmd.ExecuteNonQuery(); // Executa a atualização do funcionário
                }

                // Atualiza informações do trabalho
                string query1 = "UPDATE JobInfo SET jobRole = @jobRole, JobDescription = @jobDescription WHERE id = @jobInfoId";
                using (SqlCommand cmd = new SqlCommand(query1, con))
                {
                    cmd.Parameters.Add("@jobRole", SqlDbType.NVarChar).Value = employee.JobRole;
                    cmd.Parameters.Add("@jobDescription", SqlDbType.NVarChar).Value = employee.JobDescription;
                    cmd.Parameters.Add("@jobInfoId", SqlDbType.Int).Value = employee.JobId; // Supondo que JobId seja um inteiro

                    cmd.ExecuteNonQuery(); // Executa a atualização do trabalho
                }
            }
        }
        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Employees WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            Address address = new Address();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT e.id, e.firstname, e.middlename, e.lastname, e.birthdate, e.email, e.acceptedRGDPT, e.nif, e.nib, e.managerName, e.addressId, e.jobInfoId, j.jobRole, j.jobDescription " +
                                "FROM Employees e " +
                                "LEFT JOIN JobInfo j ON e.jobInfoId = j.id " +
                                "WHERE e.id = @id;";
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
                        employee = new Employee(reader["firstname"].ToString(), reader["middlename"].ToString(), reader["lastname"].ToString(), 
                            Convert.ToDateTime(reader["birthdate"].ToString()), reader["email"].ToString(), Convert.ToBoolean(reader["acceptedRGDPT"].ToString()), Convert.ToInt32(reader["addressId"].ToString()),
                            Convert.ToInt32(reader["nib"].ToString()), Convert.ToInt32(reader["nif"].ToString()),
                            reader["jobRole"].ToString(), reader["jobDescription"].ToString(), reader["managerName"].ToString(), address);
                        employee.JobId = Convert.ToInt32(reader["jobInfoId"].ToString());
                    }
                    employee.Id = id;
                    
                    return employee;
                }
            }            
        }

        public List<Employee> GetAll()
        {
            List<Employee> listEmployees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                List<Employee> _listEmployees = new List<Employee>();
                Address address = null;
                string query = "SELECT * FROM Employees";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;


                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee employee = new Employee(reader["firstname"].ToString(), reader["middlename"].ToString(), reader["lastname"].ToString(),
                             Convert.ToDateTime(reader["birthdate"].ToString()), reader["email"].ToString(), Convert.ToBoolean(reader["acceptedRGDPT"].ToString()), Convert.ToInt32(reader["addressId"].ToString()),
                             Convert.ToInt32(reader["nib"].ToString()), Convert.ToInt32(reader["nif"].ToString()),
                             "", "", reader["managerName"].ToString(), address);
                        employee.Id = Convert.ToInt32(reader["id"].ToString());
                        _listEmployees.Add(employee);
                    }
                }
                return _listEmployees;
            }

        }

        public List<Employee> GetAll2()
        {
            List<Employee> _listEmployees = new List<Employee>();
            Address address = new Address();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Employees";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Employee employee = new Employee(dr["firstname"].ToString(), dr["middlename"].ToString(), dr["lastname"].ToString(), Convert.ToDateTime(dr["birthdate"].ToString()),
                            dr["email"].ToString(), Convert.ToBoolean(dr["acceptedRGDPT"].ToString()), Convert.ToInt32(dr["addressId"]), Convert.ToInt32(dr["nib"].ToString()), Convert.ToInt32(dr["nif"].ToString()),
                            "", "", dr["managerName"].ToString(), address);
                        employee.Id = Convert.ToInt32(dr["id"].ToString());
                        _listEmployees.Add(employee);
                    }
                }
                return _listEmployees;
            }

        }

    }
}
