using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;
using System;
using System.Globalization;

namespace SocialServicesManager.Data.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        public Address CreateAddress(Town town, string name)
        {
            var address = new Address
            {
                Name = name,
                Town = town
            };

            return address;
        }

        public Family CreateFamily(string name, User assignedStaff)
        {
            var family = new Family
            {
                Name = name,
                AssignedStaffMember = assignedStaff
            };

            return family;
        }

        public User CreateUser(string username, string password, string firstName, string lastName)
        {
            var user = new User
            {
                // TODO: Add the other properites
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            return user;
        }

        public Visit CreateVisit(string date, int userId, int familyId, VisitType visitType, string descirption)
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

        public MedicalDoctor CreateMedicalDoctor(string firstName, string lastName, string phoneNumber, string specialty)
        {
            var doctor = new MedicalDoctor
            {
                // TODO: Add all new properties of Medical Doctor
                Id = 1,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Specialty = specialty
            };

            return doctor;
        }

        public MedicalRecord CreateMedicalRecord(int childId, MedicalDoctor doctor, string description)
        {
            var medicalRecord = new MedicalRecord
            {
                Description = description,
                ChildId = childId,

                // TODO: Medicalrecord now has many doctors 
                // MedicalDoctor = doctor
            };

            return medicalRecord;
        }
    }
}
