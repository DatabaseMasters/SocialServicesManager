using Bytes2you.Validation;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class ExporterCommand : ICommand
    {
        protected readonly IDataFactory DataFactory;

        public ExporterCommand(IDataFactory dataFactory)
        {
            Guard.WhenArgument(dataFactory, "dataFactory").IsNull().Throw();
            this.DataFactory = dataFactory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
