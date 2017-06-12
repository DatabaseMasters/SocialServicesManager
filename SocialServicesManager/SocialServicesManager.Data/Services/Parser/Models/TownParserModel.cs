using SocialServicesManager.Data.Models;
using System;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("Town"), XmlType("Town")]
    public class TownParserModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Municipality")]
        public string Municipality { get; set; }

        public Town ParseToTown()
        {
            return new Town
            {
                Name = this.Name,
                Municipality = new Municipality { Name = this.Municipality },
            };
        }
    }
}
