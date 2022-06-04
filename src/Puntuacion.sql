CREATE TABLE [dbo].[Puntuacion]
(
        [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [Id_Pelicula] INT FOREIGN KEY REFERENCES [dbo].[Peliculas](Id),
        [Id_Usuario] INT FOREIGN KEY REFERENCES [dbo].[Usuarios](Id),
        [Puntuacion] DECIMAL(4, 2) NOT NULL,
)