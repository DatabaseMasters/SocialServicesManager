using System;
using SocialServicesManager.Data.Models;
using SocialServicesManager.Data.Factories.Contracts;

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

        public Child CreateChild(string firstName, string lastName, Gender gender, DateTime? birthdDate, Family family)
        {
            var child = new Child
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                BirthDate = birthdDate,
                Family = family
            };

            return child;
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

        public FamilyMember CreateFamilyMember(string firstName, string lastName, Gender gender, Address address, Family family)
        {
            var familyMember = new FamilyMember
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Address = address,
                Family = family
            };

            return familyMember;
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

        public MedicalRecord CreateMedicalRecord(DateTime date, int childId, MedicalDoctor doctor, string description)
        {
            var medicalRecord = new MedicalRecord
            {
                Description = description,
                ChildId = childId,
                // TODO: Medicalrecord now has many doctors 
                //MedicalDoctor = doctor
                
            };

            medicalRecord.MedicalDoctors.Add(doctor);

            return medicalRecord;
        }

        public Municipality CreateMunicipality(string name)
        {
            var municipality = new Municipality
            {
                Name = name
            };

            return municipality;
        }

        public Town CreateTown(string name, Municipality municipality)
        {
            var town = new Town
            {
                Name = name,
                Municipality = municipality
            };

            return town;
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

        public Visit CreateVisit(DateTime date, int userId, int familyId, VisitType visitType, string descirption)
        {
            var visit = new Visit
            {
                Date = date,
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
    }
}
