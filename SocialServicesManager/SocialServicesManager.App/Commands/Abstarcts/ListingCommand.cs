using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public class ListingCommand: ICommand
    {
        public ListingCommand(IContextFactory contextFactory)
        {

        }

        // TODO Add validation logic
        public string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
