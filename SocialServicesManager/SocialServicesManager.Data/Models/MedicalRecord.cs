using System.Collections.Generic;

namespace SocialServicesManager.Data.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Deleted { get; set; }

        public int ChildId { get; set; }

        public virtual MedicalDoctor MedicalDoctor { get; set; }
    }
}
