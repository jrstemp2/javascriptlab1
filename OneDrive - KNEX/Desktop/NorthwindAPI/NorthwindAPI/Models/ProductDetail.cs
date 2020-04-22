using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class ProductDetail
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double  CurrentPrice { get; set; }
        public double  PriceatOrder { get; set; }
        public double Discount { get; set; }

}
}
