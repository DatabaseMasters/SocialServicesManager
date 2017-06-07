using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;
using System.Collections.Generic;
using System.Data.Entity;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateUserCommand : CreationalCommand, ICommand
    {
        public CreateUserCommand(DbContext dbContext, IModelsFactory factory)
            : base(dbContext, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var result = this.Factory.CreateUser(parameters[0]);

            return result;
        }
    }
}
