using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EmployeeBackend.Models;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EDataController : Controller
    {
        public IConfiguration Configuration { get; }

        public EDataController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            List<Employee> employeeRecords = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("EmployeeLinuxdb")))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From Employee";
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeeRecords.Add(new Employee() { ID = reader.GetInt32(0), Name = reader.GetString(1), Department = reader.GetString(2), Age = reader.GetInt32(3) });
                }
            }
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return employeeRecords;
        }
    }
}