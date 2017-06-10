using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
    }
}