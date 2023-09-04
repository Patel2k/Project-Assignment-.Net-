using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4.Models
{
    class EmployeeDatabase : IEmpDatabase
    {
        public  static List<Employee> employee = new List<Employee>();
        public Employee this[int index] => employee[index];

        public int count => employee.Count;

        public void AddElement(Employee emp) => employee.Add(emp);

        public void DeleteElement(int id)
        {
            foreach (var item in employee) // Check wheather the employee id is present and then remove data from the list;
            {
                if (item.Empid == id)
                {
                    employee.Remove(item);
                    return;
                }
            }
            throw new Exception("No Employee found to delete");
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return employee.GetEnumerator();
        }


        public void UpdateEmploye(int id, Employee emp)
        {
            foreach (var item in employee) // Check wheather the employee id is present and then remove data from the list;
            {
                if (item.Empid == id)
                {

                    item.DeepCopy(item);
                    return;

                }
            }
            throw new Exception("No Employee found to update");
        }

        /// <summary>
        /// Explicit implimentation point this IEnumerable is used and added
        /// </summary>
        /// <returns></returns>
        /// 

        IEnumerator<Employee> IEnumerable<Employee>.GetEnumerator()
        {
            foreach (var item in employee)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return employee.GetEnumerator();
        }
    }
    class CollectionDATABASE 
    {
        //public static List<Employee> employee = new List<Employee>();
        public static EmployeeDatabase ex = new EmployeeDatabase();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee data_Base");
            while (true)
            {
                MenuDrive();
                Console.WriteLine("Enter your Choice");
                int c =int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Addingusersdata();
                        break;


                    case 2:
                        Deleteuserdata();
                        break;

                    case 3:

                        Updatauserdata();

                        break;

                    case 4: Display();
                        break;
                    case 5:
                    default:
                        break;
                }
            }
        }

        private static void Updatauserdata()
        {
            Console.WriteLine("Enter the id to update");
            int id = int.Parse(Console.ReadLine());
            string name = Utilities.GetString("Enter the name to change :");
            string addres = Utilities.GetString("Enter the address to change :");
            int salary = Utilities.GetInteger("Enter the salary of to change :");
            Employee emp = new Employee { Empid = id, EmpAdrss = addres, Empname = name, Empsalary = salary };
            ex.UpdateEmploye(id, emp);
            Console.WriteLine("Employee Data Changed Successfully");
        }


        private static void Display()
        {
            
           foreach(var item in EmployeeDatabase.employee)
            {
                Console.WriteLine($"The details of the employees {item.Empname} {item.Empid} {item .EmpAdrss} {item.Empsalary}");
            }
        }

        private static void Deleteuserdata()
        {
            Console.WriteLine("Enter the id to delete");
            int id = int.Parse(Console.ReadLine());
            ex.DeleteElement(id);
        }

        private static void Addingusersdata()
        {
            Console.WriteLine("Enter the Name of Employee");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Id of Employee");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the address");
            string addr = Console.ReadLine();
            Console.WriteLine("Enter the salary");
            int salary = int.Parse(Console.ReadLine());
            Employee starts = new Employee { Empid = id, Empname = name, EmpAdrss = addr, Empsalary = salary };
            //EmployeeDatabase.employee.Add(starts);
            ex.AddElement(starts);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee added to list succesfully");
        }

        private static void MenuDrive()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("To add the employee -----Press 1");
            Console.WriteLine("To Delete the employee --Press 2");
            Console.WriteLine("To Update the employee --Press 3");
            Console.WriteLine("To Display the employee -Press 4");
            Console.WriteLine("To Exit -----------------Press 5");
        }
    }

}
