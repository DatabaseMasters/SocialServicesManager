using SocialServicesManager.Data.Models;
using System.Collections.Generic;

namespace SocialServicesManager.Data.Factories.Contracts
{
    public interface IDataFactory
    {
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

        void SaveAllChanges();

        Child FindChild(int id);

        MedicalDoctor FindMedicalDoctor(int id);

        VisitType GetVisitType(string type);

        User FindUser(int id);

        ICollection<Visit> GetUserVisits(User user);

        Family FindFamily(int id);

        IEnumerable<Family> GetAllFamilies();

        Town FindTown(int id);

        void UpdateFamily(Family family, IList<string> parameters);
    }
}
