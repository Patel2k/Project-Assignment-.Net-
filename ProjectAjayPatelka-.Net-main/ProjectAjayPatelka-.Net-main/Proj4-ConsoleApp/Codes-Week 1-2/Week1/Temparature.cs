using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp01LoanCalculator
{
    class Temparature
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Temperature check");
            Console.WriteLine("Enter temperature in celsius or Fahreheit");
            double temp = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter choice C or F");
            string s = Console.ReadLine();
            double value;
            switch(s)
            {
                case "C": value = ((temp - 32) * 5) / 9; Console.WriteLine("Celsius Value is" + value); break;


                case "F":
                    value = (9*temp + (32*5))/5; Console.WriteLine("Fahreheit Value is" + value); break;

                default: Console.WriteLine("Invalid Choice");break;
            }
        }

    }
}
