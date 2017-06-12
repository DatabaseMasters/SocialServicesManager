namespace SocialServicesManager.Data.SQLServerMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Uniqueusernamegender : DbMigration
    {
        public override void Up()
        {            
            this.CreateIndex("dbo.Users", "UserName", unique: true, name: "IX_UserNameUnique");
            this.CreateIndex("dbo.Genders", "Name", unique: true, name: "IX_GenderUnique");
        }
        
        public override void Down()
        {
            this.DropIndex("dbo.Genders", "IX_GenderUnique");
            this.DropIndex("dbo.Users", "IX_UserNameUnique");
        }
    }
}
