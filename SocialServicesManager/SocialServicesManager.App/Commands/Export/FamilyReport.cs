using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Interfaces;
using SocialServicesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialServicesManager.App.Commands.Export
{
    public class FamilyReport : ExporterCommand, ICommand
    {
        public FamilyReport(IDataFactory dataFactory) 
            : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            ICollection<Family> all = this.dataFactory.ExportAllFamilies();

            //StringBuilder sb = new StringBuilder();

            //foreach (Family family in all)
            //{
            //    sb.AppendLine($"Family {family.Name} with id {family.Id}");
            //}

            return "Done.";
        }
    }
}
