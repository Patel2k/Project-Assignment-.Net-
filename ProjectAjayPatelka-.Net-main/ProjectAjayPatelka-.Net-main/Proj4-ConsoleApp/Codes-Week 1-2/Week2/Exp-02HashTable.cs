using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Day_4
{
    class Exp_02HashTable
    {
        static void Main(string[] args)
        {
            hashtablecheck();
            dictionarycheck();
        }

        private static void dictionarycheck()
        {
            Dictionary<string, string> st = new Dictionary<string, string>();
            st.Add("Akshay", "Akshay@123");
            st.Add("Ajay", "Ajay@123");
            st.Add("Padma", "Padma@123");
            st.Add("Lekha", "Lekha@123");
            st.Add("Sourav", "Sourav@123");
            st["Madhav"] = "Madhav@123"; //The another way of adding the data there but it throws exception while the data is ensured and adds a new key ad a value to collection
            Console.WriteLine("Enter the username");
            var usname = Console.ReadLine();
            
            Console.WriteLine("Enter the password");
            var pass = Console.ReadLine();
            if (!st.ContainsKey(usname))
            {
                Console.WriteLine("Wrong username!!!!!!");
            }
            else
            {
                if(st[usname] != pass)
                {
                    Console.WriteLine("Wrong pass dude go through that again da what daaa");
                }
            }
        }

        private static void hashtablecheck()
        {
            Hashtable check = new Hashtable();
            check.Add(1, "Akshay");
            check.Add(2, "Abhishek");
            check.Add(3, "Lekha");
            foreach(var value in check.Values)
            {
                Console.WriteLine("The values are " + value);
            }
        }    }
}
// Create 2 function called sign in and sign up and implement dic for user to login and register