using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment.Module
{
    interface ICutomerDetails
    {
        void AddData(string name , int id , string address);
        void DeleData(int id);
        void UpdataData(int id);
        void display();

    }
}
