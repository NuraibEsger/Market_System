using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Market_System.Services;

namespace Market_System.SubMenu
{
    public class SubMenuHelper
    {
        public static void ProductSubMenu()
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Add new product");

                Console.WriteLine("2. Uptade product");

                Console.WriteLine("3. Delete product");

                Console.WriteLine("4. Display all products");

                Console.WriteLine("5. Display products by category");

                Console.WriteLine("6. Display products by price range");

                Console.WriteLine("7. Search products by name");

                Console.WriteLine("0. Go back");

                Console.WriteLine("-----------");

                Console.WriteLine("Enter option:");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid number!");

                    Console.WriteLine("-----------");

                    Console.WriteLine("Enter option:");
                }

                switch (option)
                {
                    case 1:
                        MenuServices.MenuAddProduct();
                        break;

                    case 2:
                        MenuServices.MenuUptadeProduct();
                        break;

                    case 3:
                        MenuServices.MenuRemoveProduct();
                        break;

                    case 4:
                        MenuServices.MenuShowAllProducts();
                        break;

                    case 5:
                        MenuServices.MenuShowProductByCategory();
                        break;

                    case 6:
                        MenuServices.MenuShowProductByPriceRange();
                        break;

                    case 7:
                        MenuServices.MenuSearchProductsByName();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option != 0);
        }
        public static void SaleSubMenu()
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Add new sales");

                Console.WriteLine("2. Rremove product from sales");

                Console.WriteLine("3. Delete sales");

                Console.WriteLine("4. Display all sales");

                Console.WriteLine("5. Display sales by date");

                Console.WriteLine("6. Display sales by price range");

                Console.WriteLine("7. Display sales on the given date");

                Console.WriteLine("8. Display sales on the given number");

                Console.WriteLine("0. Go back");

                Console.WriteLine("-----------");

                Console.WriteLine("Enter option:");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid number!");

                    Console.WriteLine("-----------");

                    Console.WriteLine("Enter option:");
                }

                switch (option)
                {
                    case 1:
                        MenuServices.MenuAddSale();
                        break;

                    case 2:
                        MenuServices.MenuRemoveProductFromSale();
                        break;

                    case 3:
                        MenuServices.MenuRemoveSale();
                        break;

                    case 4:
                        MenuServices.MenuDisplayAllSales();
                        break;

                    case 5:
                        MenuServices.MenuDisplaySalesByDate();
                        break;

                    case 6:
                        MenuServices.MenuDisplaySalesByPriceRange();
                        break;

                    case 7:
                        MenuServices.MenuDisplaySalesOnTheGivenDate();
                        break;

                    case 8:
                        MenuServices.MenuDisplaySalesOnTheGivenNumber();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}
