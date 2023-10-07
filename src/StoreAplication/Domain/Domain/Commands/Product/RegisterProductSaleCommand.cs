using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Product
{
    public class RegisterProductSaleCommand
    {
        [Required] public int Quantity { get; set; }

    }
}
