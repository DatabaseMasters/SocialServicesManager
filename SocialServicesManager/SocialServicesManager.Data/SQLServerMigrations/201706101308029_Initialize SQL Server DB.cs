namespace SocialServicesManager.Data.SQLServerMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
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
                        Name = c.String(nullable: false, maxLength: 300),
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
                        UserName = c.String(nullable: false, maxLength: 50,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_UserName",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_UserName, IsUnique: True }")
                                },
                            }),
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
                        Name = c.String(nullable: false, maxLength: 50,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_Gender",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_Gender, IsUnique: True }")
                                },
                            }),
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
            DropForeignKey("dbo.Towns", "Municipality_Id", "dbo.Municipalities");
            DropForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.FamilyMembers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.FamilyMembers", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Children", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Children", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Families", "AssignedStaffMember_Id", "dbo.Users");
            DropIndex("dbo.Towns", new[] { "Municipality_Id" });
            DropIndex("dbo.Children", new[] { "Family_Id" });
            DropIndex("dbo.Children", new[] { "Gender_Id" });
            DropIndex("dbo.Families", new[] { "AssignedStaffMember_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Address_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Gender_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
            DropIndex("dbo.Addresses", new[] { "Town_Id" });
            DropTable("dbo.Municipalities");
            DropTable("dbo.Towns");
            DropTable("dbo.Genders",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "IX_Gender", "IndexAnnotation: { Name: IX_Gender, IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Children");
            DropTable("dbo.Users",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "UserName",
                        new Dictionary<string, object>
                        {
                            { "IX_UserName", "IndexAnnotation: { Name: IX_UserName, IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Families");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Addresses");
        }
    }
}
