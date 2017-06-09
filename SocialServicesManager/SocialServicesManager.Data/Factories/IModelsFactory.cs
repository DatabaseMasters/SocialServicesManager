using SocialServicesManager.Models;

namespace SocialServicesManager.Data.Factories
{
    public interface IModelsFactory
    {
        string CreateFamily(string name);

        string CreateUser(string name);

        string CreateVisit(string date, string descirption, int userId, int familyId, string type);

        VisitType CreateVisitType(string name);
    }
}
