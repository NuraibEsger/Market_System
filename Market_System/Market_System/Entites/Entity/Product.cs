using Market_System.Entites.Base;
using Market_System.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_System.Entites.Entity
{
    public class Product : BaseEntity
    {
        private static int counter;
        public Product()
        {
            //For increase the Product's Id
            Id = counter;
            counter++;
        }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public Category Category { get; set; }
    }
}
