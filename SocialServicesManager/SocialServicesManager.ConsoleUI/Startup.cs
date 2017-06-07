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
            var dbContext = new SQLServerDbContext();
            var modelsFacotry = new ModelsFactory(dbContext);
            var cmdFactory = new CommandsFactory(modelsFacotry);
            var processor = new CommandProcessor(cmdFactory);

            var engine = new Engine(reader, writer, processor);

            //Sample commands:
            //"createfamily Petrovi";
            //"createuser Nedialka";

            engine.Start();
        }
    }
}
