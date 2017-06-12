using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Services.PdfReport;
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
            var family = this.DataFactory.FindFamily(familyId);
            var familyVisits = this.DataFactory.GetFamilyVisits(family);

            ReportCreator.CreateFamilyVisitsReport(family, familyVisits);

            return "Done";
        }
    }
}
