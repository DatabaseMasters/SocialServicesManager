using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Text;

namespace SocialServicesManager.App.Commands.Listing
{
    public class ListUsersCommand : Command, ICommand
    {
        public ListUsersCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            var users = this.DataFactory.GetAllUsers();

            if (users.Count == 0)
            {
                return "There are no users in this database.";
            }

            builder.AppendLine(string.Empty);

            builder.AppendLine(string.Format($"| {"Id",+2} | {"First Name",-10} | {"Last Name",-10} | {"Username",-10} |"));

            builder.AppendLine(new string('-', 40));

            foreach (var user in users)
            {
                builder.AppendLine($"| {user.Id,+2} | {user.FirstName,-10} | {user.LastName,-10} | {user.UserName,-10} |");
            }

            return builder.ToString();
        }
    }
}
