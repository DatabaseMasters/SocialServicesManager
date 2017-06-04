using System.Data.Entity;

namespace SocialServicesManager.Core
{
    public class SocialServicesDbContext : DbContext
    {
        public SocialServicesDbContext() : base("SocialServicesConnection")
        {

        }        
    }
}
