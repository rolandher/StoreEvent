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

namespace Infrastructure.DTO
{
    public class RegisterUserDTO
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required] public int BranchId { get; set; }

        [Required] public string UserName { get; set; }

        [Required] public string UserPassword { get; set; }

        [Required] public string UserEmail { get; set; }

        [Required] public string UserRole { get; set; }       

        [Required]
        [ForeignKey("BranchId")]
        public virtual RegisterBranchDTO Branch { get; set; }

        public RegisterUserDTO(string name,int branchId, string userPassword, string email, string role)
        {
            Name = name;
            BranchId = BranchId;
            UserPassword = userPassword;
            Email = email;
            Role = role;
        }
        }
    }
}
