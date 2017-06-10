using System.Collections.Generic;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;

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
            var townId = int.Parse(parameters[0]);
            var name = parameters[1];

            var townFound = this.dataFactory.FindTown(townId);

            if (townFound == null)
            {
                throw new EntryNotFoundException($"Town id {townId} not found.");
            }

            var address = this.ModelFactory.CreateAddress(townFound, name);

            this.dataFactory.AddAddress(address);
            this.dataFactory.SaveAllChanges();

            return $"Address {address.Name}, {address.Town.Name} with id {address.Id} created.";
        }
    }
}
