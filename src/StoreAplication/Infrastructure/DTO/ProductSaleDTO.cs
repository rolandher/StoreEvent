﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class ProductSaleDTO
    {
        [Required] public int ProductId { get; set; }

        [Required] public decimal ProductPrice { get; set; }

        [Required] public int ProductInventoryStock { get; set; }
               
    }
}
