using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment_01
{
  /*  public class VenderInventory
    {
        public int VendId { get; set; }
        public string VendName { get; set; }
        public string VendProduct { get; set; }
    }*/
  public class VenderClass
    {
        static List<VenderInventory> storageVen = new List<VenderInventory>();
        const string STRCONNECTION = @"Data Source=W-674PY03-2;Initial Catalog=AjayDataBase;Persist Security Info=True;User ID=SA;Password=Password@123456-=";
        const string STRSELECT1 = "Select * from Vender";

      public  static void ReadAllRecord() // ------------> Done with first one 
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
        static List<VenderInventory> getProductDetails()
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
       public static void InsertDataVender(string name,string Vprd)
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
            string DeletePro = $"Delete form product where {p.VendId} = '{Vid}'";
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
        static void Main(string[] args)
        {
            Program ps = new Program();
            
        }
    }

}
