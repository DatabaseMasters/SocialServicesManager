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

            // var sofia = new Municipality { Name = "Sofia" };
            // var plovdiv = new Municipality { Name = "Ploviv" };
            // var varna = new Municipality { Name = "Varna" };
            // var tarnovo = new Municipality { Name = "Veliko Tarnovo" };
            // 
            // context.Municipalities.AddOrUpdate(m => m.Name,
            //     sofia,
            //     plovdiv,
            //     varna,
            //     tarnovo
            //     );
            // 
            // context.Towns.AddOrUpdate(t => t.Name,
            //     new Town
            //     {
            //         Name = "Sofia",
            //         Municipality = sofia
            //     },
            //     new Town
            //     {
            //         Name = "Pernik",
            //         Municipality = sofia
            //     },
            //     new Town
            //     {
            //         Name = "Plovdiv",
            //         Municipality = plovdiv
            //     },
            //     new Town
            //     {
            //         Name = "Varna",
            //         Municipality = varna
            //     },
            //     new Town
            //     {
            //         Name = "Veliko Tarnovo",
            //         Municipality = tarnovo
            //     });
        }
    }
}
