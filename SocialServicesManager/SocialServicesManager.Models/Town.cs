namespace SocialServicesManager.Models
{
    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Municipality Municipality { get; set; }
    }
}