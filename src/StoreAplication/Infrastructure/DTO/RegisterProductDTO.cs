using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ObjectValues.ObjectValuesProduct;

namespace Infrastructure.DTO
{
    public class RegisterProductDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }

        [Required] public double Price { get; set; }       

        [Required] public string Category { get; set; }

        [Required] public string BranchId { get; set; }

        [Required]

        [ForeignKey("BranchId")]
        public virtual RegisterBranchDTO Branch { get; set; }

        public RegisterProductDTO(string name, string description, double price, string category, string branchId)
        {
            Name = name;            
            Description = description;
            Price = price;            
            Category = category;
            BranchId = branchId;
        }     

        public RegisterProductDTO()
        {
        }
       

    }
}
