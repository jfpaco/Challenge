CREATE TABLE [dbo].[Permissions]
(
	[Id] INT NULL PRIMARY KEY, 
    [EmployeeForename] NVARCHAR(50) NULL, 
    [EmployeeSurname] NVARCHAR(50) NULL, 
    [PermissionType] INT NULL, 
    [PermissionDate] DATETIME NULL
)
