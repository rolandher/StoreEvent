using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Product
{
    public class RegisterProductInventoryCommand
    {
        [Required] public int Quantity { get; set; }

    }
}
