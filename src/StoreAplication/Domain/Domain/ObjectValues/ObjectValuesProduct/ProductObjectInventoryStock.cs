using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues.ObjectValuesProduct
{
    public class ProductObjectInventoryStock
    {
        public int InventoryStock { get; set; }

        public ProductObjectInventoryStock(int stock)
        {
            InventoryStock = stock;
        }
    }
}
