using System;
using System.Collections.Generic;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Exceptions;
using System.Linq;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class Command : ICommand
    {
        protected readonly int ParameterCount;

        public Command(int parameterCount)
        {
            this.ParameterCount = parameterCount;
        }

        public abstract string Execute(IList<string> parameters);

        protected virtual void ValidateParameters(IList<string> parameters)
        {
            if (parameters.Count != ParameterCount)
            {
                throw new ParameterValidationException($"Command expects {this.ParameterCount} parameters but got {parameters.Count}.");
            }

            if (parameters.Any(p => p == string.Empty))
            {
                throw new ParameterValidationException("Some of the parameters are empty");
            }
        }
    }
}
