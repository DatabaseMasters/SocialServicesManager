namespace SocialServicesManager.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public virtual Address Address { get; set;  }

        public virtual Family Family {get; set; }                
    }
}
