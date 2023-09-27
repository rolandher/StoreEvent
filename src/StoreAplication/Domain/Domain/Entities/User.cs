﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ObjectValues;
using static Domain.Common.Enums;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public int BranchId { get; set; }

        public Name UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public UserRoleEnum UserRole { get; set; }

    }
}
