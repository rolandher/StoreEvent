using Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Branchs
    {
        public int BranchId { get; set; }

        public string BranchName { get; set; }

        public Location BranchLocation { get; set; }

    }
}
