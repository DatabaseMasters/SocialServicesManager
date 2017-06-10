using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalDoctor : CreationalCommand, ICommand
    {
        public CreateMedicalDoctor(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory, 4)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var phoneNumber = parameters[2];
            var specialty = parameters[3];

            var doctor = this.ModelFactory.CreateMedicalDoctor(firstName, lastName, phoneNumber, specialty);

            this.DataFactory.AddMedicalDoctor(doctor);
            this.DataFactory.SaveAllChanges();

            // TODO add all new Medical doctor properties
            return $"Medical doctor {doctor.FirstName} with id {doctor.Id} created.";

        }
    }
}
