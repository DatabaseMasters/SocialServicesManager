using SocialServicesManager.Data.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class FamilyMember
    {
        public FamilyMember()
        {
            this.Deleted = false;
        }

        public int Id { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string FirstName { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string LastName { get; set; }

        public bool Deleted { get; set; }

        public Gender Gender { get; set; }

        public virtual Address Address { get; set;  }

        public virtual Family Family {get; set; }                
    }
}
