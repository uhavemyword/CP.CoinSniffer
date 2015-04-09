using System.IO;
using System.Xml.Serialization;

namespace CP.CoinSniffer.Common
{
    public class XmlHelper
    {
        public static void Serialize<T>(string filePath, T obj)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(stream, obj);
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            T val;
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                val = (T)xs.Deserialize(stream);
            }
            return val;
        }
    }
}
