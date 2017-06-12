namespace SocialServicesManager.Data.PostgreMigrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class PostgreConfiguration : DbMigrationsConfiguration<SocialServicesManager.Data.PostgreDbContext>
    {
        public PostgreConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.MigrationsDirectory = @"PostgreMigrations";
        }

        protected override void Seed(PostgreDbContext context)
        {
            context.VisitTypes.AddOrUpdate(
                v => v.Name,
                new VisitType { Name = "HomeVisit" },
                new VisitType { Name = "OfficeVisit" },
                new VisitType { Name = "HospitalVisit" });
        }
    }
}
