namespace SocialServicesManager.Data.PostgreMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitializePostgreDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        FamilyId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        VisitType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VisitTypes", t => t.VisitType_Id, cascadeDelete: true)
                .Index(t => t.VisitType_Id);
            
            CreateTable(
                "dbo.VisitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(
                                    nullable: false, 
                                    maxLength: 50,
                                    annotations: new Dictionary<string, AnnotationValues>
                                    {
                                        { 
                                            "IX_VisitType",
                                            new AnnotationValues(
                                                oldValue: null, 
                                                newValue: "IndexAnnotation: { Name: IX_VisitType, IsUnique: True }")
                                        },
                                    }),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "VisitType_Id", "dbo.VisitTypes");
            DropIndex("dbo.Visits", new[] { "VisitType_Id" });
            DropTable("dbo.VisitTypes",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "IX_VisitType", "IndexAnnotation: { Name: IX_VisitType, IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Visits");
        }
    }
}
