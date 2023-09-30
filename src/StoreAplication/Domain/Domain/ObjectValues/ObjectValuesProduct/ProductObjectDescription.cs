using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues.ObjectValuesProduct
{
    public class ProductObjectDescription
    {
        public string Description { get; set; }

        public ProductObjectDescription(string description)
        {
            Description = description;
        }
    }
}
