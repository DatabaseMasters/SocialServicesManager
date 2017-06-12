using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateVisitTypeCommand : CreationalCommand
    {
        private const int ParameterCount = 1;

        public CreateVisitTypeCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var name = parameters[0];

            this.ValidateName("Visit type name", name);

            var visitType = this.ModelFactory.CreateVisitType(name);

            this.DataFactory.AddVisitType(visitType);
            this.DataFactory.SaveAllChanges();

            return $"Visit type {visitType.Name} created with id {visitType.Id}.";
        }
    }
}
