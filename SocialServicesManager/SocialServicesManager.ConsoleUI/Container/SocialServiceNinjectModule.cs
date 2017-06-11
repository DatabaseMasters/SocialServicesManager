using Ninject.Modules;
using SocialServicesManager.App;
using SocialServicesManager.App.Commands;
using SocialServicesManager.App.Commands.Creational;
using SocialServicesManager.App.Commands.Deleting;
using SocialServicesManager.App.Commands.Export;
using SocialServicesManager.App.Commands.Listing;
using SocialServicesManager.App.Commands.Updating;
using SocialServicesManager.ConsoleUI.Providers;
using SocialServicesManager.Data;
using SocialServicesManager.Data.Factories;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Data.Entity;

namespace SocialServicesManager.ConsoleUI.Container
{
    public class SocialServiceNinjectModule : NinjectModule
    {
        private const string CreateAddressName = "createaddress";
        private const string CreateChildName = "createchild";
        private const string CreateFamilyName = "createfamily";
        private const string CreateFamilyMemberName = "createfamilymember";
        private const string CreateMedicalDoctorName = "createmedicaldoctor";
        private const string CreateMedicalRecordName = "createmedicalrecord";
        private const string CreateUserName = "createuser";
        private const string CreateVisitName = "createvisit";

        private const string ListChildrenName = "listchildren";
        private const string ListFamiliesName = "listfamilies";

        private const string UpdateChildName = "updatechild";
        private const string UpdateFamilyNameName = "updatefamilyname";
        private const string UpdateFamilyStaffName = "updatefamilystaff";
        private const string DeleteFamilyName = "deletefamily";

        private const string CreateUserReport = "exportuserreport";
        private const string ExportFamilyVisitsReport = "exportfamilyvisitsreport";

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

            this.Bind<ICommand>().To<CreateAddressCommand>().Named(CreateAddressName);
            this.Bind<ICommand>().To<CreateChildCommand>().Named(CreateChildName);
            this.Bind<ICommand>().To<CreateFamilyCommand>().Named(CreateFamilyName);
            this.Bind<ICommand>().To<CreateFamilyMemberCommand>().Named(CreateFamilyMemberName);
            this.Bind<ICommand>().To<CreateMedicalDoctor>().Named(CreateMedicalDoctorName);
            this.Bind<ICommand>().To<CreateMedicalRecord>().Named(CreateMedicalRecordName);
            this.Bind<ICommand>().To<CreateUserCommand>().Named(CreateUserName);
            this.Bind<ICommand>().To<CreateVisitCommand>().Named(CreateVisitName);

            this.Bind<ICommand>().To<ExportUserReport>().Named(CreateUserReport);
            this.Bind<ICommand>().To<ExportFamilyVisitsReport>().Named(ExportFamilyVisitsReport);

            this.Bind<ICommand>().To<ListChildrenCommand>().Named(ListChildrenName);
            this.Bind<ICommand>().To<ListFamiliesCommand>().Named(ListFamiliesName);

            this.Bind<ICommand>().To<UpdateChildCommand>().Named(UpdateChildName);
            this.Bind<ICommand>().To<UpdateFamilyNameCommand>().Named(UpdateFamilyNameName);
            this.Bind<ICommand>().To<UpdateFamilyStaffCommand>().Named(UpdateFamilyStaffName);
            this.Bind<ICommand>().To<DeleteFamilyCommand>().Named(DeleteFamilyName);
        }
    }
}
