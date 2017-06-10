using System.Data.Entity.Infrastructure.Annotations;

namespace SocialServicesManager.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [StringLength(65)]
        [Index("IX_FirstNameLastName", 1, IsUnique = true)]
        public string Name { get; set; }
    }
}