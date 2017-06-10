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

            var splitBrackets = commandLine.Split(descriptionSeparators);
            var parameters = splitBrackets[0].TrimEnd();

            var commandName = parameters.Split(' ')[0].ToLower();
            var commandParams = parameters.Split(' ').Skip(1).ToList();
            if (splitBrackets.Length > 1)
            {
                var description = splitBrackets[1];
                commandParams.Add(description);
            }

            var command = this.commandFactory.GetCommand(commandName);
            var commandResult = command.Execute(commandParams);

            return commandResult;
        }
    }
}
