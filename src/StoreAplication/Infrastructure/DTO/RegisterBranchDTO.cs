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
        public int Id { get; set; }

        [Required] public string BranchName { get; set; }

        [Required] public string BranchCountry { get; set; }

        [Required] public string BranchCity { get; set; }

        public virtual List<RegisterProductDTO> BranchUsers { get; set; }

        public virtual List<RegisterUserDTO> BranchProducts { get; set; }

        public RegisterBranchDTO(string branchName, string branchCountry, string branchCity)
        {
            BranchName = branchName;
            BranchCountry = branchCountry;
            BranchCity = branchCity;
        }

        public RegisterBranchDTO()
        {
        }
    }
}
