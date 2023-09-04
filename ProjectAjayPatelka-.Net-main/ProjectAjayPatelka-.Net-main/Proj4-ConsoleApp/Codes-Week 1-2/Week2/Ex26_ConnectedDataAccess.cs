using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Day_4.Week2
{
    
    class Ex26_ConnectedDataAccess
    {
        const string STRSELECT = " Select * from Myfirst";
        const string STRCONNECTION = @"Data Source=W-674PY03-2;Persist Security Info=True;User ID=SA;Password=Password@123456-=";
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
                while(reader.Read())
                {
                    Console.WriteLine(reader["emName"]);
                }
                
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
        private static void InsertData(string name , string address , int salary , int dept)
        {
            string query = $"Insert into Myfirst values ({name} , {address} , {salary} ,{dept})";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows == 1)
                {
                    Console.WriteLine("Employee inserted succesfully");
                }
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }finally
            {
                con.Close();
            }


        }

        static void Main(string[] args)
        {
            ReaddAllRecord();
            string name = Utilities.GetString("Enter the name");
            string address = Utilities.GetString("Enter the addres");
            int salary  = Utilities.GetInteger("Enter the salary");
            int Depid = Utilities.GetInteger("Enter the depid");
            InsertData(name,address,salary,Depid);

                
        }
    }
}
