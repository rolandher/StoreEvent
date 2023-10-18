using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdapterSQL.DTO
{
    public class RegisterSalesDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SalesId { get; set; }

        [Required] public int Number { get; set; }

        [Required] public int Quantity { get; set; }

        [Required] public double Total { get; set; }

        [Required] public string Type { get; set; }

        [Required] public Guid BranchId { get; set; }

        [Required]
        [ForeignKey("BranchId")]
        public virtual RegisterBranchDTO Branch { get; set; }

        public RegisterSalesDTO(int number, int quantity, double total, string type, Guid branchId)
        {

            Number = number;
            Quantity = quantity;
            Total = total;
            Type = type;
            BranchId = branchId;
        }
    }
}
