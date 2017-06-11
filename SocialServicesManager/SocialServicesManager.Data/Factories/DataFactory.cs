using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialServicesManager.Data.Factories
{
    public class DataFactory : IDataFactory
    {
        private readonly SQLServerDbContext sqlDbContext;
        private readonly PostgreDbContext postgreDbContext;
        private readonly SqliteDbContext sqliteDbContext;

        public DataFactory(SQLServerDbContext sqlDbContext, PostgreDbContext postgreDbContext, SqliteDbContext sqliteDbContext)
        {
            this.sqlDbContext = sqlDbContext;
            this.postgreDbContext = postgreDbContext;
            this.sqliteDbContext = sqliteDbContext;
        }

        private SQLServerDbContext SqlDbContext
        {
            get
            {
                return this.sqlDbContext;
            }
        }

        private PostgreDbContext PostgreDbContext
        {
            get
            {
                return this.postgreDbContext;
            }
        }

        private SqliteDbContext SqliteDbContext
        {
            get
            {
                return this.sqliteDbContext;
            }
        }

        // CREATING
        public void AddAddress(Address address)
        {
            this.SqlDbContext.Addresses.Add(address);
        }

        public void AddChild(Child child)
        {
            this.SqlDbContext.Children.Add(child);
        }

        public void AddFamily(Family family)
        {
            this.SqlDbContext.Families.Add(family);
        }

        public void AddFamilyMember(FamilyMember familyMember)
        {
            this.SqlDbContext.FamilyMembers.Add(familyMember);
        }

        public void AddMedicalDoctor(MedicalDoctor doctor)
        {
            this.SqliteDbContext.MedicalDoctors.Add(doctor);
        }        

        public void AddMedicalRecord(MedicalRecord record)
        {
            this.SqliteDbContext.MedicalRecords.Add(record);
        }
        
        public void AddMunicipality(Municipality municipality)
        {
            this.SqlDbContext.Municipalities.Add(municipality);
        }

        public void AddTown(Town town)
        {
            this.SqlDbContext.Towns.Add(town);
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
            this.PostgreDbContext.VisitTypes.Add(visitType);
        }
        
        // TODO Research if this creates issues
        public void SaveAllChanges()
        {
            this.SqlDbContext.SaveChanges();
            this.PostgreDbContext.SaveChanges();
            this.SqliteDbContext.SaveChanges();
        }

        // READING
        public Child FindChild(int id)
        {
            var childFound = this.SqlDbContext.Children.Find(id);

            return childFound;
        }

        public Gender GetGender(string gender)
        {
            var genderFound = this.SqlDbContext.Genders
                .FirstOrDefault(g => g.Name.ToLower() == gender.ToLower());

            return genderFound;
        }

        public MedicalDoctor FindMedicalDoctor(int id)
        {
            var doctorFound = this.SqliteDbContext.MedicalDoctors.Find(id);

            return doctorFound;
        }
        
        public VisitType GetVisitType(string type)
        {
            var typeFound = this.PostgreDbContext.VisitTypes
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
        public ICollection<Visit> GetUserVisits(User user)
        {
            var userVisits = this.PostgreDbContext.Visits.Where(v => v.UserId == user.Id).ToList();

            return userVisits;
        }
        
        public ICollection<Visit> GetFamilyVisits(Family family)
        {
            return this.PostgreDbContext.Visits.Where(v => v.FamilyId == family.Id).ToList();
        }
        
        public User FindUser(int id)
        {
            var userFound = this.SqlDbContext.Users.Find(id);

            return userFound;
        }
    }
}
