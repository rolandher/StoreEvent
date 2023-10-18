using Domain.ObjectValues.ObjectValuesBranch;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Branch
{
    public class RegisterBranchCommand
    {
        [Required] public string Name { get; set; }

        [Required] public BranchObjectLocation Location { get; set; }


    }
}
