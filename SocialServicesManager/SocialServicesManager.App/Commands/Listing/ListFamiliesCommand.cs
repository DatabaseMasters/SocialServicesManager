using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SocialServicesManager.App.Commands.Listing
{
    public class ListFamiliesCommand : Command, ICommand
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

            builder.AppendLine(string.Format($"| {"Id", +3} | {"Name", -10} |"));
            builder.AppendLine("-------------------");

            foreach (var family in families)
            {
                builder.AppendLine($"| {family.Id,+3} | {family.Name,-10} |");
            }

            if (builder.ToString() == string.Empty)
            {
                return "There are no families in the database.";
            }

            return builder.ToString().TrimEnd();
        }
    }
}
