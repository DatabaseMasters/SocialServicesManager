using SocialServicesManager.Data.Models;
using System.Data.Entity;

namespace SocialServicesManager.Data
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext() : base("PostgreConnection")
        {
        }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<VisitType> Visittypes { get; set; }
    }
}
