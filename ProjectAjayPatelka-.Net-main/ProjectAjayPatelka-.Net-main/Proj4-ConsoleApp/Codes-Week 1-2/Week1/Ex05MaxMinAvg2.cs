using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp01LoanCalculator
{
    class Ex05MaxMinAvg2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for(int i=0;i<n;i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            foreach(int a in arr)
            {
                Console.WriteLine(a);
            }

            int max = int.MinValue;
            int min = int.MaxValue;
            for(int i=0;i<n;i++)
            {
                if (arr[i] > arr[i + 1])
                    max = arr[i];

            }
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < arr[i + 1])
                    min = arr[i];

            }
            Console.WriteLine($"Minimum Value is {min} Maximum is {max}");
        }
    }
}
