using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories;
using System.Data.Entity;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateFamilyCommand : CreationalCommand, ICommand
    {
        public CreateFamilyCommand(DbContext dbContext, IModelsFactory factory) : base(dbContext, factory)
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
