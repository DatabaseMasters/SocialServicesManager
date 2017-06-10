using iTextSharp.text;
using iTextSharp.text.pdf;
using SocialServicesManager.Data.Models;
using SocialServicesManager.Data.Services.PdfPageElements;
using System.Collections.Generic;
using System.IO;

namespace SocialServicesManager.Data.Services
{
    public static class ReportCreator
    {
        public static void CreateUserReport(User user, ICollection<Visit> visit)
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


            doc.Open();

            doc.Add(userTable);

            doc.Close();

            fs.Close();
        }
    }
}
