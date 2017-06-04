namespace SocialServicesManager.Models
{
    public class Family
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual User AuthorizedStaffMember { get; set; }
    }
}