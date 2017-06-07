namespace SocialServicesManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitilizePostgreDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Municipalities", newName: "VisitTypes");
            DropForeignKey("dbo.Towns", "Municipality_Id", "dbo.Municipalities");
            DropForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Families", "AuthorizedStaffMember_Id", "dbo.Users");
            DropForeignKey("dbo.Children", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.FamilyMembers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            DropIndex("dbo.Addresses", new[] { "Town_Id" });
            DropIndex("dbo.Towns", new[] { "Municipality_Id" });
            DropIndex("dbo.Children", new[] { "Family_Id" });
            DropIndex("dbo.Families", new[] { "AuthorizedStaffMember_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Address_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
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
            
            DropTable("dbo.Addresses");
            DropTable("dbo.Towns");
            DropTable("dbo.Children");
            DropTable("dbo.Families");
            DropTable("dbo.Users");
            DropTable("dbo.FamilyMembers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Address_Id = c.Int(),
                        Family_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorizedStaffMember_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Family_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Municipality_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Town_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Visits", "VisitType_Id", "dbo.VisitTypes");
            DropIndex("dbo.Visits", new[] { "VisitType_Id" });
            DropTable("dbo.Visits");
            CreateIndex("dbo.FamilyMembers", "Family_Id");
            CreateIndex("dbo.FamilyMembers", "Address_Id");
            CreateIndex("dbo.Families", "AuthorizedStaffMember_Id");
            CreateIndex("dbo.Children", "Family_Id");
            CreateIndex("dbo.Towns", "Municipality_Id");
            CreateIndex("dbo.Addresses", "Town_Id");
            AddForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families", "Id");
            AddForeignKey("dbo.FamilyMembers", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Children", "Family_Id", "dbo.Families", "Id");
            AddForeignKey("dbo.Families", "AuthorizedStaffMember_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns", "Id");
            AddForeignKey("dbo.Towns", "Municipality_Id", "dbo.Municipalities", "Id");
            RenameTable(name: "dbo.VisitTypes", newName: "Municipalities");
        }
    }
}
