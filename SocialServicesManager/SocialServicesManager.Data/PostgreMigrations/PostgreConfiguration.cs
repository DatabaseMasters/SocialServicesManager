namespace SocialServicesManager.Data.PostgreMigrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class PostgreConfiguration : DbMigrationsConfiguration<SocialServicesManager.Data.PostgreDbContext>
    {
        public PostgreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"PostgreMigrations";
        }

        protected override void Seed(SocialServicesManager.Data.PostgreDbContext context)
        {
            context.VisitTypes.AddOrUpdate(v => v.Name,
                new VisitType { Name = "HomeVisit" },
                new VisitType { Name = "OfficeVisit" },
                new VisitType { Name = "HospitalVisit" });
        }
    }
}
