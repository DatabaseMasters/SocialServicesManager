using SocialServicesManager.Models;
using System;
using System.Globalization;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.Data.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        public Family CreateFamily(string name)
        {
            var family = new Family
            {
                Name = name
            };

            return family;
        }

        public User CreateUser(string name)
        {
            var user = new User
            {
                Name = name
            };

            return user;
        }

        public Visit CreateVisit(string date, string descirption, int userId, int familyId, VisitType visitType)
        {
            var visit = new Visit
            {
                Date = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Description = descirption,
                UserId = userId,
                FamilyId = familyId,
                VisitType = visitType
            };

            return visit;
        }

        public VisitType CreateVisitType(string name)
        {
            var visitType = new VisitType
            {
                Name = name
            };

            return visitType;
        }

        public MedicalDoctor CreateMedicalDoctor(string name)
        {
            var doctor = new MedicalDoctor
            {
                Id = 1,
                Name = name
            };

            return doctor;
        }

        public MedicalRecord CreateMedicalRecord(string description, int childId, MedicalDoctor doctor)
        {
            var medicalRecord = new MedicalRecord
            {
                Description = description,
                ChildId = childId,
                MedicalDoctor = doctor
            };

            return medicalRecord;
        }
    }
}
