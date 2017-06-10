using iTextSharp.text;
using iTextSharp.text.pdf;
using SocialServicesManager.Data.Models;
using System.Collections.Generic;
using System.IO;

namespace SocialServicesManager.Data.Services
{
    public static class ReportCreator
    {
        public static void CreateUserReport(User user, ICollection<Visit> visit)
        {

            FileStream fs = new FileStream("UserReport.pdf", FileMode.Create);

            Document doc = new Document(PageSize.A4.Rotate());

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            doc.Add(new Paragraph("start"));

            doc.Add(new Paragraph("hi"));

            doc.Close();

            fs.Close();
        }
    }
}
