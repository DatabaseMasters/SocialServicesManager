using SocialServicesManager.Data.Models;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("Address"), XmlType("Address")]
    public class AddressParserModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Town")]
        public TownParserModel Town { get; set; }

        public Address ParseToAddress()
        {
            return new Address
            {
                Name = this.Name,
                Town = this.Town.ParseToTown(),
            };
        }
    }
}
