## Databases: Teamwork Assignement
# Team Database Masters - Social Services Manager


## Project Description
Management tool for monitoring and organizing social service visits for families with young children. 

The database is organised in tables in SQL Server, PostgreSQL and SQLite.
Accessed is through a console application.
Data can be inported from XML and JSON and eported to PDF.

### Data Relations
- The staff of the social service (`Users`) keep track of the `Families` they work with. Each family has one `Assigned Staff Member`, one or more `Family Members` and one or more `Children`. Staff members conduct `Visits` to `Families` during which they provide advice and assistance to `Family Members` for the care and welbeing of the `Children`.

- `Children` have one or more `Medical Records` tracked by one or more `Medical Doctors`

[Diagram](#database-diagram)

[Commands Samples](./CommandsSamples.md)


## Team Members

| Names               | Email                      | Username            | Tasks      |
| ------------------- | -------------------------- | ------------------- | ---------- |
| Nadezhda Hristova   | epohster@gmail.com         | nhristova           | Commands   |
| Aleksandar Ikonomov | aleksandar.ikonomov@abv.bg | a.ikonomov          | PDF export |
| Milena Sapunova     | @                          | milena.aleksandrova | Import     |

## Links

|   [GitHub](https://github.com/DatabaseMasters)    |   [Showcase](#)   |   [YouTube](#)    |

## General Requirements Covered
+ Code First approach
+ Entity Framework
+ SQL Server 2016 - one team member used SQL Server 2014
+ At least five tables in the SQL Server database
+ All type of relations in the database - except one-to-one
+ Attributes and the Fluent API (Model builder) for configuration
+ Data in SQLite and PostgreSQL
+ Data loaded from external files - XML, JSON
+ The user is able to manipulate the database through the client 
+ Usable user interface for the client - console
+ PDF reports 

## Additional Requirements Covered
+ **iTextSharp** library used for PDF export
+ **Newtonsoft.JSON** used for JSON serializations

- @?The XML files read through the standard .NET parsers

## Optional Requirements 
+ Pure Entity Framework and DbContext

- @!TODO! **Unit Tests**

## Database Diagram

![database diagram](./database-diagram.JPG)