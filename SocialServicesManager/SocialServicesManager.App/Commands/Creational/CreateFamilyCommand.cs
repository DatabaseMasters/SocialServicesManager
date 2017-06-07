using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateFamilyCommand : CreationalCommand, ICommand
    {
        public CreateFamilyCommand(IModelsFactory factory) : base(factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var result = this.Factory.CreateFamily(parameters[0]);

            return result;
        }
    }
}
