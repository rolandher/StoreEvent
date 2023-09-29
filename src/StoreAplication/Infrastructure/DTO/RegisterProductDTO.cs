using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class RegisterProductDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; }
        [Required] public int BranchId { get; set; }

        [Required] public string ProductName { get; set; }

        [Required] public string ProductDescription { get; set; }

        [Required] public decimal ProductPrice { get; set; }

        [Required] public int ProductInventoryStock { get; set; }

        [Required] public string ProductCategory { get; set; }

        [Required]

        [ForeignKey("BranchId")]
        public virtual RegisterBranchDTO Branch { get; set; }

        public RegisterProductDTO(int branchId, string productName, string productDescription,
                       decimal productPrice, int productStock, string productCategory)
        {
            BranchId = branchId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductInventoryStock = productStock;
            ProductCategory = productCategory;
        }
       

    }
}
