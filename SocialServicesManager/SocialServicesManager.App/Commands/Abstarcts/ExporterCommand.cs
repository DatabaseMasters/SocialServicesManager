﻿using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class ExporterCommand : ICommand
    {
        protected readonly IDataFactory dataFactory;

        public ExporterCommand(IDataFactory dataFactory)
        {
            this.dataFactory = dataFactory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}