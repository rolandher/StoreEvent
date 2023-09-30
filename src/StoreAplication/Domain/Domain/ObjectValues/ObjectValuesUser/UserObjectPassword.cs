using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues.ObjectValuesUser
{
    public class UserObjectPassword
    {
        public string Password { get; set; }

        public UserObjectPassword(string Password)
        {
            Password = Password;
        }
    }
}
