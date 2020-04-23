using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private string connectionString;

        public CustomerController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }
        //-------------------------------------NEW---------------------------------------------------------
        [HttpGet]
        public IEnumerable<CustomerSummary> GetAllCustomers()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Customers";
            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command);
            return result;
        }

        [HttpGet("AllByCountry/{id}")]
        public IEnumerable<CustomerSummary> GetAllCustomers(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Customers WHERE Country = @val";
            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command, new { val = id });
            return result;
        }
        //----------------------------------------------------------------------------------------------------



        [HttpGet("CustomerSummary")]
        public IEnumerable<CustomerSummary> GetCustomerSummary()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC CustomerSummary";
            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command);
            return result;
        }

        [HttpGet("ByCountry/{id}")]
        public IEnumerable<CustomerSummary> GetByCustomerSummaryCountry(string id = null)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC CustSummaryByCountry @Country";
            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command, new { Country = id });
            return result;
        }

        [HttpPost]
        public Object Post(Customer c)
        {
            SqlConnection conn = null;
            string addString = "INSERT INTO Customers (CustomerID, ContactName, CompanyName, Country) VALUES (@CustomerID, @ContactName, @CompanyName, @Country) SELECT SCOPE_IDENTITY();";

            int newId;

            try
            {
                conn = new SqlConnection(connectionString);
                newId = conn.ExecuteScalar<int>(addString, c);
            }
            catch (Exception e)
            {
                newId = -1;
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (conn != null)
                {
                    conn.Close(); //explicitly closing the connection
                }
            }

            //return newId;


            if (newId < 0)
            {
                return new { success = false };
            }
            return new { success = true, id = newId };
        }
    }
}