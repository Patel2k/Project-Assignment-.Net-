using Day_4.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4.Week2
{

    class UserAlreadyRegisterdException : Exception 
    {
        public UserAlreadyRegisterdException(string emoname) : base(emoname)
        {

        }
        public UserAlreadyRegisterdException() : base("User Alread created Exception")
        {

        }

    }

    class Ex_25ExceptionHandling
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();


        void Signin() { }
        void SignUp(string name , string pass)
        {
            try
            {
                users.Add(name, pass);
            }
            catch (ArgumentException)
            {

                throw new EmployeeNotFoundException("The data is INCORRECT "); 
            }
        }
        static void Main(string[] args)
        {
            //trycatchone();
            /* fileHandlingExample();
             checkDividedbyzero();*/
            ///checkemailexception();
            string uname = Utilities.GetString("Enter the name to Register");
            //string [ass]
        }

        
        private static void checkDividedbyzero()
        {

        }

        private static void trycatchone()
        {
            Console.WriteLine("Enter the number to add");
            RETRY:
            try
            {
                int no = int.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {

                Console.WriteLine("Enter the no da");
                goto RETRY; //Cycle is repeted and maintained for that action
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The values shoud be{int.MinValue} and {int.MaxValue}");
            }
            finally
            {
                Console.WriteLine("The end da its Done  " +
                    "Lets go");
            }
        }

        private static void fileHandlingExample()
        {
            try
            {
                var filename = "Akshay.txt";
                var content = File.ReadAllText(filename);
                Console.WriteLine("content");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Not found ");
            }

        }
     }
}
//Create a program that handles dividedbyzero exception