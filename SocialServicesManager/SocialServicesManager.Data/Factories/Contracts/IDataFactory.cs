using SocialServicesManager.Data.Models;
using System.Collections.Generic;

namespace SocialServicesManager.Data.Factories.Contracts
{
    public interface IDataFactory
    {
        void AddAddress(Address address);

        void AddFamily(Family family);

        void AddUser(User user);

        void AddVisit(Visit visit);

        void AddMedicalDoctor(MedicalDoctor doctor);

        void AddMedicalRecord(MedicalRecord record);

        void SaveAllChanges();

        MedicalDoctor GetMedicalDoctor(int id);

        VisitType GetVisitType(string type);

        Family FindFamily(int id);

        IEnumerable<Family> GetAllFamilies();

        Town FindTown(int id);

        void UpdateFamily(Family family, IList<string> parameters);
    }
}
