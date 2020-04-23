using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models.Services
{
    public interface IDAL
    {

        //--------------PRODUCT---------------------
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategoryId(int id);
        int AddProduct(Product p);

        //---------------ORDER--------------------
        IEnumerable<Order> GetAllOrders();
        int DeleteOrderDetailsById(int id);
        IEnumerable<Order> OrdersByCustomerId(string id);

        //--------------CUSTOMER------------------ 
        IEnumerable<Customer> GetCustomersAll();
        IEnumerable<Customer> GetCustomersAllByCountry(string id);
        Customer GetCustByCustId(string id);
        int AddCustomer(Customer c);


    }
}
