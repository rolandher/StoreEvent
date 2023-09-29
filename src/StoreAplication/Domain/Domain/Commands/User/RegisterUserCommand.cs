using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Common.Enums;

namespace Domain.Commands.User
{
    public class RegisterUserCommand
    {
        [Required] public string UserName { get; set; }

        [Required] public int BranchId { get; set; }

        [Required] public string UserPassword { get; set; }

        [Required] public string UserEmail { get; set; }

        [Required] public CategoryEnum UserRole { get; set; }
    }
}
