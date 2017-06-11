using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using SocialServicesManager.Data.Services.PdfPageElements;
using System.Collections.Generic;
using System.IO;

namespace SocialServicesManager.Data.Services
{
    public static class ReportCreator
    {
        public static void CreateUserReport(User user, ICollection<Visit> visits, IDataFactory dataFactory)
        {
            FileStream fs = new FileStream("UserReport.pdf", FileMode.Create);

            PdfHeaderFooter headerFooter = new PdfHeaderFooter();

            var doc = PdfProvider.GetPage(fs, headerFooter);

            string[] userTableCells = {"First Name", "Last Name", "Username",
                $"{user.FirstName}" , $"{user.LastName}", $"{user.UserName}" };

            var userTable = PdfProvider.CreateTable(3, userTableCells, 20);

            string[] userVisitsCells = { "Date", "Description", "Visit type", "Family name" };

            var userVisits = PdfProvider.CreateTable(4, userVisitsCells, 50, "User visits table");

            foreach (Visit visit in visits)
            {
                var familyName = dataFactory.FindFamily(visit.FamilyId);
                string[] information = { visit.Date.ToShortDateString(), visit.Description, visit.VisitType.Name, familyName.Name };
                PdfProvider.FillTable(userVisits, information);

                //userVisits.AddCell(visit.Date.ToShortDateString());
                //userVisits.AddCell(visit.Description);
                //userVisits.AddCell(visit.VisitType.Name);
                //userVisits.AddCell(familyName.Name);
            }

            doc.Open();

            doc.Add(userTable);

            doc.Add(userVisits);

            doc.Close();

            fs.Close();
        }
        
    }
}
