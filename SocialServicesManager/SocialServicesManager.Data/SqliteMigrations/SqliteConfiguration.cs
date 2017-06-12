namespace SocialServicesManager.Data.SqliteMigrations
{
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;

    internal sealed class SqliteConfiguration : DbMigrationsConfiguration<SocialServicesManager.Data.SqliteDbContext>
    {
        public SqliteConfiguration()
        {
            this.SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
            this.AutomaticMigrationsEnabled = false;
            this.MigrationsDirectory = @"SqliteMigrations";
        }

        protected override void Seed(SocialServicesManager.Data.SqliteDbContext context)
        {
        }
    }
}
