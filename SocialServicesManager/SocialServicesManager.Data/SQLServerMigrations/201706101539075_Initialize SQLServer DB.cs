namespace SocialServicesManager.Data.SQLServerMigrations
{
    using System.Data.Entity.Migrations;

    public partial class InitializeSQLServerDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Town_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.Town_Id, cascadeDelete: true)
                .Index(t => t.Town_Id);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                        Family_Id = c.Int(nullable: false),
                        Gender_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.Gender_Id, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Family_Id)
                .Index(t => t.Gender_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                        AssignedStaffMember_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedStaffMember_Id, cascadeDelete: true)
                .Index(t => t.AssignedStaffMember_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(storeType: "smalldatetime"),
                        Gender_Id = c.Int(nullable: false),
                        Family_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id, cascadeDelete: true)
                .ForeignKey("dbo.Families", t => t.Family_Id, cascadeDelete: true)
                .Index(t => t.Gender_Id)
                .Index(t => t.Family_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Municipality_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipalities", t => t.Municipality_Id, cascadeDelete: true)
                .Index(t => t.Municipality_Id);
            
            CreateTable(
                "dbo.Municipalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Towns", "Municipality_Id", "dbo.Municipalities");
            this.DropForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns");
            this.DropForeignKey("dbo.FamilyMembers", "Address_Id", "dbo.Addresses");
            this.DropForeignKey("dbo.FamilyMembers", "Gender_Id", "dbo.Genders");
            this.DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            this.DropForeignKey("dbo.Children", "Family_Id", "dbo.Families");
            this.DropForeignKey("dbo.Children", "Gender_Id", "dbo.Genders");
            this.DropForeignKey("dbo.Families", "AssignedStaffMember_Id", "dbo.Users");
            this.DropIndex("dbo.Towns", new[] { "Municipality_Id" });
            this.DropIndex("dbo.Children", new[] { "Family_Id" });
            this.DropIndex("dbo.Children", new[] { "Gender_Id" });
            this.DropIndex("dbo.Families", new[] { "AssignedStaffMember_Id" });
            this.DropIndex("dbo.FamilyMembers", new[] { "Address_Id" });
            this.DropIndex("dbo.FamilyMembers", new[] { "Gender_Id" });
            this.DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
            this.DropIndex("dbo.Addresses", new[] { "Town_Id" });
            this.DropTable("dbo.Municipalities");
            this.DropTable("dbo.Towns");
            this.DropTable("dbo.Genders");
            this.DropTable("dbo.Children");
            this.DropTable("dbo.Users");
            this.DropTable("dbo.Families");
            this.DropTable("dbo.FamilyMembers");
            this.DropTable("dbo.Addresses");
        }
    }
}
