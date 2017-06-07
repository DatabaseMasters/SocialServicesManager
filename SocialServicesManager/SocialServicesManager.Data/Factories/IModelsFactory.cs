namespace SocialServicesManager.Data.Factories
{
    public interface IModelsFactory
    {
        string CreateFamily(string name);

        string CreateUser(string name);
    }
}
