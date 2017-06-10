using Ninject.Modules;
using System.Data.Entity;
using SocialServicesManager.App;
using SocialServicesManager.App.Commands;
using SocialServicesManager.App.Commands.Creational;
using SocialServicesManager.ConsoleUI.Providers;
using SocialServicesManager.Data;
using SocialServicesManager.Data.Factories;
using SocialServicesManager.Interfaces;
using SocialServicesManager.App.Commands.Listing;
using SocialServicesManager.App.Commands.Updating;

namespace SocialServicesManager.ConsoleUI.Container
{
    public class SocialServiceNinjectModule : NinjectModule
    {
        private const string CreateFamilyName = "createfamily";
        private const string CreateMedicalDoctorName = "createmedicaldoctor";
        private const string CreateMedicalRecordName = "createmedicalrecord";
        private const string CreateUserName = "createuser";
        private const string CreateVisitName = "createvisit";
        private const string ListFamiliesName = "listfamilies";
        private const string UpdateFamilyName = "updatefamily";

        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            
            this.Kernel.Bind<DbContext>().To<SQLServerDbContext>().WithConstructorArgument("sqlDbContext");
            this.Kernel.Bind<DbContext>().To<PostgreDbContext>().WithConstructorArgument("postgreDbContext");
            this.Kernel.Bind<DbContext>().To<SqliteDbContext>().WithConstructorArgument("sqliteDbContext");
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();
            this.Bind<IDataFactory>().To<DataFactory>().InSingletonScope();

            this.Bind<ICommandsFactory>().To<CommandsFactory>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            this.Bind<IServiceLocator>().To<ServiceLocator>();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<ICommand>().To<CreateFamilyCommand>().Named(CreateFamilyName);
            this.Bind<ICommand>().To<CreateMedicalDoctor>().Named(CreateMedicalDoctorName);
            this.Bind<ICommand>().To<CreateMedicalRecord>().Named(CreateMedicalRecordName);
            this.Bind<ICommand>().To<CreateUserCommand>().Named(CreateUserName);
            this.Bind<ICommand>().To<CreateVisitCommand>().Named(CreateVisitName);

            this.Bind<ICommand>().To<ListFamiliesCommand>().Named(ListFamiliesName);

            this.Bind<ICommand>().To<UpdateFamilyCommand>().Named(UpdateFamilyName);

        }
    }
}
