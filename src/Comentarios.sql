CREATE TABLE [dbo].[Comentarios]
(
        [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [Id_Pelicula] INT FOREIGN KEY REFERENCES [dbo].[Peliculas](Id),
        [Id_Usuario] INT FOREIGN KEY REFERENCES [dbo].[Usuarios](Id),
        [Description] VARCHAR(255) NULL,
        [Fecha] DATE NULL
)