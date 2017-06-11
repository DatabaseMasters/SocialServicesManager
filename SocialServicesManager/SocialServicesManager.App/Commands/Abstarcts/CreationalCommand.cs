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
            this.ModelFactory = modelFactory;
        }
    }
}
