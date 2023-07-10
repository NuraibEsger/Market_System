using ConsoleTables;
using Market_System.Entites.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

                int price = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's category");

                string category = Console.ReadLine();

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                //MarketService.Add();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuUptadeProduct()
        {
            try
            {
                Console.WriteLine("Write product's id");

                //MarketService.Uptade();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuRemoveProduct()
        {
            try
            {
                Console.WriteLine("Write product's ID");

                //MarketService.Remove();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

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

                if (products.Count == default)
                {
                    Console.WriteLine("No product's yet");

                    return;
                }

                foreach (var item in products)
                {
                    table.AddRow(item.ID, item.ProductName,
                        item.Price, item.Category, item.Number);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductByCategory()
        {
            try
            {
                Console.WriteLine("Write category");

                string category = Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

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

                //MarketService.ShowProductByAmount
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

            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Sale

        public static void MenuAddSale()
        {
            try
            {
                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                //marketService.AddSale
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

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

                //marketService.RemoveProductFromSales();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuRemoveSale()
        {
            try
            {
                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                //
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplayAllSales()
        {
            try
            {
                //marketService.DisplayAllSales();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesByDate()
        {
            try
            {
                Console.WriteLine("Write start date");

                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                Console.WriteLine("Write end date");

                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                //marketService.DisplaySalesbyDate();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

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

                //marketService.DisplaySalesByPriceRange();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesOnTheGivenDate()
        {
            try
            {
                Console.WriteLine("Write date");

                DateTime date = DateTime.ParseExact(Console.ReadLine(), 
                    "MM/dd/yyyy", CultureInfo.InvariantCulture);

                //marketService.DisplaySalesOnTheGivenDate();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesOnTheGivenNumber()
        {
            try
            {
                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                //marketService.DisplaySalesOnTheGivenNumber();
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
