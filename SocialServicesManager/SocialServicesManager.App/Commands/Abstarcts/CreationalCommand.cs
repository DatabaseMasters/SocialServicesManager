using Bytes2you.Validation;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.DataValidation;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class CreationalCommand : Command, ICommand
    {
        protected readonly IModelsFactory ModelFactory;

        public CreationalCommand(IModelsFactory modelFactory, IDataFactory dataFactory) 
            : base(dataFactory)
        {
            Guard.WhenArgument(modelFactory, "modelFactory").IsNull().Throw();
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
