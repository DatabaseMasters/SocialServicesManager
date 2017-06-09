using Ninject.Modules;
using SocialServicesManager.ConsoleUI.Providers;
using SocialServicesManager.App;
using SocialServicesManager.App.Providers.Contracts;
using SocialServicesManager.Data.Factories;
using System.Data.Entity;
using SocialServicesManager.Data;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.App.Commands;
using SocialServicesManager.App.Commands.Creational;
using SocialServicesManager.App.Commands.Abstarcts;

namespace SocialServicesManager.ConsoleUI.Container
{
    public class SocialServiceNinjectModule : NinjectModule
    {
        private const string CreateFamilyName = "CreateFamily";
        private const string CreateUserName = "CreateUser";
        private const string CreateVisitName = "CreateVisit";

        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            
            this.Kernel.Bind<DbContext>().To<SQLServerDbContext>().WithConstructorArgument("sqlDbContext");
            this.Kernel.Bind<DbContext>().To<PostgreDbContext>().WithConstructorArgument("postgreDbContext");
            this.Kernel.Bind<DbContext>().To<SqliteDbContext>().WithConstructorArgument("sqliteDbContext");
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();

            this.Bind<ICommandsFactory>().To<CommandsFactory>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            //this.Bind<CreationalCommand>().To<CreateFamilyCommand>().Named(CreateFamilyName);
            //this.Bind<ICommand>().To<CreateUserCommand>().Named(CreateUserName);
            //this.Bind<ICommand>().To<CreateVisitCommand>().Named(CreateVisitName);

        }
    }
}
