using System.Collections.Generic;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using SocialServicesManager.Data.DataValidation;
using SocialServicesManager.App.Exceptions;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class CreationalCommand : Command, ICommand
    {
        protected readonly IModelsFactory modelFactory;

        public CreationalCommand(IModelsFactory modelFactory, IDataFactory dataFactory) 
            : base(dataFactory)
        {
            this.modelFactory = modelFactory;
        }

        protected void ValidateName(string nameType, string firstName)
        {
            if (firstName.Length < ModelsConstraints.NameMinLenght || firstName.Length > ModelsConstraints.NameMaxLenght)
            {
                throw new ParameterValidationException(string.Format(ValidationText, nameType, ModelsConstraints.NameMinLenght, ModelsConstraints.NameMaxLenght));
            }
        }
    }
}
