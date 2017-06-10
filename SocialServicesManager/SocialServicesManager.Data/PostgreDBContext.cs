using SocialServicesManager.Data.Models;
using System.Data.Entity;
using System;

namespace SocialServicesManager.Data
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext() : base("PostgreConnection")
        {
        }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<VisitType> Visittypes { get; set; }

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
                .HasColumnType("nvarchar");
        }

        private void OnVisitModelCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
