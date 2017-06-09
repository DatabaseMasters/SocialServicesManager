namespace SocialServicesManager.Interfaces
{
    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string commandName);
    }
}
