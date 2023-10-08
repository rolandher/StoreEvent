using Domain.Response.Product;
using Domain.Response.Sale;
using Domain.Response.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response.Branch
{
    public class BranchQueryResponse
    {
        public Guid BranchId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Country { get; set; }
        [Required] public string City { get; set; }

        public virtual List<ProductResponse> Products { get; set; }

        public virtual List<UserResponse> Users { get; set; }

        public virtual List<SaleResponse> Sales { get; set; }
    }
}
