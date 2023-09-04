using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj02ConAPP
{
    class mathcheck
    {
        public void alloperation(double fvalue , double svalue,ref double squr1)
        {
            squr1 = Math.Pow(fvalue, svalue);
        }
    }
    class exp_05square
    {
        static void Main(string[] args)
        {
            mathcheck mt = new mathcheck();
            double sqr=1;
            Console.WriteLine("Enter the value of fvalue in double");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value of fvalue in double");
            double b = double.Parse(Console.ReadLine());
            mt.alloperation(a, b, ref sqr);
            Console.WriteLine(sqr);
            //ref 
        }
    }
}
