using SocialServicesManager.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace SocialServicesManager.Data
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext() : base("PostgreConnection")
        {
        }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<VisitType> VisitTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnVisitModelCreating(modelBuilder);
            this.OnVisitTypeModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void OnVisitTypeModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitType>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<VisitType>()
                .Property(t => t.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnAnnotation(
                    "IX_VisitType", 
                    new IndexAnnotation(
                        new IndexAttribute("IX_VisitType")
                        {
                            IsUnique = true
                        }));
        }

        private void OnVisitModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visit>()
                .HasKey(v => v.Id)
                .HasRequired(t => t.VisitType);

            modelBuilder.Entity<Visit>()
                .Property(c => c.Date)
                .IsRequired()
                .HasColumnType("timestamp");

            modelBuilder.Entity<Visit>()
                .Property(v => v.Description)
                .IsRequired()
                .HasColumnType("text");

            modelBuilder.Entity<Visit>()
               .Property(v => v.UserId)
               .IsRequired();

            modelBuilder.Entity<Visit>()
               .Property(v => v.FamilyId)
               .IsRequired();

            modelBuilder.Entity<Visit>()
                .Property(c => c.Deleted)
                .IsRequired();
        }
    }
}
