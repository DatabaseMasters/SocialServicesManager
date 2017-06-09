namespace SocialServicesManager.App.Commands.Contracts
{
    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string commandName);
    }
}
