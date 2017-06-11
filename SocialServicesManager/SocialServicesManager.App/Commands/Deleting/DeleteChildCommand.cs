using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App.Commands.Deleting
{
    public class DeleteChildCommand : Command, ICommand
    {
        public DeleteChildCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var childId = int.Parse(parameters[0]);

            var childFound = this.dataFactory.FindChild(childId);

            if (childFound == null)
            {
                throw new EntryPointNotFoundException($"Child with id {childId} not found.");
            }

            this.dataFactory.DeleteChild(childFound);
            this.dataFactory.SaveAllChanges();

            return $"Child {childFound.FirstName} with id {childFound.Id} deleted.";
        }
    }
}
