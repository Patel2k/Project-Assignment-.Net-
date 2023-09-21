using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment
{
    class Assig1_24th
    {
        static void Main(string[] args)
        {
            //Array Program;
            Console.WriteLine("Enter the no of employee need to add");
            int i = int.Parse(Console.ReadLine());


            string[] a = new string[i];
            for (int j = 0; j < i; j++)
            {
                a[j] = Console.ReadLine();
            }
            foreach(string item in a)
            {
                Console.WriteLine($"[ {item} ]");
            }
        }
    }
}
