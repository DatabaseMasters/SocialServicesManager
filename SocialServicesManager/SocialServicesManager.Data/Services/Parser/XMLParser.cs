using System.Xml;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser
{
    public static class XMLParser
    {
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
