using System.ComponentModel.DataAnnotations;

namespace Domain.Response.Branch
{
    public class BranchResponse
    {
        public Guid BranchId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Location { get; set; }
    }
}
