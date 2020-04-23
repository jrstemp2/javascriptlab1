using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int Discontinued { get; set; }
        
    }
}
