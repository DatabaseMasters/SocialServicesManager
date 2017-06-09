using System.Collections.Generic;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class CreationalCommand : ICommand
    {
        protected readonly IModelsFactory ModelFactory;
        protected readonly IDataFactory DataFactory;

        public CreationalCommand(IModelsFactory modelFactory, IDataFactory dataFactory)
        {
            this.ModelFactory = modelFactory;
            this.DataFactory = dataFactory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
