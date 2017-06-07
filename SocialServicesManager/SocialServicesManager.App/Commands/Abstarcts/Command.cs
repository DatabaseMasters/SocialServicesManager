using SocialServicesManager.App.Commands.Contracts;
using System.Collections.Generic;
using System.Data.Entity;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class Command : ICommand
    {
        protected readonly DbContext DbContext;

        public Command(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
