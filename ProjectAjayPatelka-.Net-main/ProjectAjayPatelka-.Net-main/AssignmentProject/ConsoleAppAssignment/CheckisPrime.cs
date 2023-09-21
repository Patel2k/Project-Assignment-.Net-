using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment
{
    class CheckisPrime
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number to check is Prime or Not");
            int a = int.Parse(Console.ReadLine());
           bool check =  CheckIsPrimeno(a);
            if(check)
            {
                Console.WriteLine($"The no {a} is Prim number");
            }
            else
            {
                Console.WriteLine($"The no {a} is not Prim number");
            }


        }

        private static bool CheckIsPrimeno(int a)
        {
            if(a <= 1)
            {
                return false;
            }
            if(a <= 3)
            {
                return true;
            }
            if(a %2 ==0 || a %3 ==0)
            {
                return false;
            }
            for (int i = 5; i * i <= a; i+=6)
            {
                if (a % i == 0 || a % (i + 2) == 0)      //Major option where the value is checked and the Formation is reduced here
                    return false;
            }
            return true ;
        }
    }
}
