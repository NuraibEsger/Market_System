using Market_System.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_System.Interface
{
    public interface IMarketable
    {
        public List<Product> ShowAllProducts();
        public int AddProduct(string name, decimal price, int number, string category);
        public void UpdateProduct(string name, int number, decimal price, int productId);
        public void RemoveProduct(int id);
        public void ShowProductByCategory(string category);
        public void ShowProductByPriceRange(decimal firstprice, decimal endprice);
        public void SearchProductsByName(string productname);

    }
}
