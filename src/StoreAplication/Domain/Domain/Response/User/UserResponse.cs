using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response.User
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Password { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Role { get; set; }

        [Required] public Guid BranchId { get; set; }
    }
}
