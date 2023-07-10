using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

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
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
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
                Console.Clear();

                Console.WriteLine("1. Add new sales");

                Console.WriteLine("2. Rremove product from sales");

                Console.WriteLine("3. Delete sales");

                Console.WriteLine("4. Display all sales");

                Console.WriteLine("5. Display sales by date");

                Console.WriteLine("6. Display sales by amount");

                Console.WriteLine("7. Display sales on the given date");

                Console.WriteLine("8. Display sales on the given number");

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
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
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
