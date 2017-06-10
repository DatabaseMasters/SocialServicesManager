using System;

namespace SocialServicesManager.Data.Models
{
    public class Visit
    {
        public Visit()
        {
            this.Deleted = false;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public int FamilyId { get; set; }

        public bool Deleted { get; set; }

        public virtual VisitType VisitType { get; set; }
    }
}
