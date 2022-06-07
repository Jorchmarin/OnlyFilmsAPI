CREATE TABLE [dbo].[Peliculas]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(25) NOT NULL, 
    [Description] VARCHAR(255) NOT NULL, 
    [Valoration] DECIMAL(4, 2) NOT NULL, 
    [ImageUrl] VARCHAR(255) NOT NULL
)