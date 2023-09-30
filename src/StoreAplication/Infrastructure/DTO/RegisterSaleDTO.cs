using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class RegisterSaleDTO
    {
        [Required] public List<ProductSaleDTO> ProductSales { get; set; }
    }
}
