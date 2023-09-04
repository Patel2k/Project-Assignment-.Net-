using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4.Common
{
    class EmployeeNotFoundException:Exception
    {
        public EmployeeNotFoundException():base ("NOT FOUND ")
        {

        }
        public EmployeeNotFoundException(string name):base(name)
        {

        }
    }
}
