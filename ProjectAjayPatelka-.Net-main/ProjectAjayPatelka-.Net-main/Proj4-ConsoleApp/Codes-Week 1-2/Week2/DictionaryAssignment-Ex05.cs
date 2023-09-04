using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class DictionaryAssignment_Ex05
    {
        public static Dictionary<string, string> userdetails = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            //1st user to sign in 
            do
            {
                Console.WriteLine("-------WELCOME TO USERLOGIN-----------");
                Console.WriteLine("Enter your choice \nIf your are NEW USER-- Press 1.SignUp \n" + "If your are EXISTINGUSER Press 2.SignIn\n3.Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SignUp(); // if you are new user
                        break;
                    case 2:
                        SignIn(); // if you have the account
                        break;
                    case 3: //Console.WriteLine();
                        return;
                    default:
                        break;
                }


            } while (true);
        }

        private static void SignUp()
        {
            Console.WriteLine("Enter your User Name : ");
            string name = Console.ReadLine(); 
            Console.WriteLine("Enter your Password : ");
            string password = Console.ReadLine();
            userdetails.Add(name, password);
            Console.WriteLine("Welcome to MenuDriven " +  " Added Successfully");
        }

        private static void SignIn()
        {
            Console.WriteLine("Enter your User Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            string password = Console.ReadLine();
            if(!userdetails.ContainsKey(name))
            {
                Console.WriteLine("---------Your are the user of MENUDRIVEN------!");
                Console.WriteLine("User name is not present!!!");
            }
            else
            {
                if(userdetails[name] != password)
                {
                    Console.WriteLine("Your PASSWORD INCORRECT TRY AGAIN");
                }
                else
                {
                    Console.WriteLine("Welcome to MENUDRIVEN");
                }
            }

        }
    }
}
