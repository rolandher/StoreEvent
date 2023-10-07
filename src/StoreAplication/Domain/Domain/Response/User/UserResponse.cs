﻿using System.ComponentModel.DataAnnotations;

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
