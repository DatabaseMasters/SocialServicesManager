using SocialServicesManager.App.Commands.Abstarcts;
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

            var doctor = this.DataFactory.GetMedicalDoctor(doctorId);

            if (doctor == null)
            {
                // Custom exception;
            }

            var record = this.ModelFactory.CreateMedicalRecord(description, childId, doctor);


            this.DataFactory.AddMedicalRecord(record);
            this.DataFactory.SaveAllChanges();

            return $"Medical record with id {record.Id} created.";
        }
    }
}
