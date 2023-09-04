using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//csv comma su
namespace Day_4.Week2
{
    class Ex_22FileIO
    {
        const string filename = @"Empdata.csv";
        static void Main(string[] args)
        {
            //ReadAllContents  we use readalltext framework to run stuff
            readallContent(filename);
            var emp = new Models.Employee();
            emp.Empid = Utilities.GetInteger("Enter the id ");
            emp.Empname = Utilities.GetString("Enter the name ");
            emp.EmpAdrss = Utilities.GetString("Enter the addres ");
            emp.Empsalary = Utilities.GetInteger("Enter the salary ");
            writeallcontentfile(emp);
            List<Models.Employee> employees = readallRecord(filename);
            foreach(var item in employees)
            {
                Console.WriteLine($"The name is {item.Empname} and id is {item.Empid}");
            }
            Console.WriteLine("");
            int id = Utilities.GetInteger("Enter the id to delete");
            Deletedatainfile(id);
        }

        private static void Deletedatainfile(int id)
        {
            var record = readallRecord(filename);
            for (int i = 0; i < record.Count; i++)
            {
                if(record[i].Empid == id)
                {
                    record.RemoveAt(i);
                    break;
                }
            }
            File.Delete(filename);
            bulkInsertRecord(record);
        }

        private static void bulkInsertRecord(List<Models.Employee> record)
        {
            foreach (var item in record)
            {
                writeallcontentfile(item);
            }
        }

        private static List<Models.Employee> readallRecord(string filename)
        {
            //Create a new list to store and pring
            List<Models.Employee> employee = new List<Models.Employee>();
            //1.Get all the line
            string[] line = File.ReadAllLines(filename);
            foreach(var item in line)
            {
                string[] words = item.Split(',');
                //2.Iterate each line and split the line into wordss
                //3.1st word is id ,and ....
                var emp = new Models.Employee
                {
                    Empid = int.Parse(words[0]),

                    Empname = words[1],
                    EmpAdrss = words[2],
                    Empsalary = int.Parse(words[3])
                };
                employee.Add(emp);


            }


            //4 .Create the emp object and set the calues from the words taken
            //5.Add the obj to the list collection
            return employee;

        }

        private static void writeallcontentfile(Models.Employee emp) 
        {
            var line = $"{emp.Empid}, {emp.Empname}, {emp.EmpAdrss}, {emp.Empsalary}\n";
            File.AppendAllText(filename, line);  //This will add the line data to the filename specifically
            Console.WriteLine(line);

        }

        private static void readallContent(string filename)
        {
            var content = File.ReadAllText(filename);
            Console.WriteLine(content);
        }
    }
}
