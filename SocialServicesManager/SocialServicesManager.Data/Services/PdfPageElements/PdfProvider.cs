using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SocialServicesManager.Data.Services.PdfPageElements
{
    public class PdfProvider
    {
        public static Document GetPage(FileStream fs)
        {
            Document doc = new Document(PageSize.A4.Rotate());

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            PdfHeaderFooter header = new PdfHeaderFooter();

            writer.PageEvent = header;
            Rectangle art = new Rectangle(50, 50, doc.Bottom, doc.Left);
            writer.SetBoxSize("art", art);

            return doc;
        }
    }
}
