﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Product
{
    public class RegisterProductInventoryCommand
    {
        public int Id { get; set; }
        public int InventoryStock { get; set; }
        
    }
}
