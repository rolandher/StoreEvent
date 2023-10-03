using Domain.ObjectValues.ObjectValuesProduct;
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
        [Required] public string Name { get; set; }        

        [Required] public string Description { get; set; }

        [Required] public double Price { get; set; }        

        [Required] public string Category { get; set; }

        [Required] public Guid BranchId { get; set; }
    }
}
