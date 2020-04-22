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
    public class OrderController : ControllerBase
    {

        private string connectionString;

        public OrderController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        //GET for ALL ORDERS
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Orders";
            var result = conn.Query<Order>(command);
            return result;
        }

        

        [HttpGet("CustomerId/{id}")]
        public IEnumerable<Order> GetProductDetails(string id)
        {
            
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Orders WHERE CustomerId = @val";
            var result = conn.Query<Order>(command, new { val= id });
            return result;
        }


        //-----------------DELETE-------------------------
        [HttpDelete("OrderId/{id}")]
        public Object DeleteOrderDetailsByID(int id)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string deleteString = "DELETE FROM [Order Details] WHERE OrderId = @id";

            int result = connection.Execute(deleteString, new { id = id });

            if (result > 0)
            {
                return new { success = true };
            }
            return new { success = false };
        }
    }
}