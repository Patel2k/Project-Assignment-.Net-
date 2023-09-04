using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj02ConAPP
{
    enum accounttype {
        sbaccount =1 ,rdaccount,fdaccount
    };
    class Ex_02enumcheck
    {
        static void Main(string[] args)
        {
            Basic2();

        }

        private static void Basic2()
        {
            //basic1();
            Console.WriteLine("Please sectect the account type that u want");
            var arrayValue = Enum.GetValues(typeof(accounttype));
            foreach(var a in arrayValue) {
                Console.WriteLine(" " + a);
            } // Printing all Enum Values present in enum data
            Console.WriteLine("The account available are " + arrayValue);
            string input = (Console.ReadLine());
            accounttype ac = (accounttype)Enum.Parse(typeof(accounttype), input);
            //Unboxing is done here so that the object value is converted into the type by douing unboxing thing
            Console.WriteLine("The selected is " + ac);
        }

        private static void basic1()
        {
            accounttype ac = accounttype.fdaccount;
            Console.WriteLine("The selected is" + ac);
            Console.WriteLine("Select the values in 0 1 2 in given group");
            ac = (accounttype)int.Parse(Console.ReadLine());
            Console.WriteLine("The selected is " + ac);
        }
    }
}
