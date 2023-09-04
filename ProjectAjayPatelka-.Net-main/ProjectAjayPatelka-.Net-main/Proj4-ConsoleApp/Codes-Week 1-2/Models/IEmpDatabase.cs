using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4.Models
{
    interface IEmpDatabase:IEnumerable<Employee>
    {
        void AddElement(Employee  emp);
        void DeleteElement(int id);
        void UpdateEmploye(int id,Employee emp);

        int count { get; }
        Employee this[int index] { get; }
    }
}
