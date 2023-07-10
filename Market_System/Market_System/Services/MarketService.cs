using Market_System.Entites.Entity;
using Market_System.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Market_System.Services
{
    public class MarketService : IMarketable
    {
        public List<Product> Products = new();

        public List<Sale> Sales = new();

        public List<SaleItem> SalesItems = new();
        public MarketService()
        {
            Products = new();
            Sales = new();
            SalesItems = new();
        }
        public List<Product> ShowAllProducts()
        {
            return Products;
        }
        public int AddProduct()
        {
            return 1;
        }
        public void UpdateProduct(int id)
        {

        }
        public void DeleteProduct(int id)
        {

        }
        public void ShowProductByCategory(string category)
        {

        }
        public void ShowProductByPriceRange(decimal firstprice, decimal endprice)
        {

        }
        public void SearchProductsByName(string productname)
        {

        }
    }
}
