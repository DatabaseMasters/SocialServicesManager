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

        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        public virtual Municipality Municipality { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}