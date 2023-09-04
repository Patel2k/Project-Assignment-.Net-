using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj02ConAPP.Module
{
    //Entity classes are used are created to represent real world entitys ex : Book , Employee,patient,bill,food;
    class Employeeclass  // One class real world one entity
    {
        public string empname { get; set ;}
        public double empid { get; set; }
        public string empaddres { get; set; }
        public double empsalary { get; set; }
       

    }
    // class the implement the crud operation for a storage device (Database entitys)
    
   class maincheck
    {
        public static Employeeclass[] empcollect= new Employeeclass[100];
        public static int empcount = 0;
        static void Main(string[] args)
        {
            while (true) 

            {
                Mainmenu();
                Console.WriteLine("Enter Your Choice");
                string s = Console.ReadLine();
                choiceselection(s);
            }
        }

        private static void choiceselection(string s)
        {
            
                switch (s)
                {
                case "N":
                        Addingemp();
                        break;
                case "U":
                        updateofemp();
                        break;
                case "D":
                        deleteemp();
                        break;
                case "F":
                        findemp();
                        break;
                case "A": Display();
                          break;
                default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            
        }

        public static void Display()
        {
           if(empcount == 0)
            {
                Console.WriteLine("No employee to display");
            }
           else
            {
                Console.WriteLine("List of employees are");
                for (int i= 0; i < empcount;i++) {
                    Console.WriteLine($"Id is {empcollect[i].empid} name is {empcollect[i].empname} and the address {empcollect[i].empaddres} and salary is {empcollect[i].empsalary}");
                }
            }
        }

        public static void findemp()
        {
            Console.WriteLine("Enter the id to find");
            int id = int.Parse(Console.ReadLine());
            int indx = -1;
            for(int i=0;i<empcount;i++)
            {
                if(empcollect[i].empid == id)
                {
                    indx = i;
                    break;
                }
            }
            if(indx != -1)
            {
                Console.WriteLine($"Id is {empcollect[indx].empid} name is {empcollect[indx].empname} and the address {empcollect[indx].empaddres} and salary is {empcollect[indx].empsalary}");
            }
        }

        public static void deleteemp()
        {
            Console.WriteLine("Enter employee id to delete ");
            int id = int.Parse(Console.ReadLine());
            int indx = -1;
            for(int i=0;i<empcount;i++)
            {
                if(empcollect[i].empid == id )
                {
                    indx = i;
                    break;
                }
            }
            if(indx == -1)
            {
                for(int i=indx;i<empcount-1;i++)
                {
                    empcollect[i] = empcollect[i + 1]; 
                }
                empcount--;
                Console.WriteLine("Employee deleted Successfully");

            }
        }

        public static void updateofemp()
        {
            Console.WriteLine("Empolyee Id to Update:");
            int id = int.Parse(Console.ReadLine());
            int indx = -1;

            for(int i=0;i<empcount;i++)
            {
                if(empcollect[i].empid == id)
                {
                    indx = i;
                    break;
                }
            }
            if(indx!=-1)
            {
                Console.WriteLine("Enter name to update");
               
                empcollect[indx].empname = Console.ReadLine();
                Console.WriteLine("Enter name to address");
                empcollect[indx].empaddres = Console.ReadLine();
                Console.WriteLine("Enter salary ");
                empcollect[indx].empsalary = int.Parse(Console.ReadLine());
            }

        }

        public static void Addingemp()
        {
            Employeeclass emp = new Employeeclass();
            Console.WriteLine("Enter Your Name");
            string name = Console.ReadLine();
            emp.empname = name;
            Console.WriteLine("Enter Your Id");
            int id = int.Parse(Console.ReadLine());
            emp.empid = id;
            Console.WriteLine("Enter Your Address");
            string add = Console.ReadLine();
            emp.empaddres = add;
            Console.WriteLine("Enter Your salary");
            double sal = double.Parse(Console.ReadLine());
            emp.empsalary = sal;
            //employeecollection checks = new employeecollection();
            empcollect[empcount] = new Employeeclass { empname = name, empid = id, empaddres = add, empsalary = sal };
            empcount++;
            //employeecollection ec = new employeecollection();
            // ec.AddEmployee();
            Console.WriteLine("Employee added successfully");

        }

        public static void Mainmenu()
        {
            Console.WriteLine("--------------Employee Menu-----------------\n" +
                "To Add New Employee -------Press N\n" +
                "To Update New Employee-----Press U\n" +
                "To Delete an Employee------Press D\n" +
                "To Find an Employee--------Press F\n" +
                "For Display all details----Press A\n" +
                "-------Exit----------------Press E"); 
        }
    }
}
