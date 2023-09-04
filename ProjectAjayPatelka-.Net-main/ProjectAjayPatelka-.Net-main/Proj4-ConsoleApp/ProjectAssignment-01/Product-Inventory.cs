using Proj1_SampleConApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

/*create table product (
ProName nvarchar(50),
	ProId int primary key identity(1000,1),
	procuctstock int 
)
drop table product
create table Vender(
	VendId int identity(1,1) primary key,
    VendName nvarchar(50),
)
Alter table product
Add VendId int null 
REFERENCES Vender(VendId)

insert into Vender values('Akshay')
select* from Vender
insert into product values('iPhone-Mobile',10000,1);
select* from product*/
namespace ProjectAssignment_01
{

    internal class productInventery
    {
        public string ProName { get; set; }
        public int ProId { get; set; }
        public int procuctstock { get; set; }
        public int VendId { get; set; }
    }
    public class VenderInventory
    {
        public int VendId { get; set; }
        public string VendName { get; set; }
        public string VendProduct { get; set; }
    }


    class Program
    {
        const string filename = @"C:\Users\apatelka\source\repos\ProjectData-01\ProjectAssignment-01\Menu.txt";
       
        static List<productInventery> storage = new List<productInventery>();
        static List<VenderInventory> storageVen = new List<VenderInventory>();
        const string STRCONNECTION = @"Data Source=W-674PY03-2;Initial Catalog=AjayDataBase;Persist Security Info=True;User ID=SA;Password=Password@123456-=";
        const string STRSELECT = "Select * from product";
        const string STRSELECT1 = "Select * from Vender";

        public static object ConfigurationManager { get; private set; }

   

        static void ReadAllRecord() // ------------> Done with first one 
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand();
            //In this we are reading the records and adding stock data and deleting it;
            cmd.CommandText = STRSELECT;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader!=null)
                {
                    Console.WriteLine(reader["ProName"]);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //Get All ProductDelatils
        static List<productInventery> getProductDetails()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRSELECT, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                var pro1 = new productInventery
                {
                    ProName = Convert.ToString(reader[0]),
                    ProId = Convert.ToInt32(reader[1]),
                    procuctstock = Convert.ToInt32(reader[2]),
                    VendId = Convert.ToInt32(reader[3])
                };
                storage.Add(pro1);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return storage;
        }

            static void InsertDataProduct(string name, int pstock , int vid)
            {
            string InsertProquery = $"insert into product values('{name}','{pstock}','{vid}')";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(InsertProquery, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows == 1)
                {
                    Console.WriteLine("Data is Inserted Successfully");
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
        
        static void DeleteFrompro(int pid, productInventery p)
        {
            string DeletePro = $"delete from product where {p.ProId}='{pid}'";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(DeletePro, con);
            try
            {
                con.Open();
                int row = cmd.ExecuteNonQuery();
                if(row == 1)
                {
                    Console.WriteLine("The Product Data is Deleted".ToUpper());
                 
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
        static void UpdateProduct(int pid , productInventery p)
        {
            string UpdQuery = $"update product set Productname = '{p.ProName}',PrductId='{p.ProId}',PrductStock='{p.procuctstock}',VenderId ='{p.VendId}' where {p.ProId} = '{pid}'";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(UpdQuery, con);
            try
            {
                con.Open();
                int row = cmd.ExecuteNonQuery();
                if(row == 1)
                {
                    Console.WriteLine("Update Done Succssfully");
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
        static void Main(string[] args)
        {

            //InsertDataProduct("laptop", 90, 1);
            do
            {
                //FileStream fs = new FileStream(Filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                var content = File.ReadAllText(filename);
                Console.WriteLine(content);
                Console.WriteLine("-----------------------------Welcome to Product-Inventory---------------------------".ToUpper());
                Console.WriteLine("Are You an Vender or Buyer\nPress 1 Vender Press 2 Product Detail".ToUpper());
                int choice = int.Parse(Console.ReadLine());
                FirstChoice(choice);

            } while (true);
           // InsertDataProduct
        }
        public static void ReadAllRecordV() // ------------> Done with first one 
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand();
            //In this we are reading the records and adding stock data and deleting it;
            cmd.CommandText = STRSELECT1;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader != null)
                {
                    Console.WriteLine(reader["VendName"]);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        static List<VenderInventory> getProductDetailsv()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRSELECT1, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                var Ven1 = new VenderInventory
                {
                    VendId = Convert.ToInt32(reader[0]),
                    VendName = Convert.ToString(reader[1]),
                    VendProduct = Convert.ToString(reader[2]),
                };
                storageVen.Add(Ven1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return storageVen;
        }
        public static void InsertDataVender(string name, string Vprd)
        {
            string InsertProquery = $"insert into Vender values('{name}','{Vprd}')";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(InsertProquery, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Data is Inserted to Vender Successfully");
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
        static void DeleteFromVen(int Vid, VenderInventory p)
        {
            string DeletePro = $"Delete from Vender where {p.VendId} = '{Vid}'";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(DeletePro, con);
            try
            {
                con.Open();
                int row = cmd.ExecuteNonQuery();
                if (row == 1)
                {
                    Console.WriteLine("The Vender Data is Deleted".ToUpper());

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
        static void UpdateProduct(int vid, VenderInventory p)
        {
            string UpdQuery = $"update product set VenderName = '{p.VendName}',VenderProduct ='{p.VendProduct}' where {p.VendId} = '{vid}'";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(UpdQuery, con);
            try
            {
                con.Open();
                int row = cmd.ExecuteNonQuery();
                if (row == 1)
                {
                    Console.WriteLine("Update Done Succssfully");
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
        public static void FirstChoice(int choice)
        {
           
            switch (choice)
            {
                case 1: Console.WriteLine("-----------------Welcome to Vender Details-----------------------".ToUpper());
                    Console.WriteLine("Want to be Vender 1.SignIn 2.SignOut 3.All Venders".ToUpper());
                    int choice2 = int.Parse(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            string vname = Utilities.GetString("Enter the Vender name".ToUpper());
                            string Vproduct = Utilities.GetString("Enter the Product you have".ToUpper());
                            //int Vid = Utilities.GetInteger("Enter the VenderId");
                            InsertDataVender(vname, Vproduct);
                            break;
                        case 2:
                            int idx = Utilities.GetInteger("Enter the Vender id to Delete");
                            List<VenderInventory> Vendata = new List<VenderInventory>();
                            VenderInventory Ve1 = new VenderInventory();
                            DeleteFromVen(idx, Ve1);
                            break;
                            
                        case 3:
                            var records = getProductDetailsv();
                            // foreach (var items in records)
                            foreach (var items in records)
                            {
                                Console.WriteLine($"The Vender id {items.VendId} and its name {items.VendName} and stock {items.VendProduct}");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 2: Console.WriteLine("Welcome to Product Details".ToUpper());
                    Console.WriteLine("Enter 1.Add Product 2.Delete Product 3.Updtae 4.Display");
                    int choice3 = int.Parse(Console.ReadLine());
                    switch (choice3)
                    {
                        case 1:
                            string pname = Utilities.GetString("Enter the Product name".ToUpper());
                            int Pstock = Utilities.GetInteger("Enter the Pstock you have".ToUpper());
                            int Vid = Utilities.GetInteger("Enter the VenderId");
                            InsertDataProduct(pname, Pstock, Vid);
                            break;
                        case 2:
                            int idx = Utilities.GetInteger("Enter the Pid to Delete");
                            List<productInventery> empdatas = new List<productInventery>();
                            productInventery Prod1 = new productInventery();
                            DeleteFrompro(idx, Prod1);
                            break;
                        case 3:
                            int id = Utilities.GetInteger("Enter the id to check");
                            List<productInventery> empdata = new List<productInventery>();
                            empdata = getProductDetails();
                            productInventery prod = new productInventery();
                            var foundrec = storage.Find(delegate (productInventery data) {
                                return data.ProId == id;
                            });
                            UpdateProduct(id, foundrec);
                            break;
                        case 4:
                            var records = getProductDetails();
                            // foreach (var items in records)
                            foreach (var items in records)
                            {
                                Console.WriteLine($"The Product id {items.ProId} and its name {items.ProName} and stock {items.procuctstock}");
                            }
                            break;
                        default:
                            break;
                    }
                    break;


                default:
                    break;
            }
        }
    }
}
//1.Vender will do 