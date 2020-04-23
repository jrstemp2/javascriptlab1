using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class CustomerSummary
    {
        private string contactName;
        private string contactTitle;
        private string companyName;
        private string country;

        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactTitle { get => contactTitle; set => contactTitle = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string Country { get => country; set => country = value; }
    }
}
