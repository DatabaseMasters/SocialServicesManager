USE [db8ff4dea965a64ef0b842a78b012743f9]
GO
SET IDENTITY_INSERT [dbo].[Municipalities] ON 

INSERT [dbo].[Municipalities] ([Id], [Name]) VALUES (1, N'Sofia')
INSERT [dbo].[Municipalities] ([Id], [Name]) VALUES (2, N'Plovdiv')
INSERT [dbo].[Municipalities] ([Id], [Name]) VALUES (3, N'Varna')
SET IDENTITY_INSERT [dbo].[Municipalities] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([Id], [Name], [Municipality_Id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([Id], [Name], [Municipality_Id]) VALUES (2, N'Plovdiv', 2)
INSERT [dbo].[Towns] ([Id], [Name], [Municipality_Id]) VALUES (3, N'Varna', 3)
INSERT [dbo].[Towns] ([Id], [Name], [Municipality_Id]) VALUES (4, N'Pernik', 1)
SET IDENTITY_INSERT [dbo].[Towns] OFF
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [Name], [Town_Id]) VALUES (1, N'1 Sheynovo str.', 1)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Password], [FirstName], [LastName], [Deleted]) VALUES (1, N'nedipet', N'nedi1234', N'Nedialka', N'Petkova', 0)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [FirstName], [LastName], [Deleted]) VALUES (3, N'mimidot', N'mimi1234', N'Maria', N'Dotkova', 0)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [FirstName], [LastName], [Deleted]) VALUES (4, N'kiliikata', N'nemesudi123', N'Kiro', N'Baroveca', 0)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [FirstName], [LastName], [Deleted]) VALUES (5, N'nadhris', N'nadh1234', N'Nadezhda', N'Hristova', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Families] ON 

INSERT [dbo].[Families] ([Id], [Name], [Deleted], [AssignedStaffMember_Id]) VALUES (1, N'Georgievi', 0, 1)
INSERT [dbo].[Families] ([Id], [Name], [Deleted], [AssignedStaffMember_Id]) VALUES (4, N'Hristovi', 0, 4)
SET IDENTITY_INSERT [dbo].[Families] OFF
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([Id], [Name]) VALUES (1, N'Male')
INSERT [dbo].[Genders] ([Id], [Name]) VALUES (2, N'Female')
INSERT [dbo].[Genders] ([Id], [Name]) VALUES (3, N'Undefined')
SET IDENTITY_INSERT [dbo].[Genders] OFF
SET IDENTITY_INSERT [dbo].[FamilyMembers] ON 

INSERT [dbo].[FamilyMembers] ([Id], [FirstName], [LastName], [Deleted], [Family_Id], [Gender_Id], [Address_Id]) VALUES (1, N'Lina', N'Orlova', 0, 1, 2, 1)
INSERT [dbo].[FamilyMembers] ([Id], [FirstName], [LastName], [Deleted], [Family_Id], [Gender_Id], [Address_Id]) VALUES (2, N'Yovko', N'Radev', 0, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[FamilyMembers] OFF
SET IDENTITY_INSERT [dbo].[Children] ON 

INSERT [dbo].[Children] ([Id], [FirstName], [LastName], [Deleted], [BirthDate], [Gender_Id], [Family_Id]) VALUES (1, N'Galia', N'Todorova', 0, CAST(N'2001-03-02T00:00:00' AS SmallDateTime), 1, 1)
INSERT [dbo].[Children] ([Id], [FirstName], [LastName], [Deleted], [BirthDate], [Gender_Id], [Family_Id]) VALUES (2, N'Georgi', N'Evtimov', 0, CAST(N'2005-07-15T00:00:00' AS SmallDateTime), 1, 1)
INSERT [dbo].[Children] ([Id], [FirstName], [LastName], [Deleted], [BirthDate], [Gender_Id], [Family_Id]) VALUES (4, N'null', N'null', 0, NULL, 3, 1)
SET IDENTITY_INSERT [dbo].[Children] OFF
