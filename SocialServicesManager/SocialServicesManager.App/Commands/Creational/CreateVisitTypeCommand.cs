using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;

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

            var visitType = this.modelFactory.CreateVisitType(name);

            this.dataFactory.AddVisitType(visitType);
            this.dataFactory.SaveAllChanges();

            return $"Visit type {visitType.Name} created with id {visitType.Id}.";
        }
    }
}
