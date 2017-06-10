using SocialServicesManager.Models;
using System.Linq;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SocialServicesManager.Data.Factories
{
    public class DataFactory : IDataFactory
    {
        private readonly SQLServerDbContext SqlDbContext;
        private readonly PostgreDbContext PostgreDbContext;
        private readonly SqliteDbContext SqliteDbContext;

        public DataFactory(SQLServerDbContext sqlDbContext, PostgreDbContext postgreDbContext, SqliteDbContext sqliteDbContext)
        {
            this.SqlDbContext = sqlDbContext;
            this.PostgreDbContext = postgreDbContext;
            this.SqliteDbContext = sqliteDbContext;
        }

        public void AddFamily(Family family)
        {
            this.SqlDbContext.Families.Add(family);
        }

        public void AddUser(User user)
        {
            this.SqlDbContext.Users.Add(user);
        }

        public void AddVisit(Visit visit)
        {
            this.PostgreDbContext.Visits.Add(visit);
        }

        // TODO Add CreateVisitTypeCommand
        public void AddVisitType(VisitType visitType)
        {
            this.PostgreDbContext.Visittypes.Add(visitType);
        }

        public void AddMedicalDoctor(MedicalDoctor doctor)
        {
            this.SqliteDbContext.MedicalDoctors.Add(doctor);

        }        

        public void AddMedicalRecord(MedicalRecord record)
        {
            this.SqliteDbContext.MedicalRecords.Add(record);
        }


        // TODO Research if this creates issues
        public void SaveAllChanges()
        {
            this.SqlDbContext.SaveChanges();
            this.PostgreDbContext.SaveChanges();
            this.SqliteDbContext.SaveChanges();
        }

        public MedicalDoctor GetMedicalDoctor(int id)
        {
            var doctorFound = this.SqliteDbContext.MedicalDoctors.Find(id);

            return doctorFound;
        }

        public VisitType GetVisitType(string type)
        {
            var typeFound = this.PostgreDbContext.Visittypes
                .Where(v => v.Name == type)
                .FirstOrDefault();

            return typeFound;
        }

        public ICollection<Family> ExportAllFamilies()
        {
            var familiesCollection = this.SqlDbContext.Families.ToList();

            Document familyDoc = new Document();
            
            PdfWriter.GetInstance(familyDoc, new FileStream("./FamiliesReport.pdf", FileMode.Create));

            PdfPTable table = new PdfPTable(2);
            PdfPCell cell = new PdfPCell(new Phrase("All families in DB"));
            cell.Colspan = 2;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);

            foreach (Family family in familiesCollection)
            {
                PdfPCell id = new PdfPCell(new Phrase(family.Id.ToString()));
                PdfPCell name = new PdfPCell(new Phrase(family.Name));
                id.HorizontalAlignment = 1;
                name.HorizontalAlignment = 1;
                table.AddCell(id);
                table.AddCell(name);
            }

            familyDoc.Open();
            familyDoc.Add(table);
            familyDoc.Close();

            return familiesCollection;
        } 
    }
}
