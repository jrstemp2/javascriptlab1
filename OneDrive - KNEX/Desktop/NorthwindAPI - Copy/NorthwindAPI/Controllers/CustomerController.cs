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
    public class CustomerController : ControllerBase
    {
        private IDAL dal;

        public CustomerController(IDAL dalObject)
        {
            dal = dalObject;
        }
        //-------------------------------------NEW---------------------------------------------------------
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> result = dal.GetCustomersAll();
            return result;
        }
        [HttpGet("AllByCountry/{id}")]
        public IEnumerable<Customer> GetAllCustomers(string id)
        {

            IEnumerable<Customer> result = dal.GetCustomersAllByCountry(id);
            return result;
        }

        [HttpGet("CustById/{id}")]
        public Customer GetCustomerById(string id)
        {
            Customer c = dal.GetCustByCustId(id);
            return c;
        }
        //---------------------------------------------------------------------------------------------------

        [HttpPost]
        public Object PostCustomer(Customer c)
        {
            int newId = dal.AddCustomer(c);


            if (newId < 0)
            {
                return new { success = false };
            }
            return new { success = true, id = newId };
        }
    }
}