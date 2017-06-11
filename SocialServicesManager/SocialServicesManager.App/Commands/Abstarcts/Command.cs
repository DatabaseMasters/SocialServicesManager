using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class Command : ICommand
    {
        protected const string ValidationText = "{0} should be between {1} and {2} characters long.";
        protected readonly IDataFactory dataFactory;

        public Command(IDataFactory dataFactory)
        {
            this.dataFactory = dataFactory;
        }

        public abstract string Execute(IList<string> parameters);

        protected virtual void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            if (parameters.Count != paramterCount)
            {
                throw new ParameterValidationException($"Command expects {paramterCount} parameters but got {parameters.Count}.");
            }

            if (parameters.Any(p => p == string.Empty))
            {
                throw new ParameterValidationException("Some of the parameters are empty");
            }
        }
    }
}
