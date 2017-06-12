using System;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SocialServicesManager.Data.Services.PdfReport.PdfPageElements;

namespace SocialServicesManager.Data.Services.PdfReport
{
    public static class ReportCreator
    {
        public static void CreateUserReport(User user, ICollection<Visit> visits, IDataFactory dataFactory)
        {
            FileStream fs = new FileStream(GetDestinationFolder("UserReport.pdf"), FileMode.Create);

            PdfHeaderFooter headerFooter = new PdfHeaderFooter();

            var doc = PdfProvider.GetPage(fs, headerFooter);

            string[] userTableCells = 
            {
                "First Name", "Last Name", "Username",
                $"{user.FirstName}", $"{user.LastName}", $"{user.UserName}"
            };

            var userTable = PdfProvider.CreateTable(3, userTableCells, 20);

            string[] userVisitsCells = { "Date", "Description", "Visit type", "Family name" };

            var userVisits = PdfProvider.CreateTable(4, userVisitsCells, 50, "User visits table");

            foreach (Visit visit in visits)
            {
                var familyName = dataFactory.FindFamily(visit.FamilyId);
                string[] information = { visit.Date.ToShortDateString(), visit.Description, visit.VisitType.Name, familyName.Name };
                PdfProvider.FillTable(userVisits, information);

                // userVisits.AddCell(visit.Date.ToShortDateString());
                // userVisits.AddCell(visit.Description);
                // userVisits.AddCell(visit.VisitType.Name);
                // userVisits.AddCell(familyName.Name);
            }

            doc.Open();

            doc.Add(userTable);

            doc.Add(userVisits);

            doc.Close();

            fs.Close();
        }

        public static void CreateFamilyVisitsReport(Family family, ICollection<Visit> visits)
        {
            FileStream fs = new FileStream(GetDestinationFolder("FamilyVisitsReport.pdf"), FileMode.Create);

            PdfHeaderFooter headerFooter = new PdfHeaderFooter();

            var doc = PdfProvider.GetPage(fs, headerFooter);

            StringBuilder familyMembers = new StringBuilder();

            foreach (var member in family.FamilyMembers)
            {
                familyMembers.AppendLine($"{member.FirstName} {member.LastName}");
            }

            StringBuilder familyChildren = new StringBuilder();

            foreach (var child in family.Children)
            {
                familyChildren.AppendLine($"{child.FirstName} {child.LastName}");
            }

            string[] userTableCells = 
            {
                "Family Id", "Family Name", "Family Members", "Family children", "Assigned Staff Member",
                $"{family.Id}", $"{family.Name}", familyMembers.ToString(), familyChildren.ToString(),
                $"{family.AssignedStaffMember.FirstName} {family.AssignedStaffMember.LastName}"
            };

            var userTable = PdfProvider.CreateTable(5, userTableCells, 20);

            string[] userVisitsCells = { "Date", "Description", "Visit type" };

            var userVisits = PdfProvider.CreateTable(4, userVisitsCells, 50, "User visits table");

            foreach (Visit visit in visits)
            {
                string[] information = { visit.Date.ToShortDateString(), visit.Description, visit.VisitType.Name };
                PdfProvider.FillTable(userVisits, information);

                // userVisits.AddCell(visit.Date.ToShortDateString());
                // userVisits.AddCell(visit.Description);
                // userVisits.AddCell(visit.VisitType.Name);
                // userVisits.AddCell(familyName.Name);
            }

            doc.Open();

            doc.Add(userTable);

            doc.Add(userVisits);

            doc.Close();

            fs.Close();
        }

        internal static string GetDestinationFolder(string fileName)
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).ToString();
            string newPath = Path.GetFullPath(Path.Combine(directory, @"..\..\"));
            string finalPath = newPath + $@"PdfReports\{fileName}";
            return finalPath;
        }
    }
}
