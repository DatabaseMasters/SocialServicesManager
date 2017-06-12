using SocialServicesManager.Data.Models;
using System.Collections.Generic;

namespace SocialServicesManager.Data.Factories.Contracts
{
    public interface IDataFactory
    {
        // CREATING
        void AddAddress(Address address);

        void AddChild(Child child);

        void AddFamily(Family family);
        
        void AddFamilyMember(FamilyMember familyMember);

        void AddMedicalDoctor(MedicalDoctor doctor);

        void AddMedicalRecord(MedicalRecord record);

        void AddMunicipality(Municipality municipality);

        void AddTown(Town town);

        void AddUser(User user);

        void AddVisit(Visit visit);

        void AddVisitType(VisitType visitType);

        void SaveAllChanges();

        // READING
        Address FindAddress(int id);

        Child FindChild(int id);

        Family FindFamily(int id);

        string GetFamilyName(int id);

        Gender GetGender(string gender);

        MedicalDoctor FindMedicalDoctor(int id);

        Town FindTown(int id);

        User FindUser(int id);

        string GetUserByUsername(string username);

        VisitType GetVisitType(string type);

        Visit FindVisit(int id);

        ICollection<Visit> GetUserVisits(int userId);

        ICollection<Child> GetAllChildren();

        ICollection<Family> GetAllFamilies();

        ICollection<User> GetAllUsers();

        ICollection<Visit> GetFamilyVisits(Family family);

        ICollection<VisitType> GetAllVisitTypes();

        // UPDATING
        void UpdateChild(Child oldChild, Child newChild);

        void UpdateFamilyName(Family family, string newName);

        void UpdateFamilyStaff(Family family, User newStaff);

        void UpdateVisit(Visit oldVisit, Visit newVisit);
        
        // DELETING
        void DeleteChild(Child child);

        void DeleteFamily(Family family);
    }
}
