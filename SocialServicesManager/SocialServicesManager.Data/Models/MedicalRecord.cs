using SocialServicesManager.Data.DataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class MedicalRecord
    {
        public MedicalRecord()
        {
            this.MedicalDoctors = new List<MedicalDoctor>();
        }

        public int Id { get; set; }

        [DateInThePast]
        public DateTime Date { get; set; }

        public int ChildId { get; set; }
        
        [MaxLength(ModelsConstraints.DescriptionMaxLength), MinLength(ModelsConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        public virtual ICollection<MedicalDoctor> MedicalDoctors { get; set; }

        public bool Deleted { get; set; }
    }
}
