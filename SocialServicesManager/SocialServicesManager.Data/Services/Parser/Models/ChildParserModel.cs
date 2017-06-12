using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("Child"), XmlType("Child")]
    public class ChildParserModel
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Deleted")]
        public bool Deleted { get; set; }

        [XmlElement("Gender")]
        public string Gender { get; set; }

        [XmlElement("BirthDate")]
        public DateTime? BirthDate { get; set; }

        [XmlArray(ElementName = "MedicalRecords")]
        [XmlArrayItem(ElementName = "MedicalRecord")]
        public List<MedicalRecordParserModel> MedicalRecords { get; set; }

        public Child ParseToChild(IDataFactory dataFactory)
        {
            return new Child
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Deleted = this.Deleted,
                BirthDate = this.BirthDate,
                Gender = dataFactory.GetGender(this.Gender),
            };
        }
    }
}
