using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using System;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("Visit"), XmlType("Visit")]
    public class VisitParseModel
    {
        [XmlElement("Date")]
        public DateTime Date { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Deleted")]
        public bool Deleted { get; set; }

        [XmlElement("VisitType")]
        public string VisitType { get; set; }

        public Visit ParseToVisit(IDataFactory dataFactory)
        {
            return new Visit
            {
                Date = this.Date,
                Description = this.Description,
                Deleted = this.Deleted,
                VisitType = dataFactory.GetVisitType(this.VisitType)
            };
        }
    }
}