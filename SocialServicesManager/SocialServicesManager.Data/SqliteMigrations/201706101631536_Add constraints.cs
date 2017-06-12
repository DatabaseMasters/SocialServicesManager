namespace SocialServicesManager.Data.SqliteMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addconstraints : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalDoctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Specialty = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
                        Deleted = c.Boolean(nullable: false),
                        ChildId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalRecordMedicalDoctors",
                c => new
                    {
                        MedicalRecord_Id = c.Int(nullable: false),
                        MedicalDoctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicalRecord_Id, t.MedicalDoctor_Id })
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecord_Id, cascadeDelete: true)
                .ForeignKey("dbo.MedicalDoctors", t => t.MedicalDoctor_Id, cascadeDelete: true)
                .Index(t => t.MedicalRecord_Id)
                .Index(t => t.MedicalDoctor_Id);
        }
        
        public override void Down()
        {
           this.DropForeignKey("dbo.MedicalRecordMedicalDoctors", "MedicalDoctor_Id", "dbo.MedicalDoctors");
           this.DropForeignKey("dbo.MedicalRecordMedicalDoctors", "MedicalRecord_Id", "dbo.MedicalRecords");
           this.DropIndex("dbo.MedicalRecordMedicalDoctors", new[] { "MedicalDoctor_Id" });
           this.DropIndex("dbo.MedicalRecordMedicalDoctors", new[] { "MedicalRecord_Id" });
           this.DropTable("dbo.MedicalRecordMedicalDoctors");
           this.DropTable("dbo.MedicalRecords");
           this.DropTable("dbo.MedicalDoctors");
        }
    }
}
