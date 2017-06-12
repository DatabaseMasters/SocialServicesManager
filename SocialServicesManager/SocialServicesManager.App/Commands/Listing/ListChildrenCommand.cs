using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Text;

namespace SocialServicesManager.App.Commands.Listing
{
    public class ListChildrenCommand : Command, ICommand
    {
        public ListChildrenCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            var children = this.DataFactory.GetAllChildren();

            if (children.Count == 0)
            {
                return "There are no children in this database.";
            }

            builder.AppendLine();
            builder.AppendLine(string.Format($"| {"Id",+2} | {"First Name",-10} | {"Last Name",-10} | {"Birthday",-10} | {"Gender",-10} | {"Family",-10} |"));
            builder.AppendLine(new string('-', 70));

            foreach (var child in children)
            {
                var birthday = child.BirthDate != null ? child.BirthDate.Value.ToShortDateString() : "n/a";

                builder.AppendLine($"| {child.Id,+2} | {child.FirstName,-10} | {child.LastName,-10} | {birthday,-10} | {child.Gender.Name,-10} | {child.Family.Name,-10} |");
            }

            return builder.ToString();
        }
    }
}
