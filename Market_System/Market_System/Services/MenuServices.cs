﻿using ConsoleTables;
using Market_System.Entites.Entity;
using Market_System.Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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

                string name = Console.ReadLine().Trim();

                bool regex = Regex.IsMatch(name, @"^[a-zA-Z]+$");

                if (regex != true)
                {
                    throw new Exception("Enter only letter!");
                }

                Console.WriteLine("Write product's price");

                decimal price = decimal.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write product's category");

                var table = new ConsoleTable("----------");

                foreach (var item in Enum.GetValues(typeof(Category)))
                {
                    table.AddRow(item);
                }
                table.Write();

                string category = Console.ReadLine().Trim();

                bool regex1 = Regex.IsMatch(category, @"^[a-zA-Z]+$");

                if (regex1 != true)
                {
                    throw new Exception("Enter only letter!");
                }

                marketService.AddProduct(name, price, number, category);

                foreach (var item in MarketService.Products)
                {
                    Console.WriteLine($"Added {name} with ID :{item.Id}");
                }
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

                int id = int.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write product's name");

                string name = Console.ReadLine().Trim();

                bool regex = Regex.IsMatch(name, @"^[a-zA-Z]+$");

                if (regex != true)
                {
                    throw new Exception("Enter only letter!");
                }

                var table = new ConsoleTable("----------");

                foreach (var item in Enum.GetValues(typeof(Category)))
                {
                    table.AddRow(item);
                }
                table.Write();

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write product's price");

                decimal price = decimal.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write product's category");

                string category = Console.ReadLine();

                bool regex1 = Regex.IsMatch(category, @"^[a-zA-Z]+$");

                if (regex1 != true)
                {
                    throw new Exception("Enter only letter!");
                }

                marketService.UpdateProduct(id, name, number, price, category);
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
                        item.Price, item.Category, item.Number);
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

                string category = Console.ReadLine().Trim();

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

                decimal startAmount = decimal.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write end amount");

                decimal endAmount = decimal.Parse(Console.ReadLine().Trim());

                marketService.ShowProductByPriceRange(startAmount, endAmount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuSearchProductsByName()
        {
            try
            {
                Console.WriteLine("Write product's name");

                string name = Console.ReadLine().Trim();

                bool regex = Regex.IsMatch(name, @"^[a-zA-Z]+$");

                if (regex != true)
                {
                    throw new Exception("Enter only letter!");
                }

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
                Console.WriteLine("Write product's id");

                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine());

                marketService.AddSale(id, number);
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
                Console.WriteLine("Write product's id");

                var table = new ConsoleTable("Id", "Product's name");

                var products = marketService.ShowAllProducts();

                foreach (var item in products)
                {
                    table.AddRow(item.Id, item.ProductName);
                }

                int id = int.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write product's number");

                int number = int.Parse(Console.ReadLine().Trim());

                marketService.RemoveProductFromSale(id, number);
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
                Console.WriteLine("Write sale's number");

                int number = int.Parse(Console.ReadLine().Trim());

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


                if (sales.Count == 0)
                {
                    Console.WriteLine("No sale's yet");

                    return;
                }

                var res = sales.GroupBy(x => x.Id).Select(y => y.First()).ToList();

                var table = new ConsoleTable("Sale's date", "Saleitem's id", "Saleitem's price", "Saleitem's name", "Product's stock");

                foreach (var item in sales)
                {
                    foreach (var saleItem in MarketService.SalesItems)
                    {
                        if (item.Id == saleItem.Id)
                        {
                            table.AddRow(item.Date, saleItem.Id, item.Price,
                                saleItem.Product.ProductName, saleItem.Product.Number);
                        }
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
                Console.WriteLine("Write start date with, (MM/dd/yyyy HH:mm:ss) ");

                DateTime startDate = DateTime.ParseExact(Console.ReadLine().Trim(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                Console.WriteLine("Write end date wirh, (MM/dd/yyyy HH:mm:ss)");

                DateTime endDate = DateTime.ParseExact(Console.ReadLine().Trim(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

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

                decimal startPrice = decimal.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Write end price");

                decimal endPrice = decimal.Parse(Console.ReadLine().Trim());

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
                Console.WriteLine("Write date with, (MM/dd/yyyy HH:mm:ss)");

                DateTime date = DateTime.ParseExact(Console.ReadLine().Trim(),
                    "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

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

                int number = int.Parse(Console.ReadLine().Trim());

                marketService.DisplaySalesOnTheGivenNumber(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
