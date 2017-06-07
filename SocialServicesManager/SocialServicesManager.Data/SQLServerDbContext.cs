using SocialServicesManager.Models;
using System.Data.Entity;

namespace SocialServicesManager.Data
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext() : base("SQLConnection")
        {
           
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Family> Families { get; set; }
            
        public DbSet<FamilyMember> FamilyMembers { get; set; }

        public DbSet<Child> Children { get; set; }

        public DbSet<Address> Addresses { get; set; }

    }
}
