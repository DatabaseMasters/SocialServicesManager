using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Services;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Export
{
    public class ExportFamilyVisitsReport : ExporterCommand, ICommand
    {
        public ExportFamilyVisitsReport(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var familyId = int.Parse(parameters[0]);
            var family = this.dataFactory.FindFamily(familyId);
            var familyVisits = this.dataFactory.GetFamilyVisits(family);

            ReportCreator.CreateFamilyVisitsReport(family, familyVisits);

            return "Done";
        }
    }
}
