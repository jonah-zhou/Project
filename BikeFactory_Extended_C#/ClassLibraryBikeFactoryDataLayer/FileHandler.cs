using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using ClassLibraryBikeFactoryBusLayer;

namespace ClassLibraryBikeFactoryDataLayer
{
    public class FileHandler
    {
        private static String binFilePath = @"../../Data/bikes.bin";
        public static String xmlFilePath = @"../../Data/bikes.xml";

        public static void WriteIntoSerializedFile(List<Bike> listOfBikes)
        {
            FileStream fs = new FileStream(binFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, listOfBikes);
            fs.Close();
        }
        public static List<Bike> ReadFromSerializedFile()
        {
            List<Bike> listOfBikes = new List<Bike>();

            if (File.Exists(binFilePath))
            {
                FileStream fs = new FileStream(binFilePath, FileMode.Open, FileAccess.Read);

                BinaryFormatter bf = new BinaryFormatter();

                listOfBikes = (List<Bike>)bf.Deserialize(fs);

                fs.Close();
            }

            return listOfBikes;
        }

        public static void WriteToXmlFile(List<Bike> listOfBikes)
        {

            XmlWriter xw = XmlWriter.Create(xmlFilePath);

            XmlSerializer xs = new XmlSerializer(typeof(List<Bike>));

            xs.Serialize(xw, listOfBikes);

            xw.Close();

        }
        public static List<Bike> ReadFromXmlFile()
        {
            List<Bike> listOfBikes = null;

            StreamReader sr = new StreamReader(xmlFilePath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Bike>));

            listOfBikes = (List<Bike>)xmlSerializer.Deserialize(sr);

            sr.Close();

            return listOfBikes;
        }

    }

}