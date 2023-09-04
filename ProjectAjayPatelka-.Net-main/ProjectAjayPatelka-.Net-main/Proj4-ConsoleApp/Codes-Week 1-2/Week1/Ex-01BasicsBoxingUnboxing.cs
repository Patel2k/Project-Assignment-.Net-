using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj02ConAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            //boxingandUnboxing();
            RefereceType();
        }

        private static void RefereceType()
        {
            object intvalue = new object();
            int c = (int)intvalue;
            Console.WriteLine(c);
            //New object can not affect the values if the object is just changed in this due to reference object;

       }

        private static void boxingandUnboxing()
        {
            object obj = 12; // Boxed value
            Console.WriteLine("The Value and type of this boxed type is:" + obj.GetType().Name);
            int temp = (int)obj; //Unboxing value 
            temp++;
            Console.WriteLine("The unboxed and return value is changed it back to by doing unboxing" + temp);
        }
    }
}
