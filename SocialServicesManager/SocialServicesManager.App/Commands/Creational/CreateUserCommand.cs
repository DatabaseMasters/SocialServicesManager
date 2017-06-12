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
        private const int ParameterCount = 4;

        public CreateUserCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var username = parameters[0];
            var password = parameters[1];
            var firstName = parameters[2];
            var lastName = parameters[3];
            
            this.ValidateName("First name", firstName);
            this.ValidateName("Last name", lastName);

            var usernameFound = this.DataFactory.GetUserByUsername(username);

            if (usernameFound != null)
            {
                throw new ParameterValidationException("Username already exists.");
            }

            var user = this.ModelFactory.CreateUser(username, password, firstName, lastName);

            this.DataFactory.AddUser(user);
            this.DataFactory.SaveAllChanges();

            return $"User {user.FirstName} with {user.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            base.ValidateParameters(parameters, ParameterCount);

            var username = parameters[0];
            var password = parameters[1];

            if (username.Length < ModelsConstraints.UsernameMinLength || username.Length > ModelsConstraints.UsernameMaxLength)
            {
                throw new ParameterValidationException(string.Format(ValidationText, "Username", ModelsConstraints.UsernameMinLength, ModelsConstraints.UsernameMaxLength));
            }

            if (password.Length < ModelsConstraints.PasswordMinLength || password.Length > ModelsConstraints.PasswordMaxLength)
            {
                throw new ParameterValidationException(string.Format(ValidationText, "Password", ModelsConstraints.PasswordMinLength, ModelsConstraints.PasswordMaxLength));
            }
        }
    }
}
