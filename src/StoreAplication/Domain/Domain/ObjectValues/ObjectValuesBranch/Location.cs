using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues
{
    public class Location
    {
        public string Country { get; set; }
        public string City { get; set; }

        public Location(string country, string city)
        {
            Country = country;
            City = city;
        }
    }
}
