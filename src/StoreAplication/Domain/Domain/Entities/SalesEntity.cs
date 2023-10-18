using Domain.ObjectValues.ObjectValuesSales;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SalesEntity
    {
        [Required] public Guid SalesId { get; set; }

        [Required] public SalesObjectNumber Number { get; set; }

        [Required] public SalesObjectQuantity Quantity { get; set; }

        [Required] public SalesObjectTotal Total { get; set; }

        [Required] public SalesObjectType Type { get; set; }

        [Required] public Guid BranchId { get; set; }

        public SalesEntity(SalesObjectNumber number, SalesObjectQuantity quantity, SalesObjectTotal total, SalesObjectType type, Guid branchId)
        {
            SalesId = Guid.NewGuid();
            Number = number;
            Quantity = quantity;
            Total = total;
            Type = type;
            BranchId = branchId;
        }
    }
}
