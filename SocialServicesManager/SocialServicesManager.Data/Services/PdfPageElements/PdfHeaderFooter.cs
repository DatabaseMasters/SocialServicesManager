using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SocialServicesManager.Data.Services.PdfPageElements
{
    public class PdfHeaderFooter : PdfPageEventHelper
    {
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            float[] width = { 20, 80 };

            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetTotalWidth(width);

            var img = Image.GetInstance(ReportCreator.GetDestinationFolder("social_services.jpg"));

            img.ScaleAbsolute(150, 97);

            table.AddCell(new PdfPCell(img) { BorderWidth = 0 });

            var header = new Paragraph(
                16, 
                "Social Service Manager", 
                new Font(Font.FontFamily.TIMES_ROMAN, 38));

            table.AddCell(new PdfPCell(header)
            {
                BorderWidth = 0,
                HorizontalAlignment = 1,
                VerticalAlignment = Element.ALIGN_MIDDLE
            });

            document.Add(table);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            Rectangle rect = writer.GetBoxSize("art");
            var pagenumber = document.PageNumber;
            ColumnText.ShowTextAligned(
                writer.DirectContent,
                Element.ALIGN_CENTER, 
                new Phrase($"page {pagenumber}"),
                (rect.Left + rect.Right) / 2,
                rect.Bottom - 18, 
                0);
        }
    }
}
