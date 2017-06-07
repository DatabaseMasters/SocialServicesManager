using SocialServicesManager.Models;
using System;
using System.Data.Entity;

namespace SocialServicesManager.Data.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly DbContext dbContext;
        public ModelsFactory(SocialServicesDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public SocialServicesDbContext DbContext { get; private set; }

        public string CreateFamily(string name)
        {
            var family = new Family
            {
                Name = name
            };

            this.DbContext.Families.Add(family);
            this.DbContext.SaveChanges();

            return $"Family {family.Name} with id {family.Id} created.";
        }

        public string CreateUser(string name)
        {
            var user = new User
            {
                Name = name
            };

            this.DbContext.Users.Add(user);
            this.DbContext.SaveChanges();

            return $"User {user.Name} with {user.Id} created";
        }
    }
}
