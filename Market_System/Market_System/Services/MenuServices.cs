using ConsoleTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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
        public static void MenuShowAllProduct()
        {
            try
            {
                var table = new ConsoleTable("Id", "Product's name", "Product's price", 
                    "Product's category", "Product's number");

                //MarketService.ShowAllProduct
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductByDate()
        {
            try
            {
                Console.WriteLine("Write startdate");

                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                Console.WriteLine("Write enddate");

                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                //MarketService.ShowProductByDate
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductByAmount()
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
        public static void MenuDisplaySalesOnTheGivenDate()
        {
            try
            {
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                //MarketService.DisplaySalesOnTheGivenDate
            }
            catch (Exception ex)
            {
                throw new Exception("Got a error. Let's try again.");

                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDisplaySalesOnTheGivenNumber()
        {
            Console.WriteLine("Write product ID");

            int number = int.Parse(Console.ReadLine());

            //MarketService.DisplaySalesOnTheGivenNumber
        }

        #endregion

        #region Sale



        #endregion
    }
}
