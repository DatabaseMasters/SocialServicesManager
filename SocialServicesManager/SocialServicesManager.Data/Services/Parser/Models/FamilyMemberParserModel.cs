using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("FamilyMember"), XmlType("FamilyMember")]
    public class FamilyMemberParserModel
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Deleted")]
        public bool Deleted { get; set; }

        [XmlElement("Gender")]
        public string Gender { get; set; }

        [XmlElement("Address")]
        public virtual AddressParserModel Address { get; set; }

        public FamilyMember ParseToFamilyMember(IDataFactory dataFactory)
        {
            return new FamilyMember
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Deleted = this.Deleted,
                Gender = dataFactory.GetGender(this.Gender),
                Address = this.Address.ParseToAddress(),
            };
        }
    }
}
