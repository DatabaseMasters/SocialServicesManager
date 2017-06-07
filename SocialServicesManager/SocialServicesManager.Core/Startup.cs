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
            var db = new PostgreDBContext();

            var visit = new Visit();

            visit.Date = new System.DateTime(1992, 1, 1);
            visit.UserId = 1;
            visit.FamilyId = 1;
            db.Visits.Add(visit);
            db.SaveChanges();
        }
    }
}
