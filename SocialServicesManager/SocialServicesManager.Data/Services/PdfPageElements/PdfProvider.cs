using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SocialServicesManager.Data.Services.PdfPageElements
{
    public class PdfProvider
    {
        public static Document GetPage(FileStream fs, PdfHeaderFooter headerFooter)
        {
            Document doc = new Document(PageSize.A4.Rotate());

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            writer.PageEvent = headerFooter;
            Rectangle art = new Rectangle(50, 50, doc.Bottom, doc.Left);
            writer.SetBoxSize("art", art);

            return doc;
        }

        public static PdfPTable CreateTable(
                                    int numberOfColumns, 
                                    string[] headerCellsText,
                                    int spacingBefore, 
                                    string heading = null)
        {
            PdfPTable table = new PdfPTable(numberOfColumns)
            {
                HorizontalAlignment = 1,
                SpacingBefore = spacingBefore
            };

            if (heading != null)
            {
                table.AddCell(new PdfPCell(new Phrase(heading)) { HorizontalAlignment = 1, Colspan = numberOfColumns, MinimumHeight = 25, VerticalAlignment = Element.ALIGN_MIDDLE });
            }

            foreach (string text in headerCellsText)
            {
                table.AddCell(new PdfPCell(new Phrase(text))
                {
                    HorizontalAlignment = 1,
                    MinimumHeight = 25,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                });
            }

            return table;
        }

        /// <summary>
        /// Provided with array of strings, this method fill the table,
        /// with center alignment. 0 - left, 1 - center, 2 - right
        /// </summary>
        /// <param name="data">Array of strings which will be in cells</param>
        /// <param name="cellAlignment">Left, Center, Right</param>
        public static void FillTable(PdfPTable table, string[] data, int cellAlignment = 1)
        {
            foreach (var text in data)
            {
                table.AddCell(new PdfPCell(new Phrase(text))
                {
                    HorizontalAlignment = cellAlignment,
                    MinimumHeight = 20
                });
            }
        }
    }
}
