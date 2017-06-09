using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateVisitCommand : CreationalCommand, ICommand
    {
        public CreateVisitCommand(IModelsFactory factory) : base(factory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var result = this.Factory.CreateVisit(parameters[0], parameters[1], int.Parse(parameters[2]), int.Parse(parameters[3]), parameters[4]);

            return result;
        }
    }
}