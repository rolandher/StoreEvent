using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DTO
{
    public class RegisterProductDTO
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid ProductId { get; set; }
        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }

        [Required] public double Price { get; set; }

        [Required] public int InvetoryStock { get; set; }

        [Required] public string Category { get; set; }

        [Required] public Guid BranchId { get; set; }

        [Required]

        [ForeignKey("BranchId")]
        public virtual RegisterBranchDTO Branch { get; set; }


        public RegisterProductDTO(string name, string description, double price, int inventoryStock, string category, Guid branchId)
        {

            Name = name;
            Description = description;
            Price = price;
            InvetoryStock = inventoryStock;
            Category = category;
            BranchId = branchId;
        }

    }
}
