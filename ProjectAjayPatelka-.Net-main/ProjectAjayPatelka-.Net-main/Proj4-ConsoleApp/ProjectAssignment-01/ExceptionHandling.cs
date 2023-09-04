using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment_01
{
    class VenderNotFound:Exception
    {
        public VenderNotFound() : base("NOT FOUND ")
        {

        }
        public VenderNotFound(string name) : base(name)
        {

        }

    }
}
