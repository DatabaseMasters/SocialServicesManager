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
        public Address FindAddress(int id)
        {
            var addressFound = this.SqlDbContext.Addresses.Find(id);

            return addressFound;
        }

        public Child FindChild(int id)
        {
            var childFound = this.SqlDbContext.Children
                .Where(c => c.Id == id)
                .Where(c => c.Deleted == false)
                .FirstOrDefault();

            return childFound;
        }

        public Family FindFamily(int id)
        {
            var familyFound = this.SqlDbContext.Families
                .Where(f => f.Id == id)
                .Where(f => f.Deleted == false)
                .FirstOrDefault();

            return familyFound;
        }

        public string GetFamilyName(int id)
        {
            var nameFound = this.sqlDbContext.Families
                .Where(f => f.Id == id)
                .Where(f => f.Deleted == false)
                .Select(f => f.Name)
                .FirstOrDefault();

            return nameFound;
        }

        public Gender GetGender(string gender)
        {
            var genderFound = this.SqlDbContext.Genders
                .FirstOrDefault(g => g.Name.ToLower() == gender.ToLower());

            return genderFound;
        }

        public MedicalDoctor FindMedicalDoctor(int id)
        {
            var doctorFound = this.SqliteDbContext.MedicalDoctors
                .Where(d => d.Id == id)
                .Where(d => d.Deleted == false)
                .FirstOrDefault();

            return doctorFound;
        }

        public Town FindTown(int id)
        {
            var townFound = this.SqlDbContext.Towns.Find(id);

            return townFound;
        }

        public User FindUser(int id)
        {
            var userFound = this.SqlDbContext.Users
                .Where(u => u.Id == id)
                .Where(u => u.Deleted == false)
                .FirstOrDefault();

            return userFound;
        }
        
        public string GetUserByUsername(string username)
        {
            var usernameFound = this.sqlDbContext.Users
                .Where(u => u.UserName == username)
                .Where(u => u.Deleted == false)
                .Select(u => u.UserName)
                .FirstOrDefault();

            return usernameFound;
        }

        public VisitType GetVisitType(string type)
        {
            var typeFound = this.PostgreDbContext.VisitTypes
                .Where(v => v.Name == type)
                .FirstOrDefault();

            return typeFound;
        }

        public Visit FindVisit(int id)
        {
            return this.postgreDbContext.Visits.Find(id);
        }

        public ICollection<Child> GetAllChildren()
        {
            return this.SqlDbContext.Children
                .Where(c => c.Deleted == false)
                .ToList();
        }

        public ICollection<Family> GetAllFamilies()
        {
            return this.SqlDbContext.Families
                .Where(f => f.Deleted == false)
                .ToList();
        }

        public ICollection<User> GetAllUsers()
        {
            return this.SqlDbContext.Users
                .Where(u => u.Deleted == false)
                .ToList();
        }

        public ICollection<Visit> GetUserVisits(int userId)
        {
            var userVisits = this.PostgreDbContext.Visits
                .Where(v => v.UserId == userId)
                .Where(v => v.Deleted == false)
                .ToList();

            return userVisits;
        }
        
        public ICollection<Visit> GetFamilyVisits(Family family)
        {
            return this.PostgreDbContext.Visits
                .Where(v => v.FamilyId == family.Id)
                .Where(v => v.Deleted == false)
                .ToList();
        }

        public ICollection<VisitType> GetAllVisitTypes()
        {
            return this.postgreDbContext.VisitTypes
                .ToList();
        }
        
        // UPDATING
        public void UpdateChild(Child oldChild, Child newChild)
        {
            oldChild.FirstName = newChild.FirstName ?? oldChild.FirstName;
            oldChild.LastName = newChild.LastName ?? oldChild.LastName;
            oldChild.Gender = newChild.Gender ?? oldChild.Gender;
            oldChild.BirthDate = newChild.BirthDate ?? oldChild.BirthDate;
            oldChild.Family = newChild.Family ?? oldChild.Family;
        }
        
        public void UpdateFamilyName(Family family, string newName)
        {
            family.Name = newName;
        }

        public void UpdateFamilyStaff(Family family, User newStaff)
        {
            family.AssignedStaffMember = newStaff;
        }

        public void UpdateVisit(Visit oldVisit, Visit newVisit)
        {
            oldVisit.Date = newVisit.Date;
            oldVisit.UserId = newVisit.UserId;
            oldVisit.FamilyId = newVisit.FamilyId;
            oldVisit.VisitType = newVisit.VisitType;
            oldVisit.Description = newVisit.Description;
        }

        // DELETING
        public void DeleteChild(Child child)
        {
            child.Deleted = true;
        }

        public void DeleteFamily(Family family)
        {
            family.Deleted = true;
        }
    }
}
