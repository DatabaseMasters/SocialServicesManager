using SocialServicesManager.Data.DataValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class Visit
    {
        public Visit()
        {
            this.Deleted = false;
        }

        public int Id { get; set; }

        [DateInThePast]
        public DateTime Date { get; set; }

        [MaxLength(ModelsConstraints.DescriptionMaxLength), MinLength(ModelsConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public int FamilyId { get; set; }

        public bool Deleted { get; set; }

        public virtual VisitType VisitType { get; set; }
    }
}
