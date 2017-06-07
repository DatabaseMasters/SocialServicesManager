using System;

namespace SocialServicesManager.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public int FamilyId { get; set; }

        public virtual VisitType VisitType { get; set; }
    }
}
