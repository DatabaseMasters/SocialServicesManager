using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Text;

namespace SocialServicesManager.App.Commands.Listing
{
    public class ListVisitTypesCommand : Command, ICommand
    {
        public ListVisitTypesCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();

            var visitTypes = this.DataFactory.GetAllVisitTypes();

            if (visitTypes.Count == 0)
            {
                return "There are no visit types in this database.";
            }

            foreach (var visitType in visitTypes)
            {
                builder.AppendLine($"{visitType.Id} {visitType.Name}");
            }

            return builder.ToString();
        }
    }
}
