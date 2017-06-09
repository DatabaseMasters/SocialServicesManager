using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateUserCommand : CreationalCommand, ICommand
    {
        public CreateUserCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var user = this.ModelFactory.CreateUser(parameters[0]);

            this.DataFactory.AddUser(user);
            this.DataFactory.SaveAllChanges();

            return $"User {user.Name} with {user.Id} created";
        }
    }
}
