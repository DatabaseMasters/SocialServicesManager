using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.App.Commands.Creational;
using SocialServicesManager.Data.Factories;
using System;

namespace SocialServicesManager.App.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IModelsFactory ModelFactory;
        private readonly IDataFactory DataFactory;

        public CommandsFactory(IModelsFactory modelFactory, IDataFactory dataFactory)
        {
            this.ModelFactory = modelFactory;
            this.DataFactory = dataFactory;
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
            return new CreateFamilyCommand(this.ModelFactory, this.DataFactory);
        }

        private ICommand CreateUserCommand()
        {
            return new CreateUserCommand(this.ModelFactory, this.DataFactory);
        }

        private ICommand CreateVisitCommand()
        {
            return new CreateVisitCommand(this.ModelFactory, this.DataFactory);
        }

        private ICommand CreateMedicalRecordCommand()
        {
            return new CreateMedicalRecord(this.ModelFactory, this.DataFactory);
        }

        private ICommand CreateMedicalDoctorRecordCommand()
        {
            return new CreateMedicalDoctor(this.ModelFactory, this.DataFactory);
        }
    }
}
