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
    public class OrderController : ControllerBase
    {

        //private string connectionString;
        private IDAL dal;

        public OrderController(IDAL dalObject)
        {
            dal = dalObject;
        }

        //GET for ALL ORDERS
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return dal.GetAllOrders();
            
        }

        [HttpGet("CustomerId/{id}")]
        public IEnumerable<Order> GetOrdersByCustomerId(string id)
        {
            return dal.OrdersByCustomerId(id);
        }


        ////-----------------DELETE-------------------------
        [HttpDelete("OrderId/{id}")]
        public Object DeleteOrderDetailsByID(int id)
        {

            int result = dal.DeleteOrderDetailsById(id);

            if (result > 0)
            {
                return new { success = true };
            }
            return new { success = false };
        }
    }
}