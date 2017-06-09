using SocialServicesManager.Models;
using System.Linq;
using SocialServicesManager.Interfaces;

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

        // TODO Add CreateVisitTypeCommand
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
    }
}
