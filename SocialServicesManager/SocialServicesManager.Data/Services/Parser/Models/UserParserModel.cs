using SocialServicesManager.Data.Models;
using System;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("User"), XmlType("User")]
    public class UserParserModel
    {
        [XmlElement("UserName")]
        public string UserName { get; set; }

        [XmlElement("Password")]
        public string Password { get; set; }

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Deleted")]
        public bool Deleted { get; set; }

        public User ParseToUser()
        {
            return new User
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Password = this.Password,
                Deleted = this.Deleted,
            };
        }
    }
}
