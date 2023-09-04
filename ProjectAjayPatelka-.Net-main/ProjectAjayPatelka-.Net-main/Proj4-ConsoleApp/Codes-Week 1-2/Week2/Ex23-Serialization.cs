using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization.Advanced;
using System.Xml.Serialization;

namespace Proj1_SampleConApp.Week_2
{
    [Serializable]
    public class Data
    {
        public int DataNo { get; set; }
        public string DataName { get; set; }
        public DateTime BillDate { get; set; } = DateTime.Now;
        public int Amount { get; set; }
        public override string ToString()
        {
            return $"Amount of Rs {Amount} has been spent for {DataName} on {BillDate.ToLongDateString()}";
        }
    }
    class Ex23Serialization
    {
        static void Main(string[] args)
        {
            // MainMenu();
            //serialization();
            //deserialization();
            //xmlserialize();
            xmlDeserialize();
        }

        private static void xmlDeserialize()
        {
            Data data = createData();
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Read);
            XmlSerializer fm = new XmlSerializer(typeof(Data));
            Data extract = fm.Deserialize(fs) as Data;
            Console.WriteLine(extract.ToString());

        }

        private static void xmlserialize()
        {
            Data data = createData();
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer fm = new XmlSerializer(typeof(Data));
           
            fm.Serialize(fs, data);
            fs.Close();
        }

        private static void MainMenu()
        {
            
        }

        private static void deserialization()
        {
            FileStream fs = new FileStream("Temp.Bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Data deserializedData = bf.Deserialize(fs) as Data;
            Console.WriteLine(deserializedData.DataName);

        }



        private static void serialization()
        {
            Data dt = createData();
            string fileLocation = "Temp.Bin";//what to serialize
            //Where to serialize
            FileStream fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write);
            //Binary serialization for saving
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, dt);
            fs.Close();
        }



        private static Data createData()
        {

            int id = 123;
            string name = "Food at Cafeteria";
            int amount = 250;
            DateTime dt = DateTime.Now.AddDays(-146);
            return new Data
            {
                Amount = amount,
                DataName = name,
                DataNo = id,
                BillDate = dt
            };
        }
    }
}

