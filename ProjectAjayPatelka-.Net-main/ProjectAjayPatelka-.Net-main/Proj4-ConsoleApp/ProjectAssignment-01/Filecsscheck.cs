using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjectAssignment_01
{
    

    class Filecsscheck
    {
       const string filename = @"C:\Users\apatelka\source\repos\ProjectData-01\ProjectAssignment-01\Menu.txt";
        static void Main(string[] args)
        {
            var content = File.ReadAllText(filename);
            Console.WriteLine(content);
        }
    }
}
