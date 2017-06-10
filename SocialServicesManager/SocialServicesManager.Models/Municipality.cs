using System.Collections.Generic;

namespace SocialServicesManager.Models
{
    public class Municipality
    {
        public Municipality()
        {
            this.Towns = new List<Town>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}