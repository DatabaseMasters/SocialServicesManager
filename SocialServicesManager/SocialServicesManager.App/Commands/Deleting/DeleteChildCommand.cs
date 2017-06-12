using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App.Commands.Deleting
{
    public class DeleteChildCommand : Command, ICommand
    {
        private const int ParameterCount = 1;

        public DeleteChildCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var childId = int.Parse(parameters[0]);

            var childFound = this.DataFactory.FindChild(childId);

            if (childFound == null)
            {
                throw new EntryPointNotFoundException($"Child with id {childId} not found.");
            }

            this.DataFactory.DeleteChild(childFound);
            this.DataFactory.SaveAllChanges();

            return $"Child {childFound.FirstName} with id {childFound.Id} deleted.";
        }
    }
}
