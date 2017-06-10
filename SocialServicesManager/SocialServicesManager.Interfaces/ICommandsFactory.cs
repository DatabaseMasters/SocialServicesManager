namespace SocialServicesManager.Interfaces
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
