using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj02ConAPP
{
    class Mathcomponet {
        public static double add(double avalue, double bvalue) => avalue + bvalue;
        public static double sub(double avalue, double bvalue) => avalue - bvalue;
        public static double mult(double avalue, double bvalue) => avalue * bvalue;
        public static double div(double avalue, double bvalue) => avalue / bvalue;

        public void Alloperation(double fvalue,double svalue,out double add,out double sub ,out double mul,out double div)
        {
            add = fvalue + svalue;
            sub = fvalue - svalue;
            mul = fvalue * svalue;
            div = fvalue / svalue;
        }

    }

    class Ex03_Functions
    {

        static void Main(string[] args)
        {
            var mathcomp = new Mathcomponet();
            Console.WriteLine("Enter the v1 ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the v2 ");
            double b = double.Parse(Console.ReadLine());
            double res1, res2, res3, res4;
            mathcomp.Alloperation(a, b, out res1, out res2, out res3, out res4);
            Console.WriteLine($"The values add{res1} the values sub{res2} the value mult{res3} the div{res4}");

        }
    }
}
