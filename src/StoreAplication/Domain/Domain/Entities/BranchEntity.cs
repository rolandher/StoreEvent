using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesBranch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BranchEntity
    {
        public Guid Id { get; set; }

        [Required] public BranchObjectName Name { get; set; }

        [Required] public BranchObjectLocation Location { get; set; }

        public virtual List<UserEntity> UserEntities { get; set; }

        public virtual List<ProductEntity> ProductEntities { get; set; }

        public BranchEntity(BranchObjectName name, BranchObjectLocation location)
        {
            Name = name;
            Location = location;
        }
    }
}
