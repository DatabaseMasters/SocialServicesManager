using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateFamilyMemberCommand : CreationalCommand, ICommand
    {
        private const int ParameterCount = 5;

        public CreateFamilyMemberCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var firstName = parameters[0];
            var lastName = parameters[1];
            var gender = parameters[2];
            int addressId;
            int familyId;

            this.ValidateName("First name", firstName);
            this.ValidateName("Last name", lastName);

            var parsedGender = this.DataFactory.GetGender(gender);

            if (parsedGender == null)
            {
                throw new EntryNotFoundException($"Gender '{gender}' not found. Use 'undefined' if gender is unknown.");
            }

            if (!int.TryParse(parameters[3], out addressId))
            {
                throw new ParameterValidationException("Address id should be a number.");
            }

            var addressFound = this.DataFactory.FindAddress(addressId);

            if (addressFound == null)
            {
                throw new EntryNotFoundException($"Address id {addressId} not found.");
            }

            if (!int.TryParse(parameters[4], out familyId))
            {
                throw new ParameterValidationException("Family id should be a number.");
            }

            var familyFound = this.DataFactory.FindFamily(familyId);

            if (familyFound == null)
            {
                throw new EntryNotFoundException($"Family id {familyId} not found.");
            }

            var familyMember = this.ModelFactory.CreateFamilyMember(firstName, lastName, parsedGender, addressFound, familyFound);

            this.DataFactory.AddFamilyMember(familyMember);
            this.DataFactory.SaveAllChanges();

            return $"Family member {familyMember.FirstName} {familyMember.LastName} created with id {familyMember.Id}.";
        }        
    }
}
