using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues
{
    public class BranchObjectLocation
    {
        public string Country { get; set; }
        public string City { get; set; }

        public BranchObjectLocation(string country, string city)
        {
            Country = country;
            City = city;
        }
    }
}
