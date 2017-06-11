using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;
using System;
using System.Globalization;
using SocialServicesManager.Data.DataValidation;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateVisitCommand : CreationalCommand, ICommand
    {
        private const int ParameterCount = 5;

        public CreateVisitCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var date = parameters[0];
            int userId = int.Parse(parameters[1]);
            int familyId = int.Parse(parameters[2]);
            var visitType = parameters[3];
            var description = parameters[4];

            var parsedDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            if (parsedDate > DateTime.UtcNow.Date)
            {
                throw new ParameterValidationException("Visit date must be in the past.");
            }

            var typeFound = this.dataFactory.GetVisitType(visitType);
            
            if (typeFound == null)
            {
                throw new EntryNotFoundException($"Visit type {visitType} not found.");
            }

            var visit = this.modelFactory.CreateVisit(parsedDate, userId, familyId, typeFound, description);

            this.dataFactory.AddVisit(visit);
            this.dataFactory.SaveAllChanges();

            return $"Visit on {visit.Date.ToShortDateString()} with id: {visit.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            base.ValidateParameters(parameters, paramterCount);

            var description = parameters[4];

            if (description.Length < ModelsConstraints.DescriptionMinLength || description.Length > ModelsConstraints.DescriptionMaxLength)
            {
                throw new ParameterValidationException(string.Format(ValidationText, "Description", ModelsConstraints.DescriptionMinLength, ModelsConstraints.DescriptionMaxLength));
            }
        }
    }
}