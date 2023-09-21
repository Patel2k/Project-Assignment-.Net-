using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment
{
    class EnucAssignment
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Dictionary<string, int> sanath = new Dictionary<string, int>();
                Console.WriteLine("Enter the item(any name) to add (Or exit to quit)");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                {
                    return;
                }
                Console.WriteLine("Enter the value to it");
                int value = int.Parse(Console.ReadLine());
                sanath.Add(name, value);
                Console.WriteLine("The values are:");
                foreach (var item in sanath)
                {
                    //Console.WriteLine();
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }

            }
           
            

        }
    }
}
