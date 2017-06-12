namespace SocialServicesManager.Data.PostgreMigrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;

    public partial class FixVisitTypeuniqueconstraint : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn(
                "dbo.VisitTypes",
                "Name",
                c => c.String(
                    nullable: false,
                    maxLength: 50,
                    annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "IX_VisitType",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: IX_VisitType, IsUnique: True }", newValue: null)
                    },
                }));

            this.CreateIndex("dbo.VisitTypes", "Name", unique: true, name: "IX_VisitUnique");
        }

        public override void Down()
        {
            this.DropIndex("dbo.VisitTypes", "IX_VisitUnique");
            this.AlterColumn(
                "dbo.VisitTypes",
                "Name",
                c => c.String(
                    nullable: false,
                    maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "IX_VisitType",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_VisitType, IsUnique: True }")
                    },
                }));
        }
    }
}
