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
using System.Security.Cryptography.X509Certificates;
using System.Collections.Immutable;
using System.Collections;
using System.Transactions;

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
        public void AddProduct(string Name, decimal Price, int Number, string Category)
        {
            var res = Products.Find(x => x.ProductName == Name && x.Price == Price);

            if (res == null)
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
                    Category = (Category)parsedCategory,
                };

                if (newProduct.Number < 0)
                {
                    throw new Exception("empty");
                }

                Products.Add(newProduct);

                Console.WriteLine(newProduct.Id);
            }
            else
            {
                res.Number += Number;
            }

        }
        public void UpdateProduct(int productId, string name, int number, decimal price, string category)
        {
            var res = Products.FirstOrDefault(x => x.Id == productId);

            if (name is null)
            {
                Console.WriteLine("Product's name is null");
            }

            if (price <= 0)
            {
                Console.WriteLine("Price is equal or less than 0");
            }

            if (number <= 0)
            {
                Console.WriteLine("Number is equal or less than 0");
            }

            if (res == null)
            {
                Console.WriteLine($"Product with ID: {productId} not found");
            }

            bool isSuccessful = Enum.TryParse(typeof(Category), category, true, out object parsedCategory);

            if (isSuccessful != true)
            {
                throw new FormatException("Category not found");
            }

            res.Category = (Category)parsedCategory;

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
                var search = Products.Where(x => x.Category.ToString().ToLower() == category.ToLower());

                list.AddRange(search);

                var res = list.GroupBy(x => x.ProductName).Select(x => x.First()).ToList();
            }
            if (list.Count == 0)
            {
                Console.WriteLine("Not find");
                return;
            }
            var newRes = list.GroupBy(x => x.ProductName).Select(x => x.First()).ToList();

            var table = new ConsoleTable("Id", "Product's name",
                    "Product's price", "Product's category", "Product's number");

            foreach (var item in newRes)
            {
                table.AddRow(item.Id, item.ProductName, item.Price, item.Category, item.Number);
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
                    table.AddRow(item.Id, item.ProductName, item.Price, item.Category, item.Number);
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

            table.AddRow(search.Id, search.ProductName, search.Price, search.Category, search.Number);

            table.Write();

        }

        #endregion

        #region Sale

        public List<Sale> ShowAllSales()
        {
            return Sales;
        }
        public int AddSale(int num)
        {
            SalesItems = new();

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter product's id");

                int id = int.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Enter saleitem's number");

                int quantity = int.Parse(Console.ReadLine().Trim());

                if (id < 0)
                {
                    Console.WriteLine("Product's id is less than 0");
                }

                var search = Products.FirstOrDefault(x => x.Id == id);

                if (search == null)
                {
                    Console.WriteLine("There is no product");
                }

                if (quantity > search.Number)
                {
                    throw new Exception("Stock is less than 0");
                }

                var newSaleItem = new SaleItem
                {
                    Number = quantity,

                    Price = search.Price * quantity,

                    Product = search
                };

                newSaleItem.Product.Number -= quantity;

                if (search.Number <= 0)
                {
                    Console.WriteLine("Wrong!");
                }

                SalesItems.Add(newSaleItem);
            }

            decimal sum = SalesItems.Sum(x => x.Number * x.Product.Price);

            var newSale = new Sale
            {
                Price = sum,

                SaleItem = SalesItems,

                Date = DateTime.Now
            };

            Sales.Add(newSale);

            return newSale.Id;
        }
        public void RemoveProductFromSale(int id, int _id, int quantity)
        {
            var searchSale = Sales.FirstOrDefault(x => x.Id == id);

            if (searchSale == null)
            {
                throw new Exception("Sale not found");
            }

            var saleItem = searchSale.SaleItem.FirstOrDefault(item => item.Id == _id);

            if (saleItem == null)
            {
                throw new Exception("Sale item not found");
            }

            var product = saleItem.Product;

            if (quantity > saleItem.Number)
            {
                throw new Exception("Quantity to remove exceeds the available quantity");
            }

            product.Number += quantity;

            saleItem.Price -= quantity * saleItem.Product.Price;

            saleItem.Number -= quantity;

            if (saleItem.Number == 0)
            {
                searchSale.SaleItem.Remove(saleItem);
            }
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
                    foreach (var items in item.SaleItem)
                    {
                        table.AddRow(item.Id, item.Price, item.Date, items.Product.ProductName, items.Price, items.Id, items.Number);
                    }
                }

                table.Write();
            }
            else
            {
                throw new Exception("No sales found between the specified dates.");
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

            if (result == null)
            {
                throw new Exception("Sale not find");
            }

            var table = new ConsoleTable("Id", "Price", "Date");

            foreach (var item in result)
            {
                foreach (var items in item.SaleItem)
                {
                    table.AddRow(item.Id, item.Price, item.Date, items.Product.ProductName, items.Price, items.Id, items.Number);
                }
            }

            table.Write();
        }
        public void DisplaySalesOnTheGivenNumber(int id)
        {
            var result = Sales.FindAll(x => x.Id == id).ToList();

            var table = new ConsoleTable("Sale's id", "Sale' price", "Sale' date", "Prdouct's name", "Saleitem's price", "Saleitem's id", "Saleitem's number");

            if (result == null)
            {
                throw new Exception("Sale item not found");
            }

            foreach (var item in result)
            {
                foreach (var items in item.SaleItem)
                {
                    table.AddRow(item.Id, item.Price, item.Date, items.Product.ProductName, items.Price, items.Id, items.Number);
                }
            }

            table.Write();
        }

        #endregion
    }
}
