using Market_System.Entites.Entity;
using Market_System.Entites.Enums;
using Market_System.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ConsoleTables;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace Market_System.Services
{
    public class MarketService : IMarketable
    {
        public static List<Product> Products;

        public static List<Sale> Sales;

        public static List<SaleItem> SalesItems;
        public MarketService()
        {
            Products = new();
            Sales = new();
            SalesItems = new();
        }

        #region Product

        public List<Product> ShowAllProducts()
        {
            return Products;
        }
        public int AddProduct(string Name, decimal Price, int Number, string Category)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new FormatException("product's name is empty!");
            }
            if (Price < 0)
            {
                throw new FormatException("Price is less than zero");
            }
            if (Number <= 0)
            {
                throw new FormatException("Number is equal or lower than 0");
            }
            if (string.IsNullOrWhiteSpace(Category))
            {
                throw new FormatException("Category is empty!");
            }

            bool isSuccessful = Enum.TryParse(typeof(Category), Category, true, out object parsedCategory);

            if (!isSuccessful)
            {
                throw new FormatException("Category not found");
            }

            var newProduct = new Product
            {
                ProductName = Name,
                Price = Price,
                Number = Number,
                category = (Category)parsedCategory,
            };

            Products.Add(newProduct);

            return newProduct.Id;
        }
        public void UpdateProduct(string name, int number, decimal price, int productId)
        { 
            var res = Products.FirstOrDefault(x => x.Id == productId);

            if (res == null)
            {
                Console.WriteLine($"Product with ID: {productId} not found");
            }

            res.ProductName = name;

            res.Number = number;

            res.Price = price;
        }
        public void RemoveProduct(int productId)
        {
            var existingProduct = Products.FirstOrDefault(x => x.Id == productId);

            if (existingProduct is null)
            {
                throw new Exception($"Product with ID: {productId} not found");
            }
            Products = Products.Where(x => x.Id != productId).ToList();
        }
        public void ShowProductByCategory(string category)
        {
            var list = new List<Product>();

            foreach (var item in Enum.GetValues(typeof(Category)))
            {
                var search = Products.Where(x => x.category.ToString().ToLower() == category.ToLower());

                list.AddRange(search);

                var res = list.GroupBy(x => x.ProductName).Select(x => x.First()).ToList();
            }
            if (list.Count == 0)
            {
                Console.WriteLine("Didn't find");
            }
            var newRes = list.GroupBy(x => x.ProductName).Select(x => x.First()).ToList();

            var table = new ConsoleTable("Id", "Product's name",
                    "Product's price", "Product's category", "Product's number");

            foreach (var item in newRes)
            {
                    table.AddRow(item.Id, item.ProductName, item.Price, item.category, item.Number);
            }

            table.Write();
        }
        public void ShowProductByPriceRange(decimal startprice, decimal endprice)
        {
            var result = Products.Where(x => x.Price >= startprice && x.Price <= endprice).ToList();

            if (result.Count > 0)
            {
                var table = new ConsoleTable("Id", "Product's name",
                    "Product's price", "Product's category", "Product's number");

                foreach (var item in result)
                {
                    table.AddRow(item.Id, item.ProductName, item.Price, item.category, item.Number);
                }

                table.Write();
            }
            else
            {
                throw new Exception("Product is not found");
            }
        }
        public void SearchProductsByName(string productname)
        {
            var search = Products.Find(x => x.ProductName.ToLower().Trim() == productname.ToLower().Trim());

            if (search == null)
            {
                throw new Exception("Product is not found");
            }
            var table = new ConsoleTable("Id", "Product's name",
                    "Product's price", "Product's category", "Product's number");

            table.AddRow(search.Id, search.ProductName, search.Price, search.category, search.Number);

            table.Write();

        }

        #endregion

        #region Sale

        public List<Sale> ShowAllSales()
        {
            return Sales;
        }
        public int AddSale(int id, int quantity)
        {
            if (id < 0)
            {
                Console.WriteLine("Product's id is less than 0");
            }

            var search = Products.FirstOrDefault(x => x.Id == id);

            if (search == null)
            {
                Console.WriteLine("There is no product");
            }

            var newSaleItem = new SaleItem
            {
                Number = quantity,

                Product = search,
            };

            var newSale = new Sale
            {
                Price = quantity * newSaleItem.Number,

                SaleItem = new(),

                Date = DateTime.Now.Date
            };

            SalesItems.Add(newSaleItem);

            Sales.Add(newSale);

            return newSaleItem.Id;
        }
        public void RemoveProductFromSale(int productId, string name)
        {
            SaleItem saleItem = SalesItems.FirstOrDefault(item => item.Product.Id == productId);
            if (saleItem != null)
            {
                SalesItems.Remove(saleItem);

                saleItem.Product.ProductName = SalesItems.Sum(item => item.Product.Price * item.Number).ToString();
            }
            else
            {
                Console.WriteLine("Product not found in the sale.");
            }

            SalesItems = SalesItems.Where(x => x.Id != productId).ToList();
        }
        public void RemoveSale(int saleid)
        {
            var existingSale = Sales.FirstOrDefault(x => x.Id == saleid);

            if (existingSale is null)
            {
                throw new Exception($"Sale with ID: {saleid} not found");
            }

            Sales = Sales.Where(x => x.Id != saleid).ToList();
        }
        public void DisplaySalesByDate(DateTime startdate, DateTime enddate)
        {
            var result = Sales.FindAll(x => x.Date >= startdate && x.Date <= enddate).ToList();

            if (result.Count > 0)
            {
                var table = new ConsoleTable("Id", "Sale's price",
                     "Sale's date");

                foreach (var item in result)
                {
                    table.AddRow(item.Id, item.Price, item.Date);
                }

                table.Write();
            }
            else
            {
                throw new Exception("Sale is not found");
            }
        }
        public void DisplaySalesByPriceRange(decimal startPrice, decimal endPrice)
        {
            var result = Sales.FindAll(x => x.Price >= startPrice && x.Price <= endPrice).ToList();


            if (result.Count > 0)
            {
                var table = new ConsoleTable("Id", "Sale's price",
                     "Sale's date");

                foreach (var item in result)
                {
                    table.AddRow(item.Id, item.Price, item.Date);
                }

                table.Write();
            }
            else
            {
                throw new Exception("Sale is not found");
            }
        }
        public void DisplaySalesOnTheGivenDate(DateTime date)
        {
            var result = Sales.FindAll(x => x.Date == date);

            foreach (var item in result)
            {
                var table = new ConsoleTable("Id", "Price", "Date");

                table.AddRow(item.Id, item.Price, item.Date);

                table.Write();
            }

            if (result == null)
            {
                throw new Exception("Sale didn't find");
            }
        }
        public void DisplaySalesOnTheGivenNumber(int id, string name)
        {
            var result = Sales.FindAll(x => x.Id == id).ToList();

            var table = new ConsoleTable("Id", "Price", "Date", "Name");

            foreach (var item in result)
            {
                foreach (var items in SalesItems)
                {
                    table.AddRow(item.Id, item.Price, item.Date, items.Product.ProductName);
                }
            }

            table.Write();

            if (result == null)
            {
                throw new Exception("Sale didn't find");
            }
        }

        #endregion
    }
}
