namespace SocialServicesManager.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Town_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.Town_Id)
                .Index(t => t.Town_Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Municipality_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipalities", t => t.Municipality_Id)
                .Index(t => t.Municipality_Id);
            
            CreateTable(
                "dbo.Municipalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .Index(t => t.Family_Id);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorizedStaffMember_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorizedStaffMember_Id)
                .Index(t => t.AuthorizedStaffMember_Id);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Address_Id = c.Int(),
                        AuthorisedStaffMember_Id = c.Int(),
                        Family_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Users", t => t.AuthorisedStaffMember_Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.AuthorisedStaffMember_Id)
                .Index(t => t.Family_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.FamilyMembers", "AuthorisedStaffMember_Id", "dbo.Users");
            DropForeignKey("dbo.FamilyMembers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Children", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Families", "AuthorizedStaffMember_Id", "dbo.Users");
            DropForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Towns", "Municipality_Id", "dbo.Municipalities");
            DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "AuthorisedStaffMember_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Address_Id" });
            DropIndex("dbo.Families", new[] { "AuthorizedStaffMember_Id" });
            DropIndex("dbo.Children", new[] { "Family_Id" });
            DropIndex("dbo.Towns", new[] { "Municipality_Id" });
            DropIndex("dbo.Addresses", new[] { "Town_Id" });
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Families");
            DropTable("dbo.Children");
            DropTable("dbo.Municipalities");
            DropTable("dbo.Towns");
            DropTable("dbo.Addresses");
        }
    }
}
