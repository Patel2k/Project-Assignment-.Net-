using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Configuration;
using Day_4.Common;

namespace Day_4.Models

{
    //[Serializable]
    class EmpBinaryDatabase : IEmpDatabase
    {
        static List<Employee> _list = new List<Employee>();
        public Employee this[int index] => _list[index];

        public int count => _list.Count;
        private readonly string filename = ConfigurationManager.AppSettings["binaryFile"];
        private void save()
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter fm = new BinaryFormatter();
            fm.Serialize(fs, _list);
            fs.Close();
        }
        private void load()
        {
            if (!File.Exists(filename))
            {
                return;
            }
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            _list = fm.Deserialize(fs) as List<Employee>;
            fs.Close();
        }
        public void AddElement(Employee emp)
        {
             load();
            _list.Add(emp);
             save();
            
        }

        public void DeleteElement(int id)
        {
            load();
            var foundRec = _list.Find(delegate (Employee data)
            {
                return data.Empid == id;                       //This thing is checking its value is present or not and then its trying to check using deligate fuction and maintaing the major data 

            });
            if (foundRec != null)
            {
                _list.Remove(foundRec);
                save();
            }
            else
            {
                //
                throw new EmployeeNotFoundException("The data not able to delete");
            }
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _list.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void UpdateEmploye(int id, Employee emp)
        {
            load();
            var foundrec = _list.Find(delegate (Employee data)
            {
                return data.Empid == id;
            });
            if (foundrec != null)
            {
                //_list.Add()
            }
            else
            {
                throw new EmployeeNotFoundException("Unable to Add data due to some error");
            }
        }
        public void FindEmployee(int id)
        {
            load();
            var foundRec = _list.Find(delegate (Employee temp)
            {
                return temp.Empid == id;
            });
            if (foundRec != null)
            {
                Display(foundRec);
            }
            else throw new EmployeeNotFoundException($"Employee with id: {id} Not Found");
            save();
        }
        public static void SelectChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------MENUDRIVE------------");
            Console.WriteLine("To add the employee -----Press 1");
            Console.WriteLine("To Delete the employee --Press 2");
            Console.WriteLine("To Update the employee --Press 3");
            Console.WriteLine("To Display the employee -Press 4");
            Console.WriteLine("To Exit -----------------Press 5");
            Console.WriteLine("Enter your Choice");
            int c = int.Parse(Console.ReadLine());
            do
            {
                switch (c)
                {
                    case 1:
                        Addingusersdata();
                        break;


                    case 2:
                        //Deleteuserdata();
                        int idx = Utilities.GetInteger("Enter the id of the employee to get Delete");
                        new EmpBinaryDatabase().DeleteElement(idx);
                        break;

                    case 3:
                        int id = Utilities.GetInteger("Enter the id of the employee to get updated");
                        var foundRec = _list.Find((temp) => temp.Empid == id);
                        Updateuserdetails(id, foundRec);

                        break;

                    case 4:
                        new EmpBinaryDatabase().FindEmployee(Utilities.GetInteger("Enter the Id to find details"));
                        //Display(emp);
                        break;
                    case 5: return;
                    default:
                        break;
                }
            } while (true);
        }

        public static void Updateuserdetails(int id, Employee emp)
        {

            var foundRec = _list.Find((temp) => temp.Empid == id);
            if (foundRec != null)
            {
                int choice = Utilities.GetInteger("Enter Property to update: 1 for EmpId, 2 for EmpName, 3 for EmpAddress, 4 for EmpSalary");
                switch (choice)
                {
                    case 1:
                        int uid = Utilities.GetInteger("Enter Id to update");
                        foundRec.Empid = uid;
                        Console.WriteLine("Employee ID updated successfully");
                        break;
                    case 2:
                        string uname = Utilities.GetString("Enter Name to update");
                        foundRec.Empname = uname;
                        Console.WriteLine("Employee Name updated successfully");
                        break;
                    case 3:
                        string uadd = Utilities.GetString("Enter Address to update");
                        foundRec.EmpAdrss = uadd;
                        Console.WriteLine("Employee Address updated successfully");
                        break;
                    case 4:
                        int usal = Utilities.GetInteger("Enter Salary to update");
                        foundRec.Empsalary = usal;
                        Console.WriteLine("Employee Salary updated successfully");
                        break;
                    default:
                        Console.WriteLine("Invalid Option Choosen");
                        break;
                }
            }
        }

            private static void Display(Employee emp)
            {
                Console.WriteLine("The employee details are:");
                Console.WriteLine("Employee ID is: " + emp.Empid + " Employee Name is: " + emp.Empname + "\n Employee Address is " + emp.EmpAdrss + " Employee Salary is " + emp.Empsalary);
                Console.ForegroundColor = ConsoleColor.Green;
            }

            public static void Addingusersdata()
            {
                Console.WriteLine("Enter the Name of Employee");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Id of Employee");
                int idx = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the address");
                string addr = Console.ReadLine();
                Console.WriteLine("Enter the salary");
                int salary = int.Parse(Console.ReadLine());
                Employee starts = new Employee { Empid = idx, Empname = name, EmpAdrss = addr, Empsalary = salary };
                new EmpBinaryDatabase().AddElement(starts);

                //  ex.AddElement(starts);*/

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee added to list succesfully");
            }


        }
    }

   

