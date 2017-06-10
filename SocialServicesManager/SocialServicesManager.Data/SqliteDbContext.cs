using SocialServicesManager.Data.Models;
using SocialServicesManager.Data.SqliteMigrations;
using System.Data.Entity;

namespace SocialServicesManager.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext() : base("SqliteConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqliteDbContext, SqliteConfiguration>(true));
        }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<MedicalDoctor> MedicalDoctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnMedicalRecordModelCreating(modelBuilder);
            this.OnMedcialDoctorModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void OnMedicalRecordModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalRecord>()
                .HasKey(mr => mr.Id)
                .HasMany(mr => mr.MedicalDoctors)
                .WithMany(md => md.MedicalRecords);

            modelBuilder.Entity<MedicalRecord>()
                .Property(mr => mr.Date)
                .IsRequired()
                .HasColumnType("datetime");

            modelBuilder.Entity<MedicalRecord>()
                .Property(mr => mr.Description)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<MedicalRecord>()
                .Property(mr => mr.ChildId)
                .IsRequired()
                .HasColumnType("integer");

            modelBuilder.Entity<MedicalRecord>()
              .Property(mr => mr.Deleted)
              .IsRequired();
        }

        private void OnMedcialDoctorModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalDoctor>()
                .HasKey(md => md.Id)
                .HasMany(md => md.MedicalRecords);

            modelBuilder.Entity<MedicalDoctor>()
                .Property(md => md.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<MedicalDoctor>()
                .Property(md => md.LastName)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<MedicalDoctor>()
                .Property(md => md.PhoneNumber)
                .IsRequired()
                .HasColumnType("nchar");

            modelBuilder.Entity<MedicalDoctor>()
                .Property(md => md.Specialty)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<MedicalDoctor>()
                         .Property(md => md.Deleted)
                         .IsRequired();
        }
    }
}
