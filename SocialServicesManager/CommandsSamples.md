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

[Other](#other)


## Creational ##

1. ### ADDRESS

    valid format: **CreateAddress [TownId] ([Address location allows spaces])**
        
        createaddress 1 (1 Sheynovo str.)
        
    short name
        
        createaddress 1 (none)
        

1. ### CHILD

    valid format: **createchild [FirstName] [LastName] [Gender] [BirthDate] [FamilyId]**

    ```
    createchild Georgi Evtimov male 15.07.2005 1
    createchild Hristo Nikolov male 23.09.2003 2
    createchild Vania Dimitrova female 01.03.2000 3
    ```

    valid unborn child (pregnancy)
    ```
    createchild null null undefined null 1
    ```

    short firstName
    ```
    createchild H Nikolov male 23.09.2003 2
    ```

    short lastName
    ```
    createchild Hristo N male 23.09.2003 2
    ```

    gener not found
    ```
    createchild Hristo Nikolov cat 23.09.2003 2
    ```

    familyId not a number
    ```
    createchild Hristo Nikolov male 23.09.2003 df
    ```

1. ### FAMILY

    valid format: **CreateFamily [FamilyName] [StaffMemberId]**
    ```
    createfamily Georgievis 1
    ```

    short name
    ```
    createfamily G 1
    ```

    long name
    ```
    createfamily GeorgievisGeorgievisGeorgievisGeorgievisGeorgievisGeorgievis 1
    ```

1. ### FAMILY MEMBER

    valid format: CreateFamilyMember **[FirstName] [LastName] [Gender] [AddressId] [FamilyId]**
    ```
    createfamilymember Lina Orlova female 1 1
    createfamilymember Yovko Radev male 1 1
    createfamilymember Dinko Botev male 1 2
    ```
    short firstName
    ```
    createfamilymember L Orlova female 1 1
    ```
    short lastName
    ```
    createfamilymember Lina O female 1 1
    ```
    nonexistent gender
    ````
    createfamilymember Lina Orlova cat 1 1
    ```
    nonexistent addressId
    ```
    createfamilymember Lina Orlova female 99 1
    ```
    nonexistent familyId
    ```
    createfamilymember Lina Orlova female 1 99
    ```


1. ### MEDICAL DOCTOR

    valid format: **CreateMedicalDoctor [FirstName] [LastName] [PhoneNumber] [Specialty]**
    ```
    createmedicaldoctor Ivan Petrov 0888999222 GeneralPractitioner
    createmedicaldoctor Georgi Mirchev 0888123456 Peadiatric
    ```
    
    short firstName
    ```
    createmedicaldoctor G Mirchev 0888123456 Peadiatric
    ```
    
    short lastName
    ```
    createmedicaldoctor Georgi M 0888123456 Peadiatric
    ```
    
    short phoneNumber
    ```
    createmedicaldoctor Georgi Mirchev 08881234 Peadiatric
    ```
    
    invalid phoneNumber (validation: start with zero, only digits)
    ```
    createmedicaldoctor Georgi Mirchev 0888ab!456 Peadiatric
    createmedicaldoctor Georgi Mirchev 8888123456 Peadiatric
    ```

1. ### MEDICAL RECORD
    
    valid format: **CreateMedicalRecord [Date] [ChildId] [DoctorId] ([Description allows spaces])**
    ```
    createmedicalrecord 12.05.2017 1 2 (Galia had the flu)
    ```
    
    future date
    ```
    createmedicalrecord 12.12.2017 1 2 (Galia had the flu)
    ```
    
    short descriptiopn
    ```
    createmedicalrecord 12.05.2017 1 2 (Galia h)
    ```

1. ### USER
    
    valid format: **CreateUser [Username] [Password] [FirstName] [LastName]**
    ```
    createuser nedipet nedi1234 Nedialka Petkova 
    createuser mimidot mimi1234 Maria Dotkova 
    ```

    short username
    ```
    createuser nedi nedi1234 Nedialka Petkova 
    ```

    short password
    ```
    createuser nedipet nedi123 Nedialka Petkova
    ```

    short firstName
    ```
    createuser nedipet nedi1234 N Petkova
    ```

    short lastName
    ```
    createuser nedipet nedi1234 Nedialka P
    ```

1. ### VISIT
    
    valid format: **CreateVisit [Date] [StaffId] [FamilyId] [VisitType] ([Description allows spaces])**
    ```
    createvisit 12.05.2017 1 2 HomeVisit (Galia was playing ball)
    createvisit 12.04.2017 1 2 HomeVisit (Galia was at a birthday)
    createvisit 12.02.2017 1 2 HomeVisit (Galia had broken a cup)
    ```
    
    short descriptiopn
    ```
    createvisit 12.02.2017 1 2 HomeVisit (Galia)
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

### OTHER

- TODO validations (if needed) for existing commands:

    - updatefamily
    - deletefamily

- TODO new commands:

    - Validation for parsable values - foreign key ids and (possibly) dates
    - Validation for wrong/unparsable dates
    - Implement command AddDoctorToRecord or AddRecordToDoctor for adding more than one doctor to records

- TODO other:

    - Medical record to hold Child instead of childId?
    - DataFactory to throw when Family not found? Otherwise throwing repeats in many commands
    - Rename DataFactory to DataService
    - Rename DataValidation folder to Validation
    - Move DataParser to Services folder
    - Implement logging functionality and assign new family to currently logged user