using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp01LoanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //loandetails();
            Console.WriteLine("Welcome to Bank of India");
            Console.WriteLine("Enter Your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter amount for loan amount required");
            float principleamount = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Rate of Interest");
            float interest = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the time requried int years");
            int time = int.Parse(Console.ReadLine());
            float si = ((principleamount * interest * time) / 100);
            Console.WriteLine($"Simple intrest amount of {name} with duration of{time} with intrest of {interest} is : {si}");
            Console.WriteLine("Emi would be");
             double check =  Math.Pow(1 + time, interest);
             double emi = (principleamount * time * check) / (check - 1);
            Console.WriteLine(emi);

        }
    }
}
