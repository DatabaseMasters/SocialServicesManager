namespace SocialServicesManager.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Town Town { get; set; }
    }
}