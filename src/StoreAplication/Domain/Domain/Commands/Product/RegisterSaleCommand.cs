using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Product
{
    public class RegisterSaleCommand
    {
        [Required] public List<ProductEntity> Products { get; set; }

        public RegisterSaleCommand(List<ProductEntity> products)
        {
            Products = products;
        }
    }
}
