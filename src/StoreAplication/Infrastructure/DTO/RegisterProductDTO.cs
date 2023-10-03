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
              

        public RegisterProductDTO(string name, string description, double price, string category, Guid branchId)
        {
            
            Name = name;
            Description = description;
            Price = price;            
            Category = category;
            BranchId = branchId;
        }        
       
    }
}
