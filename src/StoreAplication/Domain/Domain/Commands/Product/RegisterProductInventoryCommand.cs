using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Product
{
    public class RegisterProductInventoryCommand
    {
       [Required] public int Quantity { get; set; }       
        
    }
}
