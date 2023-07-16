using Market_System.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Market_System.Entites.Entity
{
    public class Sale : BaseEntity
    {
        private static int counter;
        public Sale()
        {
            //For increase the Sale's Id
            Id = counter;
            counter++;
        }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public List<SaleItem> SaleItem { get; set; }
    }
}
