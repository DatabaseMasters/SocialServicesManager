using SocialServicesManager.Core;
using SocialServicesManager.Data;
using SocialServicesManager.Models;

namespace SocialServicesManager.ConsoleUI
{
    class Startup
    {
        static void Main(string[] args)
        {
            var db = new SQLServerDbContext();

            var newUser = new User();
            newUser.Name = "Maria";
           // db.Users.Add();
        }
    }
}
