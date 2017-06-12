using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Globalization;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Models;

namespace SocialServicesManager.App.Commands.Updating
{
    public class UpdateChildCommand : UpdatingCommand, ICommand
    {
        private const int ParameterCount = 6;

        public UpdateChildCommand(IModelsFactory modelFactory, IDataFactory dataFactory) 
            : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var childId = int.Parse(parameters[0]);
            var firstName = parameters[1];
            var lastName = parameters[2];
            var gender = parameters[3];
            var birthDate = parameters[4];
            var familyId  = parameters[5];

            var oldChild = this.DataFactory.FindChild(childId);

            if (oldChild == null)
            {
                throw new EntryNotFoundException($"Child id {childId} not found.");
            }

            if (firstName == "null")
            {
                firstName = null;
            }
            else
            {
                this.ValidateName("First name", firstName);
            }

            if (lastName == "null")
            {
                lastName = null;
            }
            else
            {
                this.ValidateName("Last name", lastName);
            }

            Gender parsedGender = null;

            if (gender != "null")
            {
               parsedGender = this.DataFactory.GetGender(gender);
            }
                      
            DateTime? parsedBirthday = null;

            if (birthDate != "null")
            {               
                parsedBirthday = DateTime.ParseExact(birthDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }

            Family familyFound = null;

            if (familyId != "null")
            {
                familyFound = this.DataFactory.FindFamily(int.Parse(familyId));
            }

            var newChild = this.ModelFactory.CreateChild(firstName, lastName, parsedGender, parsedBirthday, familyFound);

            this.DataFactory.UpdateChild(oldChild, newChild);
            this.DataFactory.SaveAllChanges();

            return $"Child with id {oldChild.Id} updated.";
        }
    }
}
