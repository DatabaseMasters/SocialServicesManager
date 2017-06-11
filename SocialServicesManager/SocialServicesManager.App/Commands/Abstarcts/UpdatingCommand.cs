using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.DataValidation;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class UpdatingCommand : Command, ICommand
    {
        protected readonly IModelsFactory ModelFactory;

        public UpdatingCommand(IModelsFactory modelFactory, IDataFactory dataFactory)
            : base(dataFactory)
        {
            this.ModelFactory = modelFactory;
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
