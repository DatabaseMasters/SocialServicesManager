using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;
using System.Text;

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

            builder.AppendLine(string.Empty);

            foreach (var family in families)
            {                
                builder.AppendLine($"Id: {family.Id,+3} | Name: {family.Name,-10}");
            }

            if (builder.ToString() == string.Empty)
            {
                return "There are no families in the database.";
            }

            return builder.ToString().TrimEnd();
        }
    }
}
