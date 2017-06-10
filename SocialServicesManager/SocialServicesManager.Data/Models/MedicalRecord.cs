using SocialServicesManager.Data.DataValidation;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }

        [MaxLength(ModelsConstraints.DescriptionMaxLength), MinLength(ModelsConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        public bool Deleted { get; set; }

        public int ChildId { get; set; }

        public virtual MedicalDoctor MedicalDoctor { get; set; }
    }
}
