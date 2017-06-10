using SocialServicesManager.Data.DataValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class Municipality
    {
        public Municipality()
        {
            this.Towns = new List<Town>();
        }

        public int Id { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}