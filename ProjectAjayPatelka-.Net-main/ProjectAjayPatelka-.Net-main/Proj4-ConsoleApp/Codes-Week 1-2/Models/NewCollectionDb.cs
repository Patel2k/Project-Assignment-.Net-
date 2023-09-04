using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Day_4.Models;

namespace Day_4.Week2
{
    internal class EmpData
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string Empadd { get; set; }
        public int EMpsala { get; set; }
        public int DeptId { get; set; }
    }
    class NewCollectionDB
    {
        static List<EmpData> records = new List<EmpData>();
        const string STRSELECT = "SELECT * FROM MYFIRST ";
        const string STRCONNECTION = @"Data Source=W-674PY03-2;Initial Catalog=AjayDataBase;Persist Security Info=True;User ID=SA;Password=Password@123456-=";
        static void ReaddAllRecord()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            /*con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";*/
            //con.ConnectionString(STRCONNECTION);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = STRSELECT;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //SqlDataReader con = cmd.ExecuteReader();
                //cmd.Connection = con; // Has - A Realation
                while (reader.Read())
                {
                    Console.WriteLine(reader["emName"]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
        private static void InsertData(string name, string address, int salary, int dept)
        {
            string query = $"insert into Myfirst values('{name}','{address}',{salary},{dept})";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Employee inserted succesfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }
        static List<EmpData> getAllEmployee()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRSELECT, con);
           
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var emp1 = new EmpData
                    {
                        Empid = Convert.ToInt32(reader[0]),
                        Empname = Convert.ToString(reader[1]),
                        Empadd = Convert.ToString(reader[2]),
                        EMpsala = Convert.ToInt32(reader[3]),
                        DeptId = Convert.IsDBNull(reader[4]) ? 1 : Convert.ToInt32(reader[4])
                    };
                    records.Add(emp1);
                }


            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return records;
        }
        
        static void UpdateRecord(int v1,EmpData emp)
        {
            string query = $"update Myfirst set emName = '{emp.Empname}',empAddress='{emp.Empadd}',empSalary={emp.EMpsala},DeptId ='{emp.DeptId}' where EmpId ='{v1}'";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Employee Updated succesfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        static void DeleteRecord(int v1,EmpData emp)
        {
            string query = $"Delete form Myfirst where {emp.Empid} = '{v1}'";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Employee Deleted succesfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
           // SqlParameter
            do
            {
                int choice = MenuDrive();
                //int choice = Utilities.GetInteger("Enter your choice : ");
                switch (choice)
                {
                    case 1: //Add
                        string name = Utilities.GetString("Enter the name");
                        string address = Utilities.GetString("Enter the addres");
                        int salary = Utilities.GetInteger("Enter the salary");
                        int Depid = Utilities.GetInteger("Enter the depid");
                    InsertData(name, address, salary, Depid);
                        break;
                    case 2: //Update 
                        int id = Utilities.GetInteger("Enter the id to check");
                        List<EmpData> empdata = new List<EmpData>();
                        empdata = getAllEmployee();
                        EmpData empup = new EmpData { Empid = 1100, Empname = "jay ", Empadd = "Chenni", EMpsala = 900000 };
                        foreach (var item in empdata)
                        {
                            if (item.Empid == id)
                            {
                                UpdateRecord(id, empup);
                            }
                        }
                        break;
                    case 3: //Delete data
                        int idx = Utilities.GetInteger("Enter the id to Delete");
                        List<EmpData> empdatas = new List<EmpData>();
                        EmpData empups = new EmpData();
                        DeleteRecord(idx,empups);
                        break;
                    case 4: //Display 
                        var records = getAllEmployee();
                        // foreach (var items in records)
                        foreach (var items in records)
                        {
                            Console.WriteLine($"The Employee {items.Empname} and his salary is {items.EMpsala} and his id {items.Empid}");
                        }
                        break;
                    default:
                        break;
                }


            } while (true);






            ReaddAllRecord();
            
            // UpdateRecord(Depid,name,address,)
          
           

        }

        private static int MenuDrive()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------MENUDRIVE------------");
            Console.WriteLine("To add the employee -----Press 1");
            Console.WriteLine("To Update the employee --Press 2");
            Console.WriteLine("To Delete the employee --Press 3");
            Console.WriteLine("To Display the employee -Press 4");
            Console.WriteLine("To Exit -----------------Press 5");
            Console.WriteLine("Enter your Choice");
           int c = int.Parse(Console.ReadLine());
            return c;
        }
    }

   
}
// As 70% of the code is reused in our fuction we need 2 apis for the dml (insert , Delete ,and Update) and DQL(Select) 
// create 2 Apis that will take the required inputs and perform the operation and call it in main method,
