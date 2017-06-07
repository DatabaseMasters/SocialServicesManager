using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.Data.Factories;
using System.Data.Entity;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class CreationalCommand : Command, ICommand
    {
        protected readonly IModelsFactory Factory;

        public CreationalCommand(DbContext dbContext, IModelsFactory factory) : base(dbContext)
        {
            this.Factory = factory;
        }
    }
}
