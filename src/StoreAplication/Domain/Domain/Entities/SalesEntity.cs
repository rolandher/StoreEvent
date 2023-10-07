using Domain.ObjectValues.ObjectValuesSales;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SalesEntity
    {
        [Required] public Guid SalesId { get; set; }

        [Required] public SalesObjectNumber Number { get; set; }

        [Required] public SalesObjectQuantity Quantity { get; set; }

        [Required] public SalesObjectType Type { get; set; }

        [Required] public SalesObjectTotal Total { get; set; }

        [Required] public Guid BranchId { get; set; }

        public virtual BranchEntity BranchEntity { get; set; }

        public SalesEntity(SalesObjectNumber number, SalesObjectQuantity quantity, SalesObjectType type, SalesObjectTotal total, Guid branchId)
        {
            Number = number;
            Quantity = quantity;
            Type = type;
            Total = total;
            BranchId = branchId;
        }
    }
}
