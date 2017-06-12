using System.Data.Entity.Migrations;

namespace SocialServicesManager.Data.SQLServerMigrations
{    
    public partial class FixAddressconstraints : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Addresses", "Name", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.Addresses", "Name", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
