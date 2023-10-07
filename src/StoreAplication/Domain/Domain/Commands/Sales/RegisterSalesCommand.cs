using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Sales
{
    public class RegisterSalesCommand
    {
        [Required] public int Number { get; set; }

        [Required] public string Type { get; set; }

        [Required] public int Quantity { get; set; }

        [Required] public int Total { get; set; }

        [Required] public Guid BranchId { get; set; }
    }
}
