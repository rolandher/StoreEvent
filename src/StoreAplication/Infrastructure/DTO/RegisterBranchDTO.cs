using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class RegisterBranchDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BranchId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Country { get; set; }

        [Required] public string City { get; set; }

        public virtual List<RegisterProductDTO> BranchUsers { get; set; }

        public virtual List<RegisterUserDTO> BranchProducts { get; set; }

        public RegisterBranchDTO(string name, string country, string city)
        {
            Name = name;
            Country = country;
            City = city;
        }
       
    }
}
