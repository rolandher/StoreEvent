using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues.ObjectValuesUser
{
    public class UserObjectEmail
    {
        public string Email { get; set; }

        public UserObjectEmail(string email)
        {
            Email = email;
        }
    }
}
