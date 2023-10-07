using Domain.ObjectValues;
using System.ComponentModel.DataAnnotations;

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
