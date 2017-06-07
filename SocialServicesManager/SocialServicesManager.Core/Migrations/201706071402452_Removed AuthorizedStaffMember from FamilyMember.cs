namespace SocialServicesManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAuthorizedStaffMemberfromFamilyMember : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FamilyMembers", "AuthorisedStaffMember_Id", "dbo.Users");
            DropIndex("dbo.FamilyMembers", new[] { "AuthorisedStaffMember_Id" });
            DropColumn("dbo.FamilyMembers", "AuthorisedStaffMember_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FamilyMembers", "AuthorisedStaffMember_Id", c => c.Int());
            CreateIndex("dbo.FamilyMembers", "AuthorisedStaffMember_Id");
            AddForeignKey("dbo.FamilyMembers", "AuthorisedStaffMember_Id", "dbo.Users", "Id");
        }
    }
}
