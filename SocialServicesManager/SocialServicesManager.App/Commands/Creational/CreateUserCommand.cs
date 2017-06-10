using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.DataValidation;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateUserCommand : CreationalCommand, ICommand
    {
        public CreateUserCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory, 4)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var username = parameters[0];
            var password = parameters[1];
            var firstName = parameters[2];
            var lastName = parameters[3];



            var user = this.ModelFactory.CreateUser(username,password,firstName,lastName);

            this.DataFactory.AddUser(user);
            this.DataFactory.SaveAllChanges();

            // TODO Add the new properties of User

            return $"User {user.FirstName} with {user.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters)
        {
            base.ValidateParameters(parameters);

            var username = parameters[0];
            var password = parameters[1];
            var firstName = parameters[2];
            var lastName = parameters[3];

            if (username.Length < ModelsConstraints.UsernameMinLength)
            {
                throw new ParameterValidationException($"Username should be longer than {ModelsConstraints.UsernameMinLength}");
            }
            else if (username.Length > ModelsConstraints.UsernameMaxLength)
            {
                throw new ParameterValidationException($"Username should be shorter than {ModelsConstraints.UsernameMaxLength}");
            }

            if (password.Length < ModelsConstraints.PasswordMinLength)
            {
                throw new ParameterValidationException($"Password should be longer than {ModelsConstraints.PasswordMinLength}");
            }
            else if (password.Length > ModelsConstraints.PasswordMaxLength)
            {
                throw new ParameterValidationException($"Password should be shorter than {ModelsConstraints.PasswordMaxLength}");
            }

        }
    }
}
