using System;
using System.Collections.Generic;
namespace Proj1_SampleConApp.Week_2
{
    using Day_4.Models;
    using Proj1_SampleConApp.Common;
   //[Serializable]
    class Ex18_CustomCollections
    {
        EmpBinaryDatabase exs = new EmpBinaryDatabase();
       
        static void Main(string[] args)
        {

            var component = EmpFactory.GetComponent("binary");
            //MenudriveCheck();
           // EmpBinaryDatabase.
            EmpBinaryDatabase.SelectChoice();
            foreach (var emp in component)
            {
                Console.WriteLine(emp.Empname);
            }

        }

      
    }
}