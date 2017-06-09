using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateVisitCommand : CreationalCommand, ICommand
    {
        public CreateVisitCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var date = parameters[0];
            var description = parameters[1];
            int userId = int.Parse(parameters[2]);
            int familyId = int.Parse(parameters[3]);
            var visitType = parameters[4];

            var typeFound = this.DataFactory.GetVisitType(visitType);

            if (typeFound == null)
            {
                // Custom exception;
            }

            var visit = this.ModelFactory.CreateVisit(date, description, userId, familyId, typeFound);

            this.DataFactory.AddVisit(visit);
            this.DataFactory.SaveAllChanges();

            return $"Visit on {visit.Date} with id: {visit.Id} was created";
        }
    }
}