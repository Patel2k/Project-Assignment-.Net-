using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj02ConAPP
{
    struct rectangle {
    }

    struct Employeer
    {
        private int empID; //For Private datat use CamelCasing
        private string empName;
        private string empAdd;
        private double empSala;
       //Propertys in Camel Cases
        public int EmpID { get => empID; set => empID = value; }
        public string EmpName { get => empName; set => empName = value; }
        public string EmpAdd { get => empAdd; set => empAdd = value; }
        //public string EmpAdd { get => empAdd; set => empAdd = value; }
        public double EmpSal { get => empSala; set => empSala = value; }
      //  public string EmpSal { get => empSala; set=> }

       
    }
    class Ex03_Structs
    {
        static void Main(string[] args)
        {
            Employeer em = new Employeer();
            em.EmpName = "Akshay";
            em.EmpID = 90; //We can treat it like feed and consume it easily
            em.EmpAdd =" Davangere 484 door no";
            em.EmpSal = 459000;
            Console.WriteLine("The details of employee" + em.EmpName);
        }
    }
}
