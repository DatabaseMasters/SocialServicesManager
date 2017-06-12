using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateChildCommand : CreationalCommand, ICommand
    {
        private const int ParameterCount = 5;

        public CreateChildCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var firstName = parameters[0];
            var lastName = parameters[1];
            var gender = parameters[2];
            var birthDate = parameters[3];
            int familyId;

            this.ValidateName("First name", firstName);
            this.ValidateName("Last name", lastName);

            var parsedGender = this.DataFactory.GetGender(gender);

            if (parsedGender == null)
            {
                throw new EntryNotFoundException($"Gender '{gender}' not found. Use 'undefined' if gender is unknown.");
            }

            DateTime? parsedBirthday;

            if (birthDate == "null")
            {
                parsedBirthday = null;
            }
            else
            {
                parsedBirthday = DateTime.ParseExact(birthDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
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

            var child = this.ModelFactory.CreateChild(firstName, lastName, parsedGender, parsedBirthday, familyFound);

            this.DataFactory.AddChild(child);
            this.DataFactory.SaveAllChanges();

            return $"Child {child.FirstName} created with id {child.Id} in family {child.Family.Name}.";
        }
    }
}
