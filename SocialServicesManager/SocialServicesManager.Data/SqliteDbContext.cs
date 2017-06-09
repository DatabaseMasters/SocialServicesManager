using SocialServicesManager.Data.SqliteMigrations;
using SocialServicesManager.Models;
using System.Data.Entity;

namespace SocialServicesManager.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext() : base("SqliteConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqliteDbContext, SqliteConfiguration>(true));
        }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<MedicalDoctor> MedicalDoctors { get; set; }
    }
}
