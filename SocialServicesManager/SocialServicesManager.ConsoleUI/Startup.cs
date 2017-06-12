using Ninject;
using SocialServicesManager.ConsoleUI.Container;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.ConsoleUI
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new SocialServiceNinjectModule());
            var engine = kernel.Get<IEngine>();

            // Sample commands:
            // createaddress townId (name)
            // createaddress 1 (78 Botevgradsko Shose blvd.)
            // createfamily Petrovi
            // createuser Nedialka
            // createvisit date userId familyId visitType (description allows spaces)
            // createvisit 01.01.1999 1 1 HomeVisit (Description with spaces, not tabs)
            // listfamilies
            // updatefamily 1 Petrovi | updatefamily id newName
            // importdata json ./../../../SocialServicesManager.Data/Services/Parser/Data/data.json
            // importdata xml ./../../../SocialServicesManager.Data/Services/Parser/Data/data.xml
            engine.Start();
        }
    }
}
