using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Product
{
    public class RegisterProductSaleCommand
    {
        [Required] public Guid ProductId { get; set; }
        [Required] public int Quantity { get; set; }

    }
}
