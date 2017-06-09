﻿using System;
using SocialServicesManager.Models;

namespace SocialServicesManager.Data.Factories
{
    public interface IDataFactory
    {
        void AddFamily(Family family);

        void AddUser(User user);

        void AddVisit(Visit visit);

        void AddMedicalDoctor(MedicalDoctor doctor);

        void AddMedicalRecord(MedicalRecord record);

        void SaveAllChanges();

        MedicalDoctor GetMedicalDoctor(int id);

        VisitType GetVisitType(string type);
    }
}