CREATE TABLE [dbo].[Applicants]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Email] NVARCHAR(255) UNIQUE NOT NULL,
    [FirstName] NVARCHAR(100) NULL, 
    [LastName] NVARCHAR(100) NULL, 
    [DateOfBirth] DATE NULL, 
    [CreationDate] DATETIME NOT NULL DEFAULT GETDATE()
)
