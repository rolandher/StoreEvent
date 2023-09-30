using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Product
{
    public class RegisterProductSaleCommand
    {
        [Required] public string Id { get; set; }
        [Required] public int Quantity { get; set; }

        public RegisterProductSaleCommand(string id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}
