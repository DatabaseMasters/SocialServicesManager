using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateUserCommand : CreationalCommand, ICommand
    {
        public CreateUserCommand(IModelsFactory factory)
            : base(factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var createdUser = this.Factory.CreateUser(parameters[0]);

            return $"User {createdUser.Name} with {createdUser.Id} created";
        }
    }
}
