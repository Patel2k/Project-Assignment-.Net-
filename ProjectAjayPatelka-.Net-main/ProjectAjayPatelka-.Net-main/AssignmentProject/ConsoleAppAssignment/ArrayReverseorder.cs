using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment
{
    class ArrayReverseorder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of Array");
            int size = int.Parse(Console.ReadLine());
            int[] a = new int[size];
            for (int k = 0; k < size; k++)
            {
                Console.WriteLine($"Entert the item {k + 1}");
                a[k] = int.Parse(Console.ReadLine());
            }
            //Console.WriteLine();
            // DoarrayReverse(a);
            int i = 0;
            int j = size - 1;
            while(i < j)
            {
                swap(a[i], a[j]);
                i++;
                j--;
            }
            //reversearray(a);
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }

        }
        private static void swap(int v1, int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
            return;
        }
    }
}
