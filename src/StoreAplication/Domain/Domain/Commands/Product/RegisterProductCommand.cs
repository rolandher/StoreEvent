using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Common.Enums;

namespace Domain.Commands.Product
{
    public class RegisterProductCommand
    {
        [Required] public string ProductName { get; set; }

        [Required] public int BranchId { get; set; }

        [Required] public string ProductDescription { get; set; }

        [Required] public decimal ProductPrice { get; set; }

        [Required] public int ProductInventoryStock { get; set; }

        [Required] public CategoryEnum ProductCategory { get; set; }
    }
}
