using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalDoctor : CreationalCommand, ICommand
    {
        public CreateMedicalDoctor(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var doctor = this.ModelFactory.CreateMedicalDoctor(parameters[0]);

            this.DataFactory.AddMedicalDoctor(doctor);
            this.DataFactory.SaveAllChanges();

            return $"Medical doctor {doctor.Name} with id {doctor.Id} created.";

        }
    }
}
