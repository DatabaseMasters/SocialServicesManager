using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;

namespace SocialServicesManager.App.Commands.Updating
{
    public class UpdateFamilyCommand : UpdatingCommand, ICommand
    {
        public UpdateFamilyCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var familyId = int.Parse(parameters[0]);

            var familyFound = this.dataFactory.FindFamily(familyId);

            if (familyFound == null)
            {
                throw new EntryNotFoundException($"Family id {familyId} doesn't exist.");
            }

            this.dataFactory.UpdateFamily(familyFound, parameters);
            this.dataFactory.SaveAllChanges();

            return $"Family {familyFound.Id} name changed to {parameters[1]}";
        }
    }
}
