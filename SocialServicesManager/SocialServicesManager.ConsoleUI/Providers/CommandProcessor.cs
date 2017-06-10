using SocialServicesManager.Interfaces;
using System.Linq;

namespace SocialServicesManager.ConsoleUI.Providers
{
    public class CommandProcessor : IProcessor
    {
        private readonly ICommandsFactory commandFactory;
        public CommandProcessor(ICommandsFactory factory)
        {
            this.commandFactory = factory;
        }

        public string ProcessCommand(string commandLine)
        {
            var commandName = commandLine.Split(' ')[0].ToLower();
            var commandParams = commandLine.Split(' ').Skip(1).ToList();
            var command = this.commandFactory.GetCommand(commandName);
            var commandResult = command.Execute(commandParams);

            return commandResult;
        }
    }
}
