using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IServiceLocator serviceLocator;

        public CommandsFactory(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.serviceLocator.GetCommand(commandName);
        }
    }
}
