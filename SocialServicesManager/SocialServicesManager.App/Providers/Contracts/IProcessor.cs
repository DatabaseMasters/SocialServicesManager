namespace SocialServicesManager.App.Providers.Contracts
{
    public interface IProcessor
    {
        string ProcessCommand(string commandLine);
    }
}
