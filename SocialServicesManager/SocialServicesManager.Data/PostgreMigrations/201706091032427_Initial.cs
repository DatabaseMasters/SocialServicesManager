namespace SocialServicesManager.Data.PostgreMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        FamilyId = c.Int(nullable: false),
                        VisitType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VisitTypes", t => t.VisitType_Id)
                .Index(t => t.VisitType_Id);
            
            CreateTable(
                "dbo.VisitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "VisitType_Id", "dbo.VisitTypes");
            DropIndex("dbo.Visits", new[] { "VisitType_Id" });
            DropTable("dbo.VisitTypes");
            DropTable("dbo.Visits");
        }
    }
}
