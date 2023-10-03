using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesUser;
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
        [Required] public UserObjectName Name { get; set; }
          
        [Required] public string Password { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Role { get; set; }

        [Required] public Guid BranchId { get; set; }
    }
}
