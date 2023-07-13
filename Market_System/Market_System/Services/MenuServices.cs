using ConsoleTables;
using Market_System.Entites.Entity;
using Market_System.Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Market_System.Services
{
    public class MenuServices
    {
        private static MarketService marketService = new();

        #region Product

        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Write product's name");

                string name = Console.ReadLine();

                Console.WriteLine("Write product's price");

                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's category");

                Console.WriteLine("----------------------");

                foreach (var item in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("----------------------");

                string category = Console.ReadLine();

                int productid = marketService.AddProduct(name, price, number, category);

                Console.WriteLine($"Added {name} with ID :{productid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuUptadeProduct()
        {
            try
            {
                Console.WriteLine("Write product's id");

                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's name");

                string name = Console.ReadLine();

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's price");

                decimal price = decimal.Parse(Console.ReadLine());

                marketService.UpdateProduct(name, number, price, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuRemoveProduct()
        {
            try
            {
                Console.WriteLine("Write product's ID");

                int id = int.Parse(Console.ReadLine());

                marketService.RemoveProduct(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowAllProducts()
        {
            try
            {
                var products = marketService.ShowAllProducts();

                var table = new ConsoleTable("Id", "Product's name",
                    "Product's price", "Product's category", "Product's number");

                if (products.Count == 0)
                {
                    Console.WriteLine("No product's yet");

                    return;
                }

                foreach (var item in products)
                {
                    table.AddRow(item.Id, item.ProductName,
                        item.Price, item.category, item.Number);
                }

                table.Write();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductByCategory()
        {
            try
            {
                Console.WriteLine("Write category");

                string category = Console.ReadLine();

                marketService.ShowProductByCategory(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductByPriceRange()
        {
            try
            {
                Console.WriteLine("Write start amount");

                decimal startAmount = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Write end amount");

                decimal endAmount = decimal.Parse(Console.ReadLine());

                marketService.ShowProductByPriceRange(startAmount, endAmount);
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuSearchProductsByName()
        {
            try
            {
                Console.WriteLine("Write product's name");

                string name = Console.ReadLine();

                marketService.SearchProductsByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Sale

        public static void MenuAddSale()
        {
            try
            {
                Console.WriteLine("Write Saleitem's count");

                int count = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's id");

                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                marketService.AddSale(id, count, number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuRemoveProductFromSale()
        {
            try
            {
                Console.WriteLine("Write product's name");

                string name = Console.ReadLine();

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                marketService.RemoveProductFromSale(number, name);
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuRemoveSale()
        {
            try
            {
                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                marketService.RemoveSale(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplayAllSales()
        {
            try
            {
                var sales = marketService.ShowAllSales();

                var table = new ConsoleTable("Id", "Sale's date", "Saleitem's id", "Saleitem's price", "Saleitem's name");

                if (sales.Count == 0)
                {
                    Console.WriteLine("No sale's yet");
                    return;
                }

                foreach (var sale in sales)
                {
                    foreach (var saleItem in MarketService.SalesItems)
                    {
                        table.AddRow(sale.Id, sale.Date, saleItem.Id, sale.Price, saleItem.Product.ProductName);
                    }
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesByDate()
        {
            try
            {
                Console.WriteLine("Write start date with, (MM/dd/yyyy) ");

                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                Console.WriteLine("Write end date wirh, (MM/dd/yyyy)");

                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                marketService.DisplaySalesByDate(startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesByPriceRange()
        {
            try
            {
                Console.WriteLine("Write start price");

                decimal startPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Write end price");

                decimal endPrice = decimal.Parse(Console.ReadLine());

                marketService.DisplaySalesByPriceRange(startPrice, endPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesOnTheGivenDate()
        {
            try
            {
                Console.WriteLine("Write date with, (MM/dd/yyyy)");

                DateTime date = DateTime.ParseExact(Console.ReadLine(),
                    "MM/dd/yyyy", CultureInfo.InvariantCulture);

                marketService.DisplaySalesOnTheGivenDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesOnTheGivenNumber()
        {
            try
            {
                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's name");

                string name = Console.ReadLine();

                marketService.DisplaySalesOnTheGivenNumber(number, name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
