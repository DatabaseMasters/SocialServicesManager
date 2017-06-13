using System;
using System.Collections.Generic;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App.Commands.Listing
{
    public class ListCommandsCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var list = @"
Social Services Manager Help 

        help
        createaddress [TownId]([Address location allows spaces])
        createchild [FirstName] [LastName] [Gender] [BirthDate] [FamilyId]
        createfamily [FamilyName] [StaffMemberId]
        createfamilymember [FirstName] [LastName] [Gender] [AddressId] [FamilyId]
        createmedicaldoctor [FirstName] [LastName] [PhoneNumber] [Specialty]
        createmedicalrecord [Date] [ChildId] [DoctorId] ([Description allows spaces])
        createuser [Username] [Password] [FirstName] [LastName]
        createvisit [Date] [StaffId] [FamilyId] [VisitType] ([Description allows spaces])
        listchildren
        listfamilies
        listusers
        listuservisits [UserId]
        listvisittypes
        updatechild [ChildId] [NewFirstName] [NewLastName] [NewGender] [NewBirthDate] [NewFamilyId]
        updatefamilyname [FamilyId] [NewFamilyName]
        updatefamilystaff [FamilyId] [NewStaffId]
        updatevisit [VisitId] [NewDate] [NewUserId] [NewFamilyId] [NewVisitType] ([NewDescription])
        deletefamily [FamilyId]
        deletechild [ChildId]
        exportuserreport
        exportfamilyvisitsreport
        importdata [Format json or xml] [file path]";

            return list;
        }
    }
}
