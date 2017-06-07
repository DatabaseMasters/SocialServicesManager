using SocialServicesManager.Models;
using System.Data.Entity;

namespace SocialServicesManager.Data
{
    public class PostgreDBContext : DbContext
    {
        public PostgreDBContext() : base("PostgreConnection")
        {
        }

        public DbSet<Visit> Visits { get; set; }
    }
}
