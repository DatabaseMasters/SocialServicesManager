using SocialServicesManager.Data.Models;
using System;

namespace SocialServicesManager.Data.Factories.Contracts
{
    public interface IModelsFactory
    {
        Address CreateAddress(Town town, string name);

        Child CreateChild(string firstName, string lastName, Gender gender, DateTime? birthdDate, Family family);

        Family CreateFamily(string name, User assignedStaff);

        FamilyMember CreateFamilyMember(string firstName, string lastName, Gender gender, Address address, Family family);

        MedicalDoctor CreateMedicalDoctor(string firstName, string lastName, string phoneNumber, string specialty);
          
        MedicalRecord CreateMedicalRecord(DateTime date, int childId, MedicalDoctor medicalDoctorId, string description);

        Municipality CreateMunicipality(string name);

        Town CreateTown(string name, Municipality municipality);

        User CreateUser(string username, string password, string firstName, string lastName);

        Visit CreateVisit(DateTime date, int userId, int familyId, VisitType type, string descirption);

        VisitType CreateVisitType(string name);
    }
}
