using System.ComponentModel.DataAnnotations;

namespace Domain.Response.Product
{
    public class ProductQueryResponse
    {
        public Guid ProductId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public double Price { get; set; }
        [Required] public int InventoryStock { get; set; }
        [Required] public string Category { get; set; }
        [Required] public Guid BranchId { get; set; }
    }
}
