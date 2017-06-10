using SocialServicesManager.Data.DataValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class Child
    {
        public Child()
        {
            this.Deleted = false;
        }

        public int Id { get; set; }

        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        public bool Deleted { get; set; }

        public virtual Gender Gender { get; set;  }

        [DateInThePast]
        public DateTime? BirthDate { get; set; }

        public virtual Family Family { get; set; }
    }
}
