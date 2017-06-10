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

            doc.Open();

            doc.Add(new Paragraph("a"));

            doc.Close();

            fs.Close();
        }
    }
}
