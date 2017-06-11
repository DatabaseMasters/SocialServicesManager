using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.DataValidation;
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

            // TODO Implement logging functionality and assign new family to currently logged user
            var foundStaff = this.dataFactory.FindUser(userId);

            if (foundStaff == null)
            {
                throw new EntryNotFoundException($"User id {userId} not found.");
            }

            var family = this.ModelFactory.CreateFamily(name, foundStaff);

            this.dataFactory.AddFamily(family);
            this.dataFactory.SaveAllChanges();

            return $"Family {family.Name} with id {family.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters, int parameterCount)
        {
            base.ValidateParameters(parameters, ParameterCount);

            var name = parameters[0];

            if (name.Length < ModelsConstraints.NameMinLenght || name.Length > ModelsConstraints.NameMaxLenght)
            {
                throw new ParameterValidationException(string.Format(ValidationText, "Family name", ModelsConstraints.NameMinLenght, ModelsConstraints.NameMaxLenght));
            }
        }
    }
}
