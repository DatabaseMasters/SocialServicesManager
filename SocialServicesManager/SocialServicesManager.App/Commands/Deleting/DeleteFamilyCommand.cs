using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Deleting
{
    public class DeleteFamilyCommand : Command, ICommand
    {
        private const int ParameterCount = 1;
        public DeleteFamilyCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var familyId = int.Parse(parameters[0]);

            var familyFound = this.dataFactory.FindFamily(familyId);
            
            if (familyFound == null)
            {
                throw new EntryNotFoundException($"Family with id {familyId} not found.");
            }

            this.dataFactory.DeleteFamily(familyFound);
            this.dataFactory.SaveAllChanges();

            return $"Family {familyFound.Name} with id {familyFound.Id} deleted.";
        }
    }
}
