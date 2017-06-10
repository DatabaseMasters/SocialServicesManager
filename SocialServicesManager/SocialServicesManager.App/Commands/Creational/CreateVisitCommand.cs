using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateVisitCommand : CreationalCommand, ICommand
    {
        private const int ParameterCount = 5;

        public CreateVisitCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            var date = parameters[0];
            int userId = int.Parse(parameters[1]);
            int familyId = int.Parse(parameters[2]);
            var visitType = parameters[3];
            var description = parameters[4];

            var typeFound = this.dataFactory.GetVisitType(visitType);
            
            if (typeFound == null)
            {
                throw new EntryNotFoundException($"Visit type {visitType} not found.");
            }

            var visit = this.ModelFactory.CreateVisit(date, userId, familyId, typeFound, description);

            this.dataFactory.AddVisit(visit);
            this.dataFactory.SaveAllChanges();

            return $"Visit on {visit.Date} with id: {visit.Id} created.";
        }
    }
}