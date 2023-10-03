using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues.ObjectValuesProduct
{
    public class ProductObjectPrice
    {
        public double Price { get; set; }
        
        public ProductObjectPrice(double price)
        {
            Price = price;
        }
    }
}
