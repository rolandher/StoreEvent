using Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Branch
{
    public class RegisterBranchCommand
    {
        [Required] public string Name { get; set; }

        [Required] public BranchObjectLocation Location { get; set; }

       
    }
}
