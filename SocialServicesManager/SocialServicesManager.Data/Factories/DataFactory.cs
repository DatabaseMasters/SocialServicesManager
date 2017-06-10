using System.Linq;
using System.Collections.Generic;
using SocialServicesManager.Interfaces;
using SocialServicesManager.Models;

namespace SocialServicesManager.Data.Factories
{
    public class DataFactory : IDataFactory
    {
        private readonly SQLServerDbContext SqlDbContext;
        private readonly PostgreDbContext PostgreDbContext;
        private readonly SqliteDbContext SqliteDbContext;

        public DataFactory(SQLServerDbContext sqlDbContext, PostgreDbContext postgreDbContext, SqliteDbContext sqliteDbContext)
        {
            this.SqlDbContext = sqlDbContext;
            this.PostgreDbContext = postgreDbContext;
            this.SqliteDbContext = sqliteDbContext;
        }

        // CREATING
        public void AddAddress(Address address)
        {
            this.SqlDbContext.Addresses.Add(address);
        }

        public void AddFamily(Family family)
        {
            this.SqlDbContext.Families.Add(family);
        }

        public void AddUser(User user)
        {
            this.SqlDbContext.Users.Add(user);
        }

        public void AddVisit(Visit visit)
        {
            this.PostgreDbContext.Visits.Add(visit);
        }

        public void AddVisitType(VisitType visitType)
        {
            this.PostgreDbContext.Visittypes.Add(visitType);
        }

        public void AddMedicalDoctor(MedicalDoctor doctor)
        {
            this.SqliteDbContext.MedicalDoctors.Add(doctor);

        }        

        public void AddMedicalRecord(MedicalRecord record)
        {
            this.SqliteDbContext.MedicalRecords.Add(record);
        }


        // TODO Research if this creates issues
        public void SaveAllChanges()
        {
            this.SqlDbContext.SaveChanges();
            this.PostgreDbContext.SaveChanges();
            this.SqliteDbContext.SaveChanges();
        }

        // READING
        public MedicalDoctor GetMedicalDoctor(int id)
        {
            var doctorFound = this.SqliteDbContext.MedicalDoctors.Find(id);

            return doctorFound;
        }
        
        public VisitType GetVisitType(string type)
        {
            var typeFound = this.PostgreDbContext.Visittypes
                .Where(v => v.Name == type)
                .FirstOrDefault();

            return typeFound;
        }
        
        public Family FindFamily(int id)
        {
            var familyFound = this.SqlDbContext.Families.Find(id);

            return familyFound;
        }

        public IEnumerable<Family> GetAllFamilies()
        {
            return this.SqlDbContext.Families.ToList();
        }

        public Town FindTown(int id)
        {
            var townFound = this.SqlDbContext.Towns.Find(id);

            return townFound;
        }

        // UPDATING
        public void UpdateFamily(Family family, IList<string> parameters)
        {
            family.Name = parameters[1];
        }

        // DELETING
    }
}
