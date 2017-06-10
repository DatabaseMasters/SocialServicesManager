using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class VisitType
    {
        public int Id { get; set; }

        [MaxLength(50), MinLength(3)]
        public string Name { get; set; }
    }
}
