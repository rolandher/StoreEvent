using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response.Branch
{
    public class BranchResponse
    {
        public Guid BranchId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Location { get; set; }
    }
}
