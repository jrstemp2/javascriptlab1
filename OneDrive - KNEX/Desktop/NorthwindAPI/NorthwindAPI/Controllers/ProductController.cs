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
    public class ProductController : ControllerBase
    {
        private string connectionString;

        public ProductController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        [HttpGet("ProductDetail/{id}")]
        public IEnumerable<ProductDetail> GetProductDetails(int id)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC ProductDetail2 @OrderId";
            var result = conn.Query<ProductDetail>(command, new { OrderId = id });
            return result;
        }

        //-------------------------------------NEW---------------------------------------------
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Products";
            var result = conn.Query<Product>(command);
            return result;
        }

        [HttpGet("ByCategory/{id}")]
        public IEnumerable<Product> GetAllProducts(string id)
        {
            int id1 = int.Parse(id);
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Products WHERE CategoryId = @val";
            var result = conn.Query<Product>(command, new { val = id1});
            return result;
        }



        [HttpPost]
        public Object Post(Product p)
        {
            SqlConnection conn = null;
            string addString = "INSERT INTO Products (ProductName, SupplierId, CategoryId, Discontinued) VALUES (@ProductName, @SupplierId, @CategoryId, @Discontinued) SELECT SCOPE_IDENTITY();";
            
            int newId;

            try
            {
                conn = new SqlConnection(connectionString);
                newId = conn.ExecuteScalar<int>(addString, p);
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