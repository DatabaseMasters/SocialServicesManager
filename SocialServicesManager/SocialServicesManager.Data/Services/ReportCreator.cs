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

            var doc = PdfProvider.GetPage(fs);

            var userTable = new PdfPTable(3);
            
            userTable.AddCell("First Name");
            userTable.AddCell("Last Name");
            userTable.AddCell("Username");

            userTable.AddCell($"{user.FirstName}");
            userTable.AddCell($"{user.LastName}");
            userTable.AddCell($"{user.UserName}");

            var userVisits = new PdfPTable(4);

            foreach (Visit visit in visits)
            {
                Console.WriteLine(visit);
                userVisits.AddCell(visit.Date.ToShortDateString());
                userVisits.AddCell(visit.Description);
                userVisits.AddCell(visit.VisitType.Name);
                var familyName = dataFactory.FindFamily(visit.FamilyId);
                userVisits.AddCell(familyName.Name);
            }


            doc.Open();

            doc.Add(userTable);

            doc.Add(userVisits);

            doc.Close();

            fs.Close();
        }
    }
}
