using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class RegisterProductInventoryStockDTO
    {
        [Required] public string Id { get; set; }

        [Required] public int Quantity { get; set; }

        public RegisterProductInventoryStockDTO(string id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
               
    }
}
