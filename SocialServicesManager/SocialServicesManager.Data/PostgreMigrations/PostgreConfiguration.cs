namespace SocialServicesManager.Data.PostgreMigrations
{
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
