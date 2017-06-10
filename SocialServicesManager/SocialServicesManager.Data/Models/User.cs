using SocialServicesManager.Data.DataValidation;
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

        [MaxLength(ModelsConstraints.UsernameMaxLength), MinLength(ModelsConstraints.UsernameMinLength)]
        public string UserName { get; set; }

        [MaxLength(ModelsConstraints.PasswordMaxLength), MinLength(ModelsConstraints.PasswordMinLength)]
        public string Password { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string FirstName { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string LastName { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<Family> Families { get; set; }
    }
}