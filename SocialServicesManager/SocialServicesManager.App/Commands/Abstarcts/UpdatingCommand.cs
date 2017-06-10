using System;
using System.Collections.Generic;
using SocialServicesManager.Interfaces;
using SocialServicesManager.Data.Factories.Contracts;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class UpdatingCommand : ICommand
    {
        protected readonly IDataFactory dataFactory;

        public UpdatingCommand(IDataFactory dataFactory)
        {
            this.dataFactory = dataFactory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
