using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalRecord : CreationalCommand, ICommand
    {
        public CreateMedicalRecord(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            var description = parameters[0];
            int childId = int.Parse(parameters[1]);
            int doctorId = int.Parse(parameters[2]);

            var doctorFound = this.DataFactory.GetMedicalDoctor(doctorId);

            if (doctorFound == null)
            {
                throw new EntryNotFoundException($"Medical doctor id {doctorId} not found.");
            }

            var record = this.ModelFactory.CreateMedicalRecord(description, childId, doctorFound);

            this.DataFactory.AddMedicalRecord(record);
            this.DataFactory.SaveAllChanges();

            return $"Medical record with id {record.Id} created.";
        }
    }
}
