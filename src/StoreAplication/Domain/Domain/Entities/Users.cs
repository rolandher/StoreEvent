using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ObjectValues;
using static Domain.Common.Enums;

namespace Domain.Entities
{
    public class Users
    {
        public int UserId { get; set; }

        [Required] public int BranchId { get; set; }

        [Required] public Name UserName { get; set; }

        [Required] public string UserPassword { get; set; }

        [Required] public string UserEmail { get; set; }

        [Required] public UserRoleEnum UserRole { get; set; }

        public virtual Branchs Branchs { get; set; }

        public Users( Name userName, int branchId, string userPassword, string userEmail, UserRoleEnum userRole)
        {
            UserName = userName;
            BranchId = branchId;
            UserPassword = userPassword;
            UserEmail = userEmail;
            UserRole = userRole;
        }
    }
}
