using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.App.Providers.Contracts;
using System.Linq;

namespace SocialServicesManager.ConsoleUI.Providers
{
    public class CommandProcessor : IProcessor
    {
        private readonly ICommandsFactory factory;

        public CommandProcessor(ICommandsFactory factory)
        {
            this.Factory = factory;
        }

        public ICommandsFactory Factory { get; private set; }

        public string ProcessCommand(string commandLine)
        {
            var commandName = commandLine.Split(' ')[0];
            var commandParams = commandLine.Split(' ').Skip(1).ToList();
            var command = this.Factory.CreateCommandFromString(commandName);
            var commandResult = command.Execute(commandParams);

            return commandResult;
        }
    }
}
