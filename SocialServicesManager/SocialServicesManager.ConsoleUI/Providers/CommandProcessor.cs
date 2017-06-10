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
            var descriptionSeparators = new char[] { '(', ')' };
            
            var parameters = commandLine.Split(descriptionSeparators)[0].TrimEnd();
            var description = commandLine.Split(descriptionSeparators)[1];

            var commandName = parameters.Split(' ')[0].ToLower();
            var commandParams = parameters.Split(' ').Skip(1).ToList();
            commandParams.Add(description);

            var command = this.commandFactory.GetCommand(commandName);
            var commandResult = command.Execute(commandParams);

            return commandResult;
        }
    }
}
