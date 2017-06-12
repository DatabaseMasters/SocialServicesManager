using SocialServicesManager.Data.DataValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class Address
    {
        public Address()
        {
            this.People = new List<FamilyMember>();
        }

        public int Id { get; set; }

        [MaxLength(ModelsConstraints.AddressNameMaxLenght), MinLength(ModelsConstraints.AddressNameMinLenght)]
        public string Name { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<FamilyMember> People { get; set; }
    }
}