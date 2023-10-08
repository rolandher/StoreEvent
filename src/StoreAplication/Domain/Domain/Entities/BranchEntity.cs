using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesBranch;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BranchEntity
    {
        public Guid BranchId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public BranchObjectName Name { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public BranchObjectLocation Location { get; set; }      

        public BranchEntity(BranchObjectName name, BranchObjectLocation location)
        {
            BranchId = Guid.NewGuid();
            Name = name;
            Location = location;
        }

        public BranchEntity()
        {
        }
    }
}
