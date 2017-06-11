using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Exceptions;

namespace SocialServicesManager.App.Commands.Updating
{
    public class UpdateFamilyStaffCommand : Command, ICommand
    {
        private const int ParameterCount = 2;

        public UpdateFamilyStaffCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var familyId = int.Parse(parameters[0]);
            var newStaffId = int.Parse(parameters[1]);

            var familyFound = this.dataFactory.FindFamily(familyId);

            if (familyFound == null)
            {
                throw new EntryNotFoundException($"Family id {familyId} not found.");
            }

            var staffFound = this.dataFactory.FindUser(newStaffId);

            if (staffFound == null)
            {
                throw new EntryNotFoundException($"Staff id {newStaffId} not found.");
            }

            this.dataFactory.UpdateFamilyStaff(familyFound, staffFound);

            return $"Family {familyFound.Name} with id {familyFound.Id} staff member updated to {staffFound.FirstName} with id {staffFound.Id}";
        }
    }
}
