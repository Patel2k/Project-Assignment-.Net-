using ConsoleAppAssignment.Module;
using System;
using System.Linq;
//Things to DO 1.Create an Array to store data 
namespace ConsoleAppAssignment
{
    class Data
    {
        public int Cutid { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }

    }
    class Customer_Program_Assignment : ICutomerDetails
    {
        static Data[] Storage = new Data[100];
        static int Count = 0;



        public void DeleData(int id)
        {
            int indx = -1;
            for (int i = 0; i < Storage.Count(); i++)
            {
                if (Storage[i].Cutid == id)
                {
                    indx = i;
                    break;
                }

            }
            if (indx == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Customer Data not found ");
            }
            else
            {
                for (indx = 0; indx < Count; indx++)
                {
                    Storage[indx] = Storage[indx + 1];
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Customer Deleted Successfully");
                    
                }


            }
        }

        public void display()
        {
            if(Count ==0 )
            {
                Console.WriteLine("Customer not added Please Add Customers--");
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The Details of Cutomer {Storage[i].CustName.ToUpper()} his id is {Storage[i].Cutid} and address is {Storage[i].CustAddress.ToUpper()}");

                }
            }
            //Console.WriteLine($"The Details of Cutomer {item.CustName} his id is {item.Cutid} and address is {item.CustAddress}");

        }

        public void UpdataData(int id)
        {
            int indx = -1;

            for (int i = 0; i < Count; i++)
            {
                if (Storage[i].Cutid == id)
                {
                    indx = i;
                    break;
                }
            }
            if (indx == -1)
            {
                Console.WriteLine("No Id Is Invalid");
                return;
            }
            else
            {
                for (indx = 0; indx < Count; indx++)
                {
                    Console.WriteLine("Enter the change name to add".ToUpper());
                    string name = (Console.ReadLine());
                    Storage[indx].CustName = name;
                    Console.WriteLine("Enter the address to change".ToUpper());
                    string address = Console.ReadLine();
                    Storage[indx].CustAddress = address;
                }

            }

        }
        static void Main(string[] args)
        {
            do
            {
                MenuDrive();
                int choice = int.Parse(Console.ReadLine());
                ChoiceData(choice);
            } while (true);

        }

        private static void ChoiceData(int s)
        {
            switch (s)
            {
                case 1:
                    AddingCustomerData();
                    break;
                case 2:
                    Console.WriteLine("Enter the id to Delete".ToUpper());
                    int id1 = int.Parse(Console.ReadLine());
                    new Customer_Program_Assignment().DeleData(id1);
                    break;
                case 3:
                    Console.WriteLine("Enter the id to Update".ToUpper());
                    int id2 = int.Parse(Console.ReadLine());
                    new Customer_Program_Assignment().UpdataData(id2);
                    break;
                case 4:
                    new Customer_Program_Assignment().display();
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        private static void AddingCustomerData()
        {

            Console.WriteLine("Enter your name to add in customer".ToUpper());
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the id of customer".ToUpper());
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the address of customer".ToUpper());
            string address = Console.ReadLine();
            new Customer_Program_Assignment().AddData(Name, id, address);
        }
        private static void MenuDrive()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("--------------MenuDrive-----------------\n" +
                "To Add new Custormer-------Press 1\n".ToUpper() +
                "To Delete New Customer-----Press 2\n".ToUpper() +
                "To Update an Customer------Press 3\n".ToUpper() +
                "For Display all details----Press 4\n".ToUpper() +
                "-------Exit----------------Press 5".ToUpper());
            Console.WriteLine("Enter the Choice ".ToUpper());
           

        }
        public void AddData(string name, int id, string address)
        {
            Storage[Count] = new Data { CustName = name, Cutid = id, CustAddress = address };
            Count++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer added Successfully".ToUpper());
        }
    }
}
