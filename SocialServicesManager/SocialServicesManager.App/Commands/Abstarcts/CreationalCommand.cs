using System.Collections.Generic;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class CreationalCommand : Command, ICommand
    {
        protected readonly IModelsFactory ModelFactory;
        protected readonly IDataFactory DataFactory;

        public CreationalCommand(IModelsFactory modelFactory, IDataFactory dataFactory, int parameterCount) 
            : base(parameterCount)
        {
            this.ModelFactory = modelFactory;
            this.DataFactory = dataFactory;
        }
    }
}
