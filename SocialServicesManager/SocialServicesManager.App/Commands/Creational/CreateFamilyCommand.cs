using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateFamilyCommand : CreationalCommand, ICommand
    {
        private const int ParameterCount = 2;

        public CreateFamilyCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var name = parameters[0];
            var userId = int.Parse(parameters[1]);

            this.ValidateName("Name", name);

            // TODO Implement logging functionality and assign new family to currently logged user
            var foundStaff = this.DataFactory.FindUser(userId);
            if (foundStaff == null)
            {
                throw new EntryNotFoundException($"User id {userId} not found.");
            }

            var family = this.ModelFactory.CreateFamily(name, foundStaff);
            this.DataFactory.AddFamily(family);
            this.DataFactory.SaveAllChanges();

            return $"Family {family.Name} created with id {family.Id}.";
        }        
    }
}
