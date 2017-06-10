using SocialServicesManager.Data.Models;

namespace SocialServicesManager.Data.Factories.Contracts
{
    public interface IModelsFactory
    {
        Address CreateAddress(Town town, string name);

        Family CreateFamily(string name);

        User CreateUser(string username, string password, string firstName, string lastName);

        Visit CreateVisit(string date, int userId, int familyId, VisitType type, string descirption);

        VisitType CreateVisitType(string name);
          
        MedicalRecord CreateMedicalRecord(int childId, MedicalDoctor medicalDoctorId, string description);

        MedicalDoctor CreateMedicalDoctor(string name);
    }
}
