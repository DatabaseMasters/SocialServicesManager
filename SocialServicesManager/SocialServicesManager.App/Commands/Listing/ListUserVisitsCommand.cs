using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Text;

namespace SocialServicesManager.App.Commands.Listing
{
    public class ListUserVisitsCommand : Command, ICommand
    {
        private const int ParameterCount = 1;

        public ListUserVisitsCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var userId = int.Parse(parameters[0]);
            var user = this.DataFactory.FindUser(userId);
            if (user == null)
            {
                return $"User id {userId} not found.";
            }

            var visits = this.DataFactory.GetUserVisits(userId);
            if (visits.Count == 0)
            {
                return $"User {user.UserName} has no visits.";
            }

            var builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine($"Visits for staff member: {user.FirstName} {user.LastName}, id {user.Id}");
            builder.AppendLine();
            builder.AppendLine(string.Format($"| {"Id",+2} | {"Date",-8} | {"Family",-10} | {"Type", -15} | {"Description",-25} |"));
            builder.AppendLine(new string('-', 60));

            foreach (var visit in visits)
            {
                // TODO Find a way to reduce calls to database.
                var family = this.DataFactory.GetFamilyName(visit.FamilyId) ?? "n/a";

                builder.AppendLine($"| {visit.Id,+2} | {visit.Date.ToShortDateString(),-8} | {family,-10} | {visit.VisitType.Name, -15} | {visit.Description,-25} |");
            }
            
            return builder.ToString();
        }
    }
}
