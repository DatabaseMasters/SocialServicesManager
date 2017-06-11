using SocialServicesManager.Data.DataValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialServicesManager.Data.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        [Index("IX_GenderUnique", IsUnique = true)]
        public string Name { get; set; }
    }
}