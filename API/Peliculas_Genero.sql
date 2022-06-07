CREATE TABLE [dbo].[Peliculas/Genero]
(
        [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [Id_Pelicula] INT FOREIGN KEY REFERENCES [dbo].[Peliculas](Id),
        [Id_Genero] INT FOREIGN KEY REFERENCES [dbo].[Genero](Id)

)