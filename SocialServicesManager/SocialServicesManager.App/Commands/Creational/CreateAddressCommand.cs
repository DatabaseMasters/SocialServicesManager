using System;
using System.Collections.Generic;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Models;
using SocialServicesManager.App.Exceptions;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateAddressCommand : CreationalCommand, ICommand
    {
        public CreateAddressCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var townId = int.Parse(parameters[0]);
            var name = parameters[1];

            var townFound = this.DataFactory.FindTown(townId);

            if (townFound == null)
            {
                throw new EntryNotFoundException($"Town {townId} not found.");
            }

            var address = this.ModelFactory.CreateAddress(townFound, name);

            this.DataFactory.AddAddress(address);
            this.DataFactory.SaveAllChanges();

            return $"Address {address.Name}, {address.Town.Name} with id {address.Id} created.";
        }
    }
}
