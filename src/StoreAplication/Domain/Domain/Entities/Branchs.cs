using Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Branchs
    {
        public int BranchId { get; set; }

        [Required] public string BranchName { get; set; }

        [Required] public Location BranchLocation { get; set; }

        public virtual List<Users> BranchUsers { get; set; }

        public virtual List<Products> BranchProducts { get; set; }

        public Branchs(string branchName, Location branchLocation)
        {
            BranchName = branchName;
            BranchLocation = branchLocation;
        }

    }
}
