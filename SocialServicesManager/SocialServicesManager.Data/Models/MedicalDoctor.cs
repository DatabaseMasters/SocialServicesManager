using SocialServicesManager.Data.DataValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class MedicalDoctor
    {
        public int Id { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string FirstName { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string LastName { get; set; }

        [MaxLength(ModelsConstraints.PhoneNumberLength), MinLength(ModelsConstraints.PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Specialty { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}