using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{

    class employeshashset
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string EAddress { get; set; }
        public int ESalary { get; set; }

        public  override int GetHashCode()
        {
            return Empid;
        }
        public override bool Equals(object obj)
        {
            var temp = obj as employeshashset;
            if (temp.Empid != Empid)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
          //  employeshashset emp = new employeshashset();
            HashSet<employeshashset> check = new HashSet<employeshashset>();
            check.Add(new employeshashset { Empid = 111, Empname = "Akshay", EAddress = "Banglore", ESalary = 900000 });
            check.Add(new employeshashset { Empid = 111, Empname = "Akshay", EAddress = "Banglore", ESalary = 900000 });
            check.Add(new employeshashset { Empid = 111, Empname = "Akshay", EAddress = "Banglore", ESalary = 900000 });
            check.Add(new employeshashset { Empid = 111, Empname = "Akshay", EAddress = "Banglore", ESalary = 900000 });
            check.Add(new employeshashset { Empid = 111, Empname = "Akshay", EAddress = "Banglore", ESalary = 900000 });
            foreach(var item in check)
            {
                Console.WriteLine(item.GetHashCode());
                
            }
            

        }

        
    }
}
