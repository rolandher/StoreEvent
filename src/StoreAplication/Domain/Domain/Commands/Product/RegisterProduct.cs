using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Product
{
    public class RegisterProduct
    {
        public string ProductName { get; set; }

        public string BranchId { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductStock { get; set; }

        public string ProductCategory { get; set; }
    }
}
