using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Updating
{
    public class UpdateFamilyNameCommand : Command, ICommand
    {
        private const int ParameterCount = 2;

        public UpdateFamilyNameCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var familyId = int.Parse(parameters[0]);
            var newFamilyName = parameters[1];

            var familyFound = this.DataFactory.FindFamily(familyId);

            if (familyFound == null)
            {
                throw new EntryNotFoundException($"Family id {familyId} not found.");
            }            
            
            this.DataFactory.UpdateFamilyName(familyFound, newFamilyName);
            this.DataFactory.SaveAllChanges();

            return $"Family {familyFound.Id} name changed to {parameters[1]}";
        }
    }
}
