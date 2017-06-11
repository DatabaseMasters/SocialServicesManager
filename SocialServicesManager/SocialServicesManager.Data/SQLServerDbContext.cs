using SocialServicesManager.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace SocialServicesManager.Data
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext() : base("SQLConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Family> Families { get; set; }

        public DbSet<FamilyMember> FamilyMembers { get; set; }

        public DbSet<Child> Children { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnUserModelCreating(modelBuilder);
            this.OnFamilyModelCreating(modelBuilder);
            this.OnFamilyMemberModelCreating(modelBuilder);
            this.OnChildModelCreating(modelBuilder);
            this.OnAddressModelCreating(modelBuilder);
            this.OnTownModelCreating(modelBuilder);
            this.OnMunicpalityModelCreating(modelBuilder);
            this.OnGenderModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
    }

        private void OnMunicpalityModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Municipality>()
                .HasKey(m => m.Id)
                .Property(m => m.Name)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Municipality>()
                .HasMany(m => m.Towns)
                .WithRequired(t => t.Municipality);
        }

        private void OnTownModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>()
                .HasKey(t => t.Id)
                .HasRequired(t => t.Municipality);

            modelBuilder.Entity<Town>()
                .HasMany(t => t.Addresses)
                .WithRequired(a => a.Town);

            modelBuilder.Entity<Town>()
                .Property(t => t.Name)
                .IsRequired()
                .HasColumnType("nvarchar");
        }

        private void OnAddressModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(a => a.Id)
                .HasRequired(a => a.Town);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.People)
                .WithRequired(p => p.Address);

            modelBuilder.Entity<Address>()
                .Property(a => a.Name)
                .IsRequired()
                .HasColumnType("nvarchar");
        }

        private void OnChildModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>()
                .HasKey(c => c.Id)
                .HasRequired(c => c.Gender);

            modelBuilder.Entity<Child>()
                .HasRequired(c => c.Family);

            modelBuilder.Entity<Child>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Child>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Child>()
                .Property(c => c.BirthDate)
                .IsOptional()
                .HasColumnType("smalldatetime");

            modelBuilder.Entity<Child>()
                .Property(c => c.Deleted)
                .IsRequired();
        }

        private void OnFamilyMemberModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyMember>()
                .HasKey(f => f.Id)
                .HasRequired(f => f.Family);

            modelBuilder.Entity<FamilyMember>()
                .HasRequired(f => f.Address);

            modelBuilder.Entity<FamilyMember>()
                .HasRequired(f => f.Gender);

            modelBuilder.Entity<FamilyMember>()
                .Property(f => f.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<FamilyMember>()
                .Property(f => f.LastName)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<FamilyMember>()
                .Property(c => c.Deleted)
                .IsRequired();
        }

        private void OnFamilyModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasKey(f => f.Id)
                .HasRequired(f => f.AssignedStaffMember);

            modelBuilder.Entity<Family>()
                .HasMany(f => f.FamilyMembers)
                .WithRequired(fm => fm.Family);

            modelBuilder.Entity<Family>()
                .HasMany(c => c.Children)
                .WithRequired(c => c.Family);

            modelBuilder.Entity<Family>()
                .Property(f => f.Name)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Family>()
               .Property(c => c.Deleted)
               .IsRequired();
        }

        private void OnUserModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .HasMany(u => u.Families)
                .WithRequired(f => f.AssignedStaffMember);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasColumnAnnotation(
                        "IX_UserName", 
                        new IndexAnnotation(
                                new IndexAttribute("IX_UserName") { IsUnique = true }));

            modelBuilder.Entity<User>()
               .Property(u => u.Password)
               .IsRequired()
               .HasColumnType("nvarchar");

            modelBuilder.Entity<User>()
               .Property(u => u.FirstName)
               .IsRequired()
               .HasColumnType("nvarchar");

            modelBuilder.Entity<User>()
               .Property(u => u.LastName)
               .IsRequired()
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Family>()
               .Property(c => c.Deleted)
               .IsRequired();
        }

        private void OnGenderModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Gender>()
                .Property(g => g.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasColumnAnnotation(
                    "IX_Gender", 
                    new IndexAnnotation(
                                      new IndexAttribute("IX_Gender") { IsUnique = true }));
        }
    }
}
