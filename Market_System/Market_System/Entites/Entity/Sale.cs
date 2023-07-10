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
            Id = counter;
            counter++;
        }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public List<SaleItem> SaleItem { get; set; }
    }
}
