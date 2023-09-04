using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4.Week2
{
    class Ex_20EventsandDeligates
    {
        delegate double Operation(int v1, int v2);
            
        static void InvokeMathfun(int v1,int v2,Operation fuc) 
        {
            double rs = fuc(v1, v2);
            Console.WriteLine("The Result of the operation is " + rs);
        }
        static double add(int v1, int v2) => v1 + v2;
        static void callfuccall(int a ,int b , Func<int,int,double> fuc)
        {

            double rs =  fuc(a, b);
            Console.WriteLine("The result is "+rs);

        }
        static void Main(string[] args)
        {
            InvokeMathfun(12, 9, add);
            // The another method is by passing the function 
            InvokeMathfun(20,7,delegate(int x , int y) {
                return x * y - 10 * 23;
            });

            // Lambda expresion
            InvokeMathfun(45, 23, (x, y) => x * 7 * y);

            // This one is of Fun<> type operation deligate
            callfuccall(10, 9, (x, y) => x * y); // The operation is done here where sent back to function .
        }
    }
}
