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

        [HttpGet]
        public IEnumerable<CustomerSummary> Get()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC CustomerSummary";
            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command);
            return result;
        }

        [HttpGet("ByCountry/{id}")]
        public IEnumerable<CustomerSummary> GetByCountry(string id = null)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC CustSummaryByCountry @Country";
            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command, new { Country = id });
            return result;
        }

    }
}