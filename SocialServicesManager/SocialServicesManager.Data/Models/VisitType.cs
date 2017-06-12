using SocialServicesManager.Data.DataValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialServicesManager.Data.Models
{
    public class VisitType
    {
        public int Id { get; set; }

        [Index("IX_VisitUnique", IsUnique = true)]
        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }
    }
}
