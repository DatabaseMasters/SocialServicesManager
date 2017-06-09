using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalRecord : CreationalCommand, ICommand
    {
        public CreateMedicalRecord(IModelsFactory factory) : base(factory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            return this.Factory.CreateMedicalRecord(parameters[0], int.Parse(parameters[1]), int.Parse(parameters[2]));
        }
    }
}
