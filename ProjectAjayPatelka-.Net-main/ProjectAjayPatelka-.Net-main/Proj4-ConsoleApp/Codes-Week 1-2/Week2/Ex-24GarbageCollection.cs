using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day_4.Week2
{
    class MemClass:IDisposable // 
    {
        public string clsName { get; set; }
        public MemClass(string name )
        {
            clsName = name;
            Console.WriteLine($"Object by name {clsName} is created");
        }
        ~MemClass () { 
            Console.WriteLine($"Object by name {clsName} is Distroyed");
            GC.Collect();
            // The collector 
            GC.WaitForPendingFinalizers();
        }

        public void Dispose()
        {
            Console.WriteLine($"Object by name {clsName} is Distroyed");
        }
    }
    class Ex_24GarbageCollection
    {
        static void createAndDistroy()
        {
            for (int i = 1; i <= 10; i++)
            {
               // MemClass mem = new MemClass(("Class Name "+i));
                using (MemClass cls = new MemClass("Class is" + i))
                {
                    // This directly calls the dispose fuction directly
                };
            }
        }
        static void Main(string[] args)
        {
            createAndDistroy();
            /*Console.WriteLine("The Main ends here--------------------------------------");
            Thread.Sleep(10);*/
            

        }
    }
}
