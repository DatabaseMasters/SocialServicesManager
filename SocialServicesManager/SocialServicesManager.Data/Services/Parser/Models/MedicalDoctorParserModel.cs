using SocialServicesManager.Data.Models;
using System;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("MedicalDoctor"), XmlType("MedicalDoctor")]
    public class MedicalDoctorParserModel
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("Specialty")]
        public string Specialty { get; set; }

        [XmlElement("Deleted")]
        public bool Deleted { get; set; }

        public MedicalDoctor ParseToMedicalDoctor()
        {
            return new MedicalDoctor
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                Specialty = this.Specialty,
                Deleted = this.Deleted,
            };
        }
    }
}
