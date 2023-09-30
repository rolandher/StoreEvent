using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesUser;
using static Domain.Common.Enums;

namespace Domain.Entities
{
    public class UserEntity

    {
        public Guid UserId { get; set; }        

        [Required] public UserObjectName Name { get; set; }

        [Required] public UserObjectPassword Password { get; set; }

        [Required] public UserObjectEmail Email { get; set; }

        [Required] public UserObjectRole Role { get; set; }

        [Required] public string BranchId { get; set; }

        public virtual BranchEntity BranchEntity { get; set; }

        public UserEntity(UserObjectName name, UserObjectPassword password, UserObjectEmail email, UserObjectRole role, string branchId)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = role;
            BranchId = branchId;
        }

       


       
    }
}
