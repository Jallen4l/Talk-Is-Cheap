CREATE TABLE [dbo].[Table]
(
	[AdminID] INT NOT NULL PRIMARY KEY, 
    [AdminFirstname] NCHAR(30) NOT NULL, 
    [AdminSurname] NCHAR(30) NOT NULL, 
    [AdminEmail] NCHAR(256) NOT NULL, 
    [AdminUsername] NCHAR(20) NOT NULL, 
    [AdminPassword] NCHAR(20) NOT NULL, 
    [Enabled] INT NOT NULL
)
