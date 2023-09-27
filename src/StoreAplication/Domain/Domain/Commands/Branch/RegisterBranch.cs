using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Branch
{
    public class RegisterBranch
    {
        public string BranchId { get; set; }

        public string BranchName { get; set; }

        public string BranchCountry { get; set; }

        public string BranchCity { get; set; }
    }
}
