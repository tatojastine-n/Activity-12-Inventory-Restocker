using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Restocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> productNames = new List<string>();
            List<int> stockCounts = new List<int>();
            List<bool> wasRestocked = new List<bool>();

            Console.WriteLine("Enter 10 products and their stock counts:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Product {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Stock count: ");
                if (int.TryParse(Console.ReadLine(), out int stock) && stock >= 0)
                {
                    productNames.Add(name);
                    stockCounts.Add(stock);
                }
                else
                {
                    Console.WriteLine("Invalid stock count. Please enter a non-negative integer.");
                    i--; 
                }
            }

            for (int i = 0; i < stockCounts.Count; i++)
            {
                if (stockCounts[i] < 10)
                {
                    stockCounts[i] += 20;
                    wasRestocked.Add(true);
                }
                else
                {
                    wasRestocked.Add(false);
                }
            }

            Console.WriteLine("\nStock Inventory Report:");
            Console.WriteLine("| Product      | Stock | Restocked |");

            for (int i = 0; i < productNames.Count; i++)
            {
                Console.WriteLine($"| {productNames[i],-12} | {stockCounts[i],5} | {(wasRestocked[i] ? "Yes" : "No"),-9} |");
            }

            Console.WriteLine("\nRestocked Items:");
            bool anyRestocked = false;
            for (int i = 0; i < productNames.Count; i++)
            {
                if (wasRestocked[i])
                {
                    Console.WriteLine($"{productNames[i]} (New stock: {stockCounts[i]})");
                    anyRestocked = true;
                }
            }
            if (!anyRestocked)
            {
                Console.WriteLine("No items needed restocking.");
            }

        }
    }
}
