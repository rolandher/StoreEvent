using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User
{
    public class RegisterUser
    {
        public string UserName { get; set; }

        public string LastName { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public string UserRole { get; set; }
    }
}
