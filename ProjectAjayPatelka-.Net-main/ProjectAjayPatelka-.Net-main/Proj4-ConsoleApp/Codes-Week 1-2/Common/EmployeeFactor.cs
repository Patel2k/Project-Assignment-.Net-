using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1_SampleConApp.Common
{
    using Day_4.Models;
    using Proj1_SampleConApp.Week_2;
    //A Class that has only static methods, which makes sure that the instance for this class is not created. 
    //[Serializable]
    static class EmpFactory
    {
        public static IEmpDatabase GetComponent(string type)
        {
            switch (type.ToLower())
            {
                case "list": return new EmployeeDatabase();
                case "binary": return new EmpBinaryDatabase();
                default: return new EmployeeDatabase(); ;
            }
        }
    }
}