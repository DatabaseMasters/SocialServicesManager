namespace SocialServicesManager.Data.PostgreMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initilize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Visits", "VisitType_Id", c => c.Int());
            CreateIndex("dbo.Visits", "VisitType_Id");
            AddForeignKey("dbo.Visits", "VisitType_Id", "dbo.VisitTypes", "Id");
            DropColumn("dbo.Visits", "VisitType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visits", "VisitType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Visits", "VisitType_Id", "dbo.VisitTypes");
            DropIndex("dbo.Visits", new[] { "VisitType_Id" });
            DropColumn("dbo.Visits", "VisitType_Id");
            DropTable("dbo.VisitTypes");
        }
    }
}
