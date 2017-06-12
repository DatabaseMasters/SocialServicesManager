# Commands #

Create
1. [CreateAddress](#address)
1. [CreateChild](#child)
1. [CreateFamily](#family)
1. [CreateFamilyMember](#family-member)
1. [CreateMedicalDoctor](#medical-doctor)
1. [CreateMedicalRecord](#medical-record)
1. [CreateUser](#user)
1. [CreateVisit](#visit)

[Export](#export)

[List](#list)

[Update](#update)

[Delete](#delete)

[TODO](#todo)

## DEMO COMMAND SET ##

```
createuser avgustgala avgu1234 Avgust Galabov
createuser adaliapetr adali1234 Adalia Petrova
createuser stoiugrade stoiu1234 Stoiu Gradev
createuser ognenadimo ognena1234 Ognena Dimova
createfamily Popovi 1
createfamily Georgievi 2
createfamily Simeonovi 4
createfamily Hitrovi 3
createfamily Atanasovi 1
createfamily Mitevi 2
createaddress 1 (3 Bistritsa str.)
createaddress 2 (17 William Gladstone str.)
createaddress 3 (105 Kniaz Boris I str.)
createaddress 2 (31 Rakovski str.)
createaddress 4 (56 Nikola Gabrovski str.)
createaddress 5 (1 Osmi mart str.)
createfamilymember Dinko Popov male 1 1
createfamilymember Lina Simeonova female 2 3
createfamilymember Yovko Mitev male 3 6
createchild Georgi Popov male 15.07.2005 1
createchild Marina Popova female 03.01.2008 1
createchild Hristo Georgiev male 23.09.2003 2
createchild Vania Simeonova female 01.03.2000 3
createchild null null undefined null 4
createmedicaldoctor Ivan Petrov 0888999222 GeneralPractitioner
createmedicaldoctor Georgi Mirchev 0888123456 Peadiatric
createmedicalrecord 25.04.2017 1 1 (Georgi had the flu)
createmedicalrecord 12.05.2017 1 2 (Georgi stopped flu meds)
createvisit 12.05.2017 1 1 HomeVisit (Georgi was sleeping)
createvisit 12.05.2017 1 2 HomeVisit (Hristo was playing ball)
createvisit 12.04.2017 1 2 HomeVisit (Hristo was at a birthday)
createvisit 12.02.2017 1 2 HomeVisit (Hristo had broken a cup)
ListChildren
ListFamilies
ListUsers
ListUserVisits 1
ListUserVisits 2
ListVisitTypes
updatechild 1 null null null null 5

``` 

## Creational ##

1. ### ADDRESS

    valid format: **CreateAddress [TownId] ([Address location allows spaces])**
        
        createaddress 1 (1 Sheynovo str.)
        
    invalid short name
        
        createaddress 1 (none)
        

1. ### CHILD

    valid format: **createchild [FirstName] [LastName] [Gender] [BirthDate] [FamilyId]**

    ```
    createchild Georgi Evtimov male 15.07.2005 1
    createchild Hristo Nikolov male 23.09.2003 2
    createchild Vania Dimitrova female 01.03.2000 3
    createchild null null undefined null 1  // unborn child (pregnancy)
    ```

    invalid 
    ```
    createchild H Nikolov male 23.09.2003 2 // short firstName
    createchild Hristo N male 23.09.2003 2  // short lastName
    createchild Hristo Nikolov cat 23.09.2003 2 // nonexistent gender
    createchild Hristo Nikolov male 23.09.2003 df   // familyId not a number
    ```

1. ### FAMILY

    valid format: **CreateFamily [FamilyName] [StaffMemberId]**
    ```
    createfamily Georgievis 1
    ```

    invalid 
    ```
    createfamily G 1    // short name
    createfamily GeorgievisGeorgievisGeorgievisGeorgievisGeorgievisGeorgievis 1 // long name
    ```

1. ### FAMILY MEMBER

    valid format: CreateFamilyMember **[FirstName] [LastName] [Gender] [AddressId] [FamilyId]**
    ```
    createfamilymember Lina Orlova female 1 1
    createfamilymember Yovko Radev male 1 1
    createfamilymember Dinko Botev male 1 2
    ```

    invalid 
    ```
    createfamilymember L Orlova female 1 1  // short firstName
    createfamilymember Lina O female 1 1    // short lastName 
    createfamilymember Lina Orlova cat 1 1  // nonexistent gender
    createfamilymember Lina Orlova female 99 1  // nonexistent addressId
    createfamilymember Lina Orlova female 1 99  // nonexistent familyId
    ```


1. ### MEDICAL DOCTOR

    valid format: **CreateMedicalDoctor [FirstName] [LastName] [PhoneNumber] [Specialty]**
    ```
    createmedicaldoctor Ivan Petrov 0888999222 GeneralPractitioner
    createmedicaldoctor Georgi Mirchev 0888123456 Peadiatric
    createmedicaldoctor Kona Sabeva 0555888444 Neurologist
    ```
    
    invalid 
    ```
    createmedicaldoctor G Mirchev 0888123456 Peadiatric // short firstName
    createmedicaldoctor Georgi M 0888123456 Peadiatric  // short lastName
    createmedicaldoctor Georgi Mirchev 08881234 Peadiatric  // short phoneNumber
    createmedicaldoctor Georgi Mirchev 0888ab!456 Peadiatric    // phoneNumber (validation: start with zero, only digits)
    createmedicaldoctor Georgi Mirchev 8888123456 Peadiatric
    ```

1. ### MEDICAL RECORD
    
    valid format: **CreateMedicalRecord [Date] [ChildId] [DoctorId] ([Description allows spaces])**
    ```
    createmedicalrecord 12.05.2017 1 2 (Galia had the flu)
    ```
    
    invalid
    ```
    createmedicalrecord 12.12.2017 1 2 (Galia had the flu)  //  future date
    createmedicalrecord 12.05.2017 1 2 (Galia h)    // short descriptiopn
    ```

1. ### USER
    
    valid format: **CreateUser [Username] [Password] [FirstName] [LastName]**
    ```
    createuser nedipet nedi1234 Nedialka Petkova 
    createuser mimidot mimi1234 Maria Dotkova 
    createuser nadhris nadh1234 Nadezhda Hristova
    ```

    invalid
    ```
    createuser nedi nedi1234 Nedialka Petkova   // short username
    createuser nedipet nedi123 Nedialka Petkova // short password
    createuser nedipet nedi1234 N Petkova   // short firstName
    createuser nedipet nedi1234 Nedialka P  // short lastName
    ```

1. ### VISIT
    
    valid format: **CreateVisit [Date] [StaffId] [FamilyId] [VisitType] ([Description allows spaces])**
    ```
    createvisit 12.05.2017 1 2 HomeVisit (Galia was playing ball)
    createvisit 12.04.2017 1 2 HomeVisit (Galia was at a birthday)
    createvisit 12.02.2017 1 2 HomeVisit (Galia had broken a cup)
    ```
    
    invalid
    ```
    createvisit 12.02.2017 1 2 HomeVisit (Galia)    // short descriptiopn
    ````



## EXPORT

valid format: 

**ExportUserReport [StaffId]**

**ExportFamilyVistsReport [FamilyId]**

```
exportuserreport 1
exportfamilyvisitsreport 1
```

## LIST

valid format:

**ListChildren**

**ListFamilies**

**ListUsers**

**ListUserVisits [UserId]**

**ListVisitTypes**

```
listuservisits 1
```

## UPDATE

valid format: 

**UpdateChild [ChildId] [NewFirstName] [NewLastName] [NewGender] [NewBirthDate] [NewFamilyId]** -- use null for unchaged values

**UpdateFamilyName [FamilyId] [NewFamilyName]**

**UpdateFamilyStaff [FamilyId] [NewStaffId]**

**UpdateVisit [VisitId] [NewDate] [NewUserId] [NewFamilyId] [NewVisitType] ([NewDescription])** -- use null for unchaged values

```
updatechild 1 Galin Georgiev female null null
updatechild 1 null null null null 5
updatechild 1 null null male 15.03.2001 3
updatefamilyname 1 Marinovi
updatefamilystaff 1 4
updatevisit 2 null null 6 null (null)
```

## DELETE

valid format: 

**DeleteChild [ChildId]**

**DeleteFamily [FamilyId]**

```
deletechild 5
deletefamily 5
```

### TODO

- New commands:

    - Implement command AddDoctorToRecord or AddRecordToDoctor for adding more than one doctor to records

- Other:

    - Medical record to hold Child instead of childId? - problem with different databases?
    - Visit to hold User instead of UserId? - problem with different databases?
    - DataFactory to throw when Family not found instead of throwing in command? Otherwise throwing repeats in many commands
    - Rename DataFactory to DataService, move to services folder
    - Rename DataValidation folder to Validation
    - Move DataParser to Services folder
    - Implement logging functionality and assign new family to currently logged user
    - Extract validations from commands - how?
    - ReportCreator should not reference datafactory?
    - Review Task list
    - Run profiler