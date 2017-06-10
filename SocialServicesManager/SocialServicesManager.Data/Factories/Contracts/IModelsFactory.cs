using SocialServicesManager.Data.Models;

namespace SocialServicesManager.Data.Factories.Contracts
{
    public interface IModelsFactory
    {
        Family CreateFamily(string name);

        User CreateUser(string name);

        Visit CreateVisit(string date, string descirption, int userId, int familyId, VisitType type);

        VisitType CreateVisitType(string name);

        MedicalRecord CreateMedicalRecord(string description, int childId, MedicalDoctor medicalDoctorId);

        MedicalDoctor CreateMedicalDoctor(string name);
    }
}
