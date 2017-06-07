using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class CreationalCommand : ICommand
    {
        protected readonly IModelsFactory Factory;

        public CreationalCommand(IModelsFactory factory)
        {
            this.Factory = factory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
