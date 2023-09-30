﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class RegisterProductInventoryStockDTO
    {
        [Required] public int Id { get; set; }

        [Required] public int InventoryStock { get; set; }
               
    }
}
