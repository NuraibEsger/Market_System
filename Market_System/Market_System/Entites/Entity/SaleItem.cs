﻿using Market_System.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_System.Entites.Entity
{
    public class SaleItem : BaseEntity
    {
        private static int counter;
        public SaleItem()
        {
            //For increase the SaleItem's Id
            Id = counter;
            counter++;
        }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
    }
}
