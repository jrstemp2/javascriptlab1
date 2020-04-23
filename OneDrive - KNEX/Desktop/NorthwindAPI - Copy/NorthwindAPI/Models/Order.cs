using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class Order
    {
        public int OrderID {get; set;}
        public string CustomerId {get; set;}
        public DateTime OrderDate {get; set;}
        public DateTime ShipDate {get; set;}
        public string ShipCity {get; set;}
        public string ShipCountry {get; set;}

    }
}
