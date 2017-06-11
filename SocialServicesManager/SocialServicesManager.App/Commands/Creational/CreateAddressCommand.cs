using System.Collections.Generic;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.DataValidation;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateAddressCommand : CreationalCommand, ICommand
    {
        private const int ParameterCount = 2;

        public CreateAddressCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var townId = int.Parse(parameters[0]);
            var name = parameters[1];

            var townFound = this.dataFactory.FindTown(townId);

            if (townFound == null)
            {
                throw new EntryNotFoundException($"Town id {townId} not found.");
            }

            var address = this.modelFactory.CreateAddress(townFound, name);

            this.dataFactory.AddAddress(address);
            this.dataFactory.SaveAllChanges();

            return $"Address {address.Name}, {address.Town.Name} with id {address.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            base.ValidateParameters(parameters, paramterCount);

            var name = parameters[1];

            if (name.Length < ModelsConstraints.AddressNameMinLenght || name.Length > ModelsConstraints.AddressNameMaxLenght)
            {
                throw new ParameterValidationException(string.Format(ValidationText, "Address", ModelsConstraints.AddressNameMinLenght, ModelsConstraints.AddressNameMaxLenght));
            }
        }
    }
}
