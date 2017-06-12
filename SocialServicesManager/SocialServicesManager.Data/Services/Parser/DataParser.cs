using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Services.Parser.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialServicesManager.Data.Services.Parser
{
    public static class DataParser
    {
        public static int ParseFamiliesJsonData(string filePath, string dateFormat, IDataFactory dataFactory)
        {
            var parsedFamilies = JsonParser.ParseJson<ICollection<FamilyParserModel>>(filePath, "dd.MM.yyyy").ToList();
            SaveData(parsedFamilies, dataFactory);
            return parsedFamilies.Count();
        }

        public static int ParseFamiliesXMLData(string filePath, IDataFactory dataFactory)
        {
            var parsedFamilies = XMLParser.ParseXML<List<FamilyParserModel>>(filePath, "Families");
            SaveData(parsedFamilies, dataFactory);
            return parsedFamilies.Count;
        }

        private static void SaveData(ICollection<FamilyParserModel> parsedFamilies, IDataFactory dataFactory)
        {
            parsedFamilies.ToList().ForEach(f =>
            {
                var family = f.ParseToFamily(dataFactory);
                dataFactory.AddFamily(family);
                dataFactory.SaveAllChanges();

                f.Visits.ToList().ForEach(v =>
                {
                    var visit = v.ParseToVisit(dataFactory);
                    visit.FamilyId = family.Id;
                    visit.UserId = family.AssignedStaffMember.Id;
                    dataFactory.AddVisit(visit);
                });

                var children = family.Children.ToList();
                var fchildren = f.Children.ToList();

                for (int i = 0; i < children.Count; i++)
                {
                    var child = children[i];
                    fchildren[i].MedicalRecords.ToList().ForEach(mr =>
                    {
                        var medicalRecord = mr.ParseToMedicalRecord();
                        medicalRecord.ChildId = child.Id;
                        dataFactory.AddMedicalRecord(medicalRecord);
                    });
                }
            });
            dataFactory.SaveAllChanges();
        }
    }
}
