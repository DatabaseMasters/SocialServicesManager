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
                case "createvisit":
                    return this.CreateVisitCommand();
                case "createmedicalrecord":
                    return this.CreateMedicalRecordCommand();
                case "createmedicaldoctor":
                    return this.CreateMedicalDoctorRecordCommand();
                default:
                    throw new ArgumentException("Command not found");
            }
        }

        private ICommand CreateFamilyCommand()
        {
            return new CreateFamilyCommand(this.Factory);
        }

        private ICommand CreateUserCommand()
        {
            return new CreateUserCommand(this.Factory);
        }

        private ICommand CreateVisitCommand()
        {
            return new CreateVisitCommand(this.Factory);
        }

        private ICommand CreateMedicalRecordCommand()
        {
            return new CreateMedicalRecord(this.Factory);
        }

        private ICommand CreateMedicalDoctorRecordCommand()
        {
            return new CreateMedicalDoctor(this.Factory);
        }
    }
}
