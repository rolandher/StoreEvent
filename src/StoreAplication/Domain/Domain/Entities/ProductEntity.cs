using Domain.ObjectValues.ObjectValuesProduct;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProductEntity
    {
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public ProductObjectName Name { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 256 caracteres.")]
        public ProductObjectDescription Description { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 1.")]
        public ProductObjectPrice Price { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "El inventario debe ser mayor o igual a 1.")]
        public ProductObjectInventoryStock InventoryStock { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public ProductObjectCategory Category { get; set; }

        [Required] public Guid BranchId { get; set; }

        public ProductEntity(ProductObjectName name, ProductObjectDescription description, ProductObjectPrice price, ProductObjectInventoryStock productObjectInventoryStock, ProductObjectCategory category, Guid branchId)
        {
            ProductId = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            InventoryStock = productObjectInventoryStock;
            Category = category;
            BranchId = branchId;
        }


    }
}
