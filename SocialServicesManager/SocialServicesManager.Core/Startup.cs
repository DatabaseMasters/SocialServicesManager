using SocialServicesManager.Core;
using SocialServicesManager.Data;
using SocialServicesManager.Models;
using System.Data.Entity;

namespace SocialServicesManager.ConsoleUI
{
    class Startup
    {
        static void Main(string[] args)
        {
            var db = new SocialServicesDbContext();

            var newUser = new User();
            newUser.Name = "Maria";
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public void Add<T>(DbContext context, T entity)
        {
            //context.Add(entity);
            //context.SaveChanges();
        }
    }
}
