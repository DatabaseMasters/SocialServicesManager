using System;

namespace SocialServicesManager.Models
{
    public class Child
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Gender Gender { get; set;  }

        public DateTime BirthDate { get; set; }

        public virtual Family Family { get; set; }

    }
}
