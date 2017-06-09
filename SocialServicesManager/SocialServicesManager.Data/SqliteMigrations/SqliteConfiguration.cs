namespace SocialServicesManager.Data.SqliteMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;

    internal sealed class SqliteConfiguration : DbMigrationsConfiguration<SocialServicesManager.Data.SqliteDbContext>
    {
        public SqliteConfiguration()
        {
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"SqliteMigrations";
        }

        protected override void Seed(SocialServicesManager.Data.SqliteDbContext context)
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
