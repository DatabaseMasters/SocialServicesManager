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

        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}