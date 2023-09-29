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
        [Required] public int BranchId { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public List<ProductSaleDTO> Products { get; set; }
    }
}
