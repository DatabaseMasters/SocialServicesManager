using SocialServicesManager.App;
using SocialServicesManager.App.Commands;
using SocialServicesManager.ConsoleUI.Providers;
using SocialServicesManager.Data;
using SocialServicesManager.Data.Factories;

namespace SocialServicesManager.ConsoleUI
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            // TODO Remove reference to Data layer?
            var sqlDbContext = new SQLServerDbContext();
            var postgreDbContext = new PostgreDbContext();
            var modelsFacotry = new ModelsFactory(sqlDbContext, postgreDbContext);
            var cmdFactory = new CommandsFactory(modelsFacotry);
            var processor = new CommandProcessor(cmdFactory);

            var engine = new Engine(reader, writer, processor);

            //Sample commands:
            //"createfamily Petrovi";
            //"createuser Nedialka";
            //createvisit 01.01.1999 description 1 1 HomeVisit

            engine.Start();
        }
    }
}
