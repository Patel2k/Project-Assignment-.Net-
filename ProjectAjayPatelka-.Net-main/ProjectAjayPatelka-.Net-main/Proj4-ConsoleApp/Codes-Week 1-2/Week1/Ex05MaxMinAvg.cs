using System;

namespace Exp01LoanCalculator
{
    class Ex05MaxMinAvg
    {
        static void Main(string[] args)
        {   // one method
            int[] a = new int[6] { 11, 22, 73, 4, 65, 6 };
            Array.Sort(a);
            int min = a[0];
            int max = a[a.Length - 1];
            Console.WriteLine($"Minimum Value is {min} Maximum is {max}");

        }
    }
}
