using SocialServicesManager.Data.DataValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class Family
    {
        public Family()
        {
            this.Deleted = false;
            this.FamilyMembers = new List<FamilyMember>();
            this.Children = new List<Child>();
        }

        public int Id { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        public bool Deleted { get; set; }

        public virtual User AssignedStaffMember { get; set; }

        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}