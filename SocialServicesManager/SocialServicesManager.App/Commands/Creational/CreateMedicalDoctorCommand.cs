using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalDoctor : CreationalCommand, ICommand
    {
        public CreateMedicalDoctor(IModelsFactory factory) : base(factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            return this.Factory.CreateMedicalDoctor(parameters[0]);
        }
    }
}
