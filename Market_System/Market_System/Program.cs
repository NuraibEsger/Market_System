using Market_System.Entites.Enums;
using Market_System.Services;
using Market_System.SubMenu;

namespace Market_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            int option;

            do
            {
                Console.Clear();

                Console.WriteLine("1. Operate on Product");

                Console.WriteLine("2. Operate on Sales");

                Console.WriteLine("0. Exit");

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
                        SubMenuHelper.ProductSubMenu();
                        break;

                    case 2:
                        SubMenuHelper.SaleSubMenu();
                        break;

                    case 0:
                        Console.WriteLine("Bye!");
                        break;

                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}