using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Product
{
    public class RegisterSaleCommand
    {
        [Required] public RegisterProductSaleCommand Products { get; set; }
    }
}
