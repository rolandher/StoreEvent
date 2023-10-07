using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DTO
{
    public class RegisterSalesDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SalesId { get; set; }

        [Required] public string Type { get; set; }

        [Required] public int Number { get; set; }

        [Required] public int Quantity { get; set; }

        [Required] public int Total { get; set; }

        [Required] public Guid BranchId { get; set; }

        [Required]
        [ForeignKey("BranchId")]
        public virtual RegisterBranchDTO Branch { get; set; }

        public RegisterSalesDTO(string type, int number, int quantity, int total, Guid branchId)
        {
            Type = type;
            Number = number;
            Quantity = quantity;
            Total = total;
            BranchId = branchId;
        }
    }
}
