﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Common.Enums;

namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public int BranchId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductStock { get; set; }

        public CategoryEnum ProductCategory { get; set; }
    }
}
