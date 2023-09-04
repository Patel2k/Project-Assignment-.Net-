using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    interface Iexaple
    {
        string Example();
    }
    interface Isimple
    {
        void Example();
    }
    class Ex_19Interface : Isimple , Iexaple
    {
        public void Example() => Console.WriteLine("This is example".ToUpper());
        void Isimple.Example() => Console.WriteLine("The Result");
        string Iexaple.Example() => "This is Iexample just it";

    }
    class maincheck
    {
        static void Main(string[] args)
        {
            Ex_19Interface st = new Ex_19Interface();
            st.Example();
            

            Iexaple yk = new Ex_19Interface();
            yk.Example();

            Isimple xk = new Ex_19Interface();
            xk.Example();
        }
    }
}
