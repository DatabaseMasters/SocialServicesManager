using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Exceptions;
using System.Globalization;

namespace SocialServicesManager.App.Commands.Updating
{
    public class UpdateVisitCommand : UpdatingCommand, ICommand
    {
        private const int ParameterCount = 6;

        public UpdateVisitCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var visitId = int.Parse(parameters[0]);
            var date = parameters[1];
            var userId = parameters[2];
            var familyId = parameters[3];
            var visitType = parameters[4];
            var description = parameters[5];

            var oldVisit = this.dataFactory.FindVisit(visitId);

            if (oldVisit == null)
            {
                throw new EntryNotFoundException($"Visit it {visitId} not found.");
            }

            DateTime parsedDate = oldVisit.Date;

            if (date != "null")
            {
                parsedDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }

            int parsedUserId = oldVisit.UserId;

            if (userId != "null")
            {
                parsedUserId = int.Parse(userId);
            }

            int parsedFamilyId = oldVisit.FamilyId;

            if (familyId != "null")
            {
                parsedFamilyId = int.Parse(familyId);
            }

            var typeFound = oldVisit.VisitType;

            if (visitType != "null")
            {
                typeFound = this.dataFactory.GetVisitType(visitType);
            }

            if (typeFound == null)
            {
                throw new EntryNotFoundException($"Visit type {visitType} not found.");
            }

            var newDescription = oldVisit.Description;
            var test = (description == "null");

            if (description != "null")
            {
                newDescription = description;
            }

            var newVisit = this.ModelFactory.CreateVisit(parsedDate, parsedUserId, parsedFamilyId, typeFound, newDescription);

            this.dataFactory.UpdateVisit(oldVisit, newVisit);
            this.dataFactory.SaveAllChanges();

            return $"Visit with id {oldVisit.Id} updated.";
        }
    }
}
