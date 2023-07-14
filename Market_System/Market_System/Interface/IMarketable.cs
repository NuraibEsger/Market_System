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
        #region Product

        public  List<Product> ShowAllProducts();
        public int AddProduct(string name, decimal price, int number, string category);
        public void UpdateProduct(int productId, string name, int number, decimal price);
        public void RemoveProduct(int id);
        public void ShowProductByCategory(string category);
        public void ShowProductByPriceRange(decimal firstprice, decimal endprice);
        public void SearchProductsByName(string productname);

        #endregion

        #region Sale

        public List<Sale> ShowAllSales();
        public int AddSale(int id, int quantity);
        public void RemoveSale(int saleid);
        public void DisplaySalesByDate(DateTime startdate, DateTime enddate);
        public void DisplaySalesByPriceRange(decimal startPrice, decimal endPrice);
        public void DisplaySalesOnTheGivenDate(DateTime date);
        public void DisplaySalesOnTheGivenNumber(int id);

        #endregion


    }
}
