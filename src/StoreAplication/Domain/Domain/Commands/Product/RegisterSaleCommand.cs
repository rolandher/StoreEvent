using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Product
{
    public class RegisterSaleCommand
    {
        [Required] public int Number { get; set; }
        [Required] public Guid BranchId { get; set; }
        [Required] public List<RegisterProductSaleCommand> Products { get; set; }
    }
}
