using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Interfaces;
using System.Text;
using SocialServicesManager.Data.Factories.Contracts;

namespace SocialServicesManager.App.Commands.Listing
{
    public class ListFamiliesCommand : ListingCommand, ICommand
    {
        public ListFamiliesCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        // TODO Add validation logic
        public override string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            var families = this.dataFactory.GetAllFamilies();

            builder.AppendLine("");

            foreach (var family in families)
            {
                builder.AppendLine($"Id: {family.Id}; Name: {family.Name}");
            }

            if (builder.ToString() == String.Empty)
            {
                return "There are no families in the database.";
            }

            return builder.ToString().TrimEnd();
        }
    }
}
