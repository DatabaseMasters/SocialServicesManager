using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("Family"), XmlType("Family")]
    public class FamilyParserModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Deleted")]
        public bool Deleted { get; set; }

        [XmlElement("AssignedStaffMember")]
        public virtual UserParserModel AssignedStaffMember { get; set; }

        [XmlArray(ElementName = "FamilyMemebers")]
        [XmlArrayItem(ElementName = "FamilyMemeber")]
        public List<FamilyMemberParserModel> FamilyMemebers { get; set; }

        [XmlArray(ElementName = "Children")]
        [XmlArrayItem(ElementName = "Child")]
        public List<ChildParserModel> Children { get; set; }

        [XmlArray(ElementName = "Visits")]
        [XmlArrayItem(ElementName = "Visit")]
        public List<VisitParseModel> Visits { get; set; }

        public Family ParseToFamily(IDataFactory dataFactory)
        {
            return new Family
            {
                Name = this.Name,
                Deleted = this.Deleted,
                AssignedStaffMember = this.AssignedStaffMember.ParseToUser(),
                FamilyMembers = this.FamilyMemebers.Select(m => m.ParseToFamilyMember(dataFactory)).ToList(),
                Children = this.Children.Select(c => c.ParseToChild(dataFactory)).ToList()
            };
        }
    }
}
