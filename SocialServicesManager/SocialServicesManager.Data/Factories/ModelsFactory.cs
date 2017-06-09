using SocialServicesManager.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Globalization;

namespace SocialServicesManager.Data.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        public ModelsFactory(SQLServerDbContext sqlDbContext, PostgreDbContext postgreDbContext, SqliteDbContext sqliteDbContext)
        {
            this.SqlDbContext = sqlDbContext;
            this.PostgreDbContext = postgreDbContext;
            this.SqliteDbContext = sqliteDbContext;
        }

        public SQLServerDbContext SqlDbContext { get; private set; }

        public PostgreDbContext PostgreDbContext { get; private set; }

        public SqliteDbContext SqliteDbContext { get; private set; }

        public Family CreateFamily(string name)
        {
            var family = new Family
            {
                Name = name
            };

            this.SqlDbContext.Families.Add(family);
            this.SqlDbContext.SaveChanges();

            return family;
        }

        public User CreateUser(string name)
        {
            var user = new User
            {
                Name = name
            };

            this.SqlDbContext.Users.Add(user);
            this.SqlDbContext.SaveChanges();

            return user;
        }

        public string CreateVisit(string date, string descirption, int userId, int familyId, string type)
        {
            var visit = new Visit
            {
                Date = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Description = descirption,
                UserId = userId,
                FamilyId = familyId,
                VisitType = this.PostgreDbContext.Visittypes.Where(x => x.Name == type).Count() > 0 ? 
                            this.PostgreDbContext.Visittypes.Where(x => x.Name == type).First() : 
                            this.CreateVisitType(type),
            };

            this.PostgreDbContext.Visits.Add(visit);
            this.PostgreDbContext.SaveChanges();

            return $"Visit on {visit.Date} with id: {visit.Id} was created";
        }

        public VisitType CreateVisitType(string name)
        {
            var visitType = new VisitType
            {
                Name = name
            };

            this.PostgreDbContext.Visittypes.Add(visitType);
            this.PostgreDbContext.SaveChanges();

            return visitType;
        }

        public string CreateMedicalDoctor(string name)
        {
            var doctor = new MedicalDoctor
            {
                Id = 1,
                Name = name
            };

            this.SqliteDbContext.MedicalDoctors.Add(doctor);
            this.SqliteDbContext.SaveChanges();

            return $"Medical doctor {doctor.Name} with id {doctor.Id} created.";
        }

        public string CreateMedicalRecord(string description, int childId, int medicalDoctorId)
        {
            var medicalRecord = new MedicalRecord
            {
                Description = description,
                ChildId = childId,
                MedicalDoctor = this.SqliteDbContext.MedicalDoctors.Find(medicalDoctorId)
            };

            this.SqliteDbContext.MedicalRecords.Add(medicalRecord);
            this.SqliteDbContext.SaveChanges();

            return $"Medical record with id {medicalRecord.Id} created.";
        }
    }
}
