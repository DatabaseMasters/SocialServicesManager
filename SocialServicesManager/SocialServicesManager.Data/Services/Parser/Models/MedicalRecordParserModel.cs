using SocialServicesManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SocialServicesManager.Data.Services.Parser.Models
{
    [XmlRoot("MedicalRecord"), XmlType("MedicalRecord")]
    public class MedicalRecordParserModel
    {
        [XmlElement("Date")]
        public DateTime Date { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Deleted")]
        public bool Deleted { get; set; }

        [XmlArray(ElementName = "MedicalDoctors")]
        [XmlArrayItem(ElementName = "MedicalDoctor")]
        public virtual List<MedicalDoctorParserModel> MedicalDoctors { get; set; }

        public MedicalRecord ParseToMedicalRecord()
        {
                return new MedicalRecord
                {
                    Date = this.Date,
                    Description = this.Description,
                    Deleted = this.Deleted,
                    MedicalDoctors = this.MedicalDoctors.Select(m => m.ParseToMedicalDoctor()).ToList(),
                };
        }
    }
}
