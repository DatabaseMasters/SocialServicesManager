using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class User
    {
        public User()
        {
            this.Deleted = false;
            this.Families = new List<Family>();
        }

        public int Id { get; set; }

        [MaxLength(50), MinLength(5)]
        public string UserName { get; set; }

        [MaxLength(50), MinLength(8)]
        public string Password { get; set; }

        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<Family> Families { get; set; }
    }
}