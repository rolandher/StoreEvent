using System.ComponentModel.DataAnnotations;

namespace Domain.Response.Sale
{
    public class SaleResponse
    {
        public Guid SalesId { get; set; }

        [Required] public int Number { get; set; }
        [Required] public string Type { get; set; }        
        [Required] public int Quantity { get; set; }
        [Required] public double Total { get; set; }
        [Required] public Guid BranchId { get; set; }
    }
}
