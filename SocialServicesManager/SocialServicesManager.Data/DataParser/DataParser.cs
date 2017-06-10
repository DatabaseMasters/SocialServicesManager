using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ProcessJSON.Core
{
    public static class DataParser
    {
        public static T ParseJson<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(text);
        }

        public static T ParseXML<T>(string filePath, string root)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = root;

            XmlSerializer serializer = new XmlSerializer(typeof(T), xmlRoot);

            XmlReader reader = XmlReader.Create(filePath);

            return (T)serializer.Deserialize(reader);
        }
    }
}
