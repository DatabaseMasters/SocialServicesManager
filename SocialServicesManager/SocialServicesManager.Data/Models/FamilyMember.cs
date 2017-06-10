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

        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        public bool Deleted { get; set; }

        public Gender Gender { get; set; }

        public virtual Address Address { get; set;  }

        public virtual Family Family {get; set; }                
    }
}
