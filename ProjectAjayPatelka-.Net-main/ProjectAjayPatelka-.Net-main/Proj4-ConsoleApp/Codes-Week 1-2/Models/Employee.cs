using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Day_4.Models
{
    [Serializable]
    class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string  EmpAdrss { get; set; }

        public int Empsalary { get; set; }

        public override int GetHashCode()
        {
            return Empid;
        }
        public override bool Equals(object obj)
        {
            if(obj is Employee)
            {
                var temp = obj as Employee;
                return temp.Empid == this.Empid;
            }
            return false;
        }
        public void DeepCopy(Employee other)
        {
            Empid=other.Empid;
            Empname = other.Empname;
            EmpAdrss= other.EmpAdrss;
            Empsalary = other.Empsalary;
            
        }
       
    }
    class Empcollection
    {
        private Employee[] _empList;

        public Empcollection()
        {
            _empList = new Employee[100];
        }

        private Employee deepCopy(Employee emp)
        {
            Employee temp = new Employee();
            temp.Empid = emp.Empid;
            temp.EmpAdrss = emp.EmpAdrss;
            temp.Empname= emp.Empname;
            temp.Empsalary = emp.Empsalary;
            return temp;
        }
        public void AddNewEmployee(Employee emp)
        {
            for (int i = 0; i < 100; i++)
            {
                if (_empList[i] == null)
                {
                    _empList[i] = deepCopy(emp);
                }
            }
        }

        public Employee FindEmployee(int id)
        {
            return new Employee { Empid = 111, EmpAdrss = "Bangalore", Empname = "Phaniraj", Empsalary = 56000 };
        }

        public Employee[] FindAllEmployees()
        {
            return _empList;
        }

        public void DeleteEmployee(int id)
        {
            Console.WriteLine("Employee deleted successfully");
        }

        public void UpdateEmployee(int id, Employee updatedRec)
        {
            Console.WriteLine("Employee updated successfully");
        }
    }

    class MainClass 
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Empid = 01;
            emp.Empname = "Ajay";
            emp.EmpAdrss = "Bangelore";
            emp.Empsalary = 909090;
            Empcollection empr = new Empcollection();
            empr.AddNewEmployee(emp);
            
        }

    }

}


