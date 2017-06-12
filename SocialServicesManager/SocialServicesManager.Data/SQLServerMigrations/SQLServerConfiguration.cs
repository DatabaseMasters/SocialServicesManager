namespace SocialServicesManager.Data.SQLServerMigrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class SQLServerConfiguration : DbMigrationsConfiguration<SocialServicesManager.Data.SQLServerDbContext>
    {
        public SQLServerConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.MigrationsDirectory = @"SQLServerMigrations";
        }

        protected override void Seed(SQLServerDbContext context)
        {
            context.Genders.AddOrUpdate(
                g => g.Name,
                new Gender { Name = "Male" },
                new Gender { Name = "Female" },
                new Gender { Name = "Undefined" });
        }
    }
}
