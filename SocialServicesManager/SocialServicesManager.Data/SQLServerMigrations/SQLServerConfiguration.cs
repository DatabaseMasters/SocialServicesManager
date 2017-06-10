namespace SocialServicesManager.Data.SQLServerMigrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SQLServerConfiguration : DbMigrationsConfiguration<SocialServicesManager.Data.SQLServerDbContext>
    {
        public SQLServerConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"SQLServerMigrations";
        }

        protected override void Seed(SocialServicesManager.Data.SQLServerDbContext context)
        {
            context.Genders.AddOrUpdate(g => g.Name,
                new Gender { Name = "Male" },
                new Gender { Name = "Female" },
                new Gender { Name = "Undefined" });
        }
    }
}
