using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
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
            var description = parameters[0];
            int childId = int.Parse(parameters[1]);
            int doctorId = int.Parse(parameters[2]);

            var doctorFound = this.dataFactory.GetMedicalDoctor(doctorId);

            if (doctorFound == null)
            {
                throw new EntryNotFoundException($"Medical doctor id {doctorId} not found.");
            }

            var record = this.ModelFactory.CreateMedicalRecord(childId, doctorFound, description);

            this.dataFactory.AddMedicalRecord(record);
            this.dataFactory.SaveAllChanges();

            return $"Medical record with id {record.Id} created.";
        }
    }
}
