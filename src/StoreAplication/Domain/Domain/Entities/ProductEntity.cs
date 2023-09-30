using Domain.ObjectValues.ObjectValuesProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Common.Enums;

namespace Domain.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }        

        [Required] public ProductObjectName Name { get; set; }

        [Required] public ProductObjectDescription Description { get; set; }

        [Required] public ProductObjectPrice Price { get; set; }

        [Required] public ProductObjectInventoryStock InventoryStock { get; set; }

        [Required] public ProductObjectCategory Category { get; set; }

        [Required] public string BranchId { get; set; }

        public virtual BranchEntity BranchEntity { get; set; }

        public ProductEntity( ProductObjectName name, ProductObjectDescription description, ProductObjectPrice price, ProductObjectCategory category, string branchId)
        {
            Name = name;            
            Description = description;
            Price = price;            
            Category = category;
            BranchId = branchId;
        }
               

    }
}
