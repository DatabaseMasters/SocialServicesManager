using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.App.Commands.Creational;
using SocialServicesManager.Data.Factories;
using System;

namespace SocialServicesManager.App.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IModelsFactory Factory;

        public CommandsFactory(IModelsFactory factory)
        {
            this.Factory = factory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            switch (commandName.ToLower())
            {
                case "createfamily":
                    return this.CreateFamilyCommand();
                case "createuser":
                    return this.CreateUserCommand();
                default:
                    throw new ArgumentException("Command not found");
            }
        }

        public ICommand CreateFamilyCommand()
        {
            return new CreateFamilyCommand(this.Factory);
        }

        public ICommand CreateUserCommand()
        {
            return new CreateUserCommand(this.Factory);
        }
    }
}
