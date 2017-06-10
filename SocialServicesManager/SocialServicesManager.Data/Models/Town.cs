using SocialServicesManager.Data.Models.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class Town
    {
        public Town()
        {
            this.Addresses = new List<Address>();
        }

        public int Id { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        public virtual Municipality Municipality { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}