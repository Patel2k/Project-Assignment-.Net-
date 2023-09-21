using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment
{
    class Calender2
    {
        static int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
        static int dayNumber(int day,int month,int year)
        {
            if(month < 3)
            {
                year -= month;
            }
            return (year + year / 4 - year / 100 + year / 400 + t[month - 1] + day) % 7;
        }
       

        static void Main(string[] args)
        {
            
        }
    }
}
