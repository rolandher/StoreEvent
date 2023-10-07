using System.ComponentModel.DataAnnotations;

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
