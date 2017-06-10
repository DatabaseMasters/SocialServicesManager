using System.Collections.Generic;

namespace SocialServicesManager.Data.Models
{
    public class MedicalDoctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}