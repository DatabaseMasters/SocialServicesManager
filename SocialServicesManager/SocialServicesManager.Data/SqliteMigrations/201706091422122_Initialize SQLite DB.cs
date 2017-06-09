namespace SocialServicesManager.Data.SqliteMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeSQLiteDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalDoctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 2147483647),
                        ChildId = c.Int(nullable: false),
                        MedicalDoctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalDoctors", t => t.MedicalDoctor_Id)
                .Index(t => t.MedicalDoctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "MedicalDoctor_Id", "dbo.MedicalDoctors");
            DropIndex("dbo.MedicalRecords", new[] { "MedicalDoctor_Id" });
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.MedicalDoctors");
        }
    }
}
