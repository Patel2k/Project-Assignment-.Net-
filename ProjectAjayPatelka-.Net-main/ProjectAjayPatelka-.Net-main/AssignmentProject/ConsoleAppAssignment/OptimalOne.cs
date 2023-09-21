using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment
{
    class OptimalOne
    {
        const string code = " the quick and brown fox jumps over the lazy dog";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the actions to encode");
            string a = Console.ReadLine();
            var temp = Encode(" ");
            

        }

        private static object Encode(string v)
        {
            var content = "";
            if(v == null)
            {
                throw new NullReferenceException("Null Not Allowed");

            }
            else if(string.IsNullOrEmpty(v))
            {
                throw new ArgumentException("String can not be null");
            }
            foreach(var item in v.ToLower())
            {
                if(item == ' ')
                {
                    content = content.Substring(0, content.Length - 1);
                  //  content += getCode();
                }
               // else if( item == )
            }
            return content.Substring(0, content.Length - 1);
        }

      
    }
}
