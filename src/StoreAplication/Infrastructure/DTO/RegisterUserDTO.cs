using Domain.Entities;
using Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ObjectValues.ObjectValuesUser;

namespace Infrastructure.DTO
{
    public class RegisterUserDTO
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] public string Name { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Role { get; set; }

        [Required] public string BranchId { get; set; }

        [Required]
        [ForeignKey("BranchId")]
        public virtual RegisterBranchDTO Branch { get; set; }

        
        public RegisterUserDTO(string name, string lastname, string password, string email, string role, string branchId)
        {
            Name = name;     
            LastName = lastname;
            Password = password;
            Email = email;
            Role = role;
            BranchId = branchId;
        }

        public RegisterUserDTO()
        {
        }
    }
}
