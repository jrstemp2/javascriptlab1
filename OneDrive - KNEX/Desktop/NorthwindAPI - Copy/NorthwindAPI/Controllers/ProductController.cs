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
using NorthwindAPI.Models.Services;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IDAL dal;

        public ProductController(IDAL dalObject)
        {
            dal = dalObject;
        }



        //[HttpGet("ProductDetail/{id}")]
        //public IEnumerable<ProductDetail> GetProductDetails(int id)
        //{
        //    Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    string command = "EXEC ProductDetail2 @OrderId";
        //    var result = conn.Query<ProductDetail>(command, new { OrderId = id });
        //    return result;
        //}

        //-------------------------------------NEW---------------------------------------------

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var result = dal.GetAllProducts();
            return result;
        }

        [HttpGet("ByCategory/{id}")]
        public IEnumerable<Product> GetAllProducts(int id)
        {
           
            return dal.GetProductsByCategoryId(id);
        }

        [HttpPost]
        public Object Post(Product p)
        {
            int newId = dal.AddProduct(p);
            if (newId < 0)
            {
                return new { success = false };
            }
            return new { success = true, id = newId };
        }
    }
}