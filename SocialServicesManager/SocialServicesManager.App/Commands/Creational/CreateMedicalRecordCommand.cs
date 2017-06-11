using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.DataValidation;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalRecord : CreationalCommand, ICommand
    {
        private const int ParameterCount = 4;

        public CreateMedicalRecord(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var date = parameters[0];
            int childId = int.Parse(parameters[1]);
            int doctorId = int.Parse(parameters[2]);
            var description = parameters[3];

            var parsedDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            if (parsedDate > DateTime.UtcNow.Date)
            {
                throw new ParameterValidationException("Record date must be in the past.");
            }

            var childFound = this.dataFactory.FindChild(childId);

            if (childFound == null)
            {
                throw new EntryNotFoundException($"Child id {childId} not found.");
            }

            var doctorFound = this.dataFactory.FindMedicalDoctor(doctorId);

            if (doctorFound == null)
            {
                throw new EntryNotFoundException($"Medical doctor id {doctorId} not found.");
            }

            var record = this.modelFactory.CreateMedicalRecord(parsedDate, childId, doctorFound, description);

            this.dataFactory.AddMedicalRecord(record);
            this.dataFactory.SaveAllChanges();

            // TODO Implement command AddDoctorToRecord for adding other doctors

            return $"Medical record with id {record.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            base.ValidateParameters(parameters, paramterCount);

            var description = parameters[3];

            if (description.Length < ModelsConstraints.DescriptionMinLength || description.Length > ModelsConstraints.DescriptionMaxLength)
            {
                throw new ParameterValidationException(string.Format(ValidationText, "Description", ModelsConstraints.DescriptionMinLength, ModelsConstraints.DescriptionMaxLength));
            }
        }
    }
}
