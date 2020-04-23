using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace NorthwindAPI.Models.Services
{
    //-----------------------SETTING CONNECTION UP-----------------------
    public class DALSqlServer : IDAL
    {
        private string connectionString;

        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }
    //------------------------------------------------------------------------
    //-------------------------PRODUCT CONTROLLER SQL---------------------------
        public IEnumerable<Product> GetAllProducts()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Products";
            IEnumerable<Product> Products = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Products = connection.Query<Product>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Products;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Products WHERE CategoryId = @val";
            var result = conn.Query<Product>(command, new { val = id });
            return result;
        }

        public int AddProduct(Product p)
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

            return newId;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Orders";
            var result = conn.Query<Order>(command);
            return result;
        }

        public int DeleteOrderDetailsById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string deleteString = "DELETE FROM [Order Details] WHERE OrderId = @id";

            int result = connection.Execute(deleteString, new { id = id });
            return result;
        }

        public IEnumerable<Order> OrdersByCustomerId(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Orders WHERE CustomerId = @val";
            var result = conn.Query<Order>(command, new { val = id });
            return result;
        }

        //-------------------------------------------------------------------------------------

        //---------------------------CUSTOMER CONTROLLER SQL-----------------------------------
        public IEnumerable<Customer> GetCustomersAll()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Customers";
            IEnumerable<Customer> result = conn.Query<Customer>(command);
            return result;
        }

        public IEnumerable<Customer> GetCustomersAllByCountry(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Customers WHERE Country = @val";
            IEnumerable<Customer> result = conn.Query<Customer>(command, new { val = id });
            return result;
        }

        public Customer GetCustByCustId(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Customers WHERE CustomerId = @val";
            Customer c = conn.QueryFirstOrDefault<Customer>(command, new { val = id });
            return c;
        }

        public int AddCustomer(Customer c)
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

            return newId;
        }

        //-------------------------------------------------------------------------------------
    }
}
