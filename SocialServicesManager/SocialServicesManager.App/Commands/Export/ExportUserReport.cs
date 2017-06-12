﻿using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Services;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Export
{
    public class ExportUserReport : ExporterCommand, ICommand
    {
        public ExportUserReport(IDataFactory dataFactory) 
            : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var userId = int.Parse(parameters[0]);

            // TODO remove comment to work normally
            var user = this.dataFactory.FindUser(userId);
            var userVisits = this.dataFactory.GetUserVisits(user.Id);

            ReportCreator.CreateUserReport(user, userVisits, this.dataFactory);

            return "Done";
        }
    }
}
