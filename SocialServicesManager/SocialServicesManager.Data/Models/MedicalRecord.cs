using SocialServicesManager.Data.DataValidation;
using SocialServicesManager.Data.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }

        [DateInThePast]
        public DateTime Date { get; set; }

        [MaxLength(ModelsConstraints.DescriptionMaxLength), MinLength(ModelsConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        public bool Deleted { get; set; }

        public int ChildId { get; set; }

        public virtual ICollection<MedicalDoctor> MedicalDoctors { get; set; }
    }
}
