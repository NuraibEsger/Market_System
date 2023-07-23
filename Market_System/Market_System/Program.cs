using Market_System.Entites.Enums;
using Market_System.Services;
using Market_System.SubMenu;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Market_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int option;
            Color c1 = Color.FromArgb(32, 178, 170);
            do
            {
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
                        Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}