using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp01LoanCalculator
{
    class ArrayProgramAdvance
    {
        static void Main(string[] args)
        {
            NewMethod();
        }

        private static void NewMethod()
        {
            Console.WriteLine("Enter the size of Array");
           // Console.ReadKey();
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter type of array want to create string , float ,double ,int,char");
            string types = Console.ReadLine();
            // dynamic arr[] = new int[]
            Type ele = Type.GetType(types);
            //Array.GetType().IsArray();
            if (ele == null)
            {
                Console.WriteLine("Invalid data type ,cannot create array");
                return;
            }
            //convert.changetype
            Array array = Array.CreateInstance(ele, size);
            //Static fuctions 
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value for the array at the index {i} fo the data{ele.Name}");
                var value = Convert.ChangeType(Console.ReadLine(), ele);
                array.SetValue(value, i);
            }
            Console.WriteLine("All the value are set");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
