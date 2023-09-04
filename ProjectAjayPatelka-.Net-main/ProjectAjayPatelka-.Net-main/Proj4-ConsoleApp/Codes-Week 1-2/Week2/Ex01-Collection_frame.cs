using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
//using System.Linq; // used to reverse the queue element and easily add . REVERSE fucntion in queue

namespace Day_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            //arraylistexp();

            // listcheck();
            //hashsetcheck();
            //hashtablecheck();
            //queuecheck();
            Stackexample();
        }

        private static void Stackexample()
        {
            Stack<string> storage = new Stack<string>();
            storage.Push("Fruits");
            storage.Push("Veggies");
            storage.Push("Software");
            storage.Push("Electronics");
            storage.Push("Backendeng");
            foreach(var item in storage)
            {
                Console.WriteLine(item);
            }
            storage.Pop(); // Backend last item is gone because stack follows first in last out
            Console.WriteLine("Poped element details");
            foreach (var item in storage)
            {
                Console.WriteLine(item);
            }
        }

        private static void queuecheck()
        {
            Queue<string> values = new Queue<string>();
            do
            {
                Console.WriteLine("Enter the product name to view details");
                string details = Console.ReadLine();
                values.Enqueue(details);
                if(values.Count > 5)
                {
                    values.Dequeue();
                }
               //var val1 = values.ToArray();
               List<string> next = new List<string>(values.ToArray());
               next.Reverse();
                foreach (var item in values)
                {
                    Console.Write("Added data is :");
                    Console.WriteLine(item);
                }

            } while (true);

        }

        private static void hashsetcheck()
        {
            HashSet<string> hs = new HashSet<string>();
            hs.Add("Apple");
            hs.Add("ball");
            hs.Add("cat");
            hs.Add("Apple");
            hs.Add("Apple"); //So the duplicates are not added so they are removed at starting point itself .

            foreach(var item in hs)
            {
                Console.WriteLine("The items are " + item);
            }

            
        }

        private static void listcheck()
        {
            List<string> a = new List<string>();
            a.Add("EMP-Lekha");
            a.Add("EMP-Akshay");
            a.Add("EMP-sourav");
            a.Add("EMP-abhishek");
            a.Add("EMP-linga");
            foreach(var item in a)
            {
                Console.WriteLine("The employees are " + item);
            }
        }

        private static void arraylistexp()
        {
            ArrayList fruits = new ArrayList(); //It creates a black array and size =0;
            fruits.Add("Apple");
            fruits.Add("Ball");
            foreach(var item in fruits)
            {
                Console.WriteLine("Item is"+item);
            }

            Console.WriteLine(fruits.ToArray());
            Console.WriteLine("The count is "+fruits.Count); //Count is used to check the count of the data which is present inside it.
            fruits.Remove("oranges"); // This takes the object of the given data ;
            fruits.RemoveAt(1);//This takes the index to remove;
            fruits.RemoveRange(0, 2); //The removing of the data from the given range and the actions.
            //limitations of array list();

            Console.WriteLine("The removed things is "); // The disadvantage is that the data add are of any type but the problem is that the values always have to unbox and box at the same time so the value is different which takes lots of time while compiling the program

        }
        private static void hashtablecheck()
        {
            Hashtable check = new Hashtable();
            check.Add(1, "Akshay");
            check.Add(2, "Abhishek");
            check.Add(3, "Lekha");
            foreach (var key in check)
            {
                Console.WriteLine("The values are " + key.GetHashCode());
            }
        }
    }
}
// Look on a example on hashtable data is stored in form of key value pairs
//Create a n list of employee and try to add multiple employees and read the name of the employee