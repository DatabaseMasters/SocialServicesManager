using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalRecord : CreationalCommand, ICommand
    {
        private const int ParameterCount = 3;

        public CreateMedicalRecord(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            var date = parameters[0];
            int childId = int.Parse(parameters[1]);
            int doctorId = int.Parse(parameters[2]);
            var description = parameters[3];

            var parsedDate = DateTime.Parse(date);

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

            var record = this.ModelFactory.CreateMedicalRecord(parsedDate, childId, doctorFound, description);

            this.dataFactory.AddMedicalRecord(record);
            this.dataFactory.SaveAllChanges();

            // TODO Implement command AddDoctorToRecord for adding other doctors

            return $"Medical record with id {record.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            base.ValidateParameters(parameters, paramterCount);
        }
    }
}
