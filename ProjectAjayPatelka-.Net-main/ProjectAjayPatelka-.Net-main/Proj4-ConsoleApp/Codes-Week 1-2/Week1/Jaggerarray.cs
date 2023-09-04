using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp01LoanCalculator
{
    class Jaggerarray
    {
        static void Main(String[] args)
        {
            int[][] jagger = new int[4][];
            Console.WriteLine("Enter the school Capacity value");
            int size = int.Parse(Console.ReadLine());
            int[] a = new int[size];
            for(int i=0;i<4;i++)
            {
                a[i] = int.Parse(Console.ReadLine());
                //jagger[i] = a[i];
            }

            jagger[0] = new int[] { 1, 2, 3, 4 };
            jagger[1] = new int[] { 1, 2};
            jagger[2] = new int[] { 1, 2, 3 };
            jagger[3] = new int[] { 1};
            Console.WriteLine("Jagged Array Elements are :");
            for(int i=0;i<jagger.Length;i++)
            {
                Console.Write(" " +"Row");
                for(int j =0;j<jagger[i].Length;j++)
                {
                    Console.Write( " " +jagger[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
