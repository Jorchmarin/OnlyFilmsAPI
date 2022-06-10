CREATE TABLE [dbo].[Peliculas]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(25) NOT NULL, 
    [Description] VARCHAR(255) NOT NULL, 
    [Valoration] DECIMAL(4, 2) NOT NULL, 
    [ImageUrl] VARCHAR(255) NOT NULL
);
CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(25) NOT NULL, 
    [Email] VARCHAR(25) NOT NULL UNIQUE,  
    [Password] VARCHAR(255) NULL,
    [Nick] VARCHAR(15) NOT NULL,
);
CREATE TABLE [dbo].[Genero]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(25) NOT NULL
);
CREATE TABLE [dbo].[Comentarios]
(
        [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [Id_Pelicula] INT FOREIGN KEY REFERENCES [dbo].[Peliculas](Id),
        [Id_Usuario] INT FOREIGN KEY REFERENCES [dbo].[Usuarios](Id),
        [Description] VARCHAR(255) NULL,
        [Fecha] DATE NULL
);
CREATE TABLE [dbo].[Peliculas/Genero]
(
        [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [Id_Pelicula] INT FOREIGN KEY REFERENCES [dbo].[Peliculas](Id),
        [Id_Genero] INT FOREIGN KEY REFERENCES [dbo].[Genero](Id)

);
CREATE TABLE [dbo].[Puntuacion]
(
        [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [Id_Pelicula] INT FOREIGN KEY REFERENCES [dbo].[Peliculas](Id),
        [Id_Usuario] INT FOREIGN KEY REFERENCES [dbo].[Usuarios](Id),
        [Puntuacion] DECIMAL(4, 2) NOT NULL,
);
CREATE TABLE [dbo].[Wishlist]
(
        [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [Id_Pelicula] INT FOREIGN KEY REFERENCES [dbo].[Peliculas](Id),
        [Id_Usuario] INT FOREIGN KEY REFERENCES [dbo].[Usuarios](Id)

);

INSERT INTO [dbo].[Genero]
(Id, Name)
VALUES
(1,'Acción'),
(2,'Aventuras'),
(3,'Ciencia Ficción'),
(4	,'Comedia'),
(5	,'Drama'),
(6	,'Fantasía'),
(7	,'Musical'),
(8	,'Suspense'),
(9	,'Terror'),
(10	,'Romántico');

INSERT INTO dbo.Peliculas
(Id, Name, Description , Valoration , ImageUrl)
VALUES
(1, 'Dune', 'En el Año 10191 el desértico planeta Arrakis, feudo de la familia Harkonnen desde hace generaciones, queda en manos de la Casa de los Atreides por orden del emperador.', 7.3 , 'https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTTEV8NJFqCLfdEvKONNm7DJVTNtnjR1PgewsZxHbQr-k6h1WoK'),
(2, 'Spider-Man: No Way Home', 'Por primera vez en la historia cinematográfica de Spider-Man, nuestro héroe, vecino y amigo es desenmascarado, y por tanto, ya no es capaz de separar su vida normal de los enormes riesgos que conlleva ser un superhéroe.', 6.2 , 'https://images-na.ssl-images-amazon.com/images/I/91PKNbBAufL._RI_.jpg'),
(3, 'No Time to Die', 'Bond ha dejado el servicio secreto y está disfrutando de una vida tranquila en Jamaica. Pero su calma no va a durar mucho tiempo. Su amigo de la CIA, Felix Leiter, aparece para pedirle ayuda. La misión de rescatar a un científico resulta...', 6.3 , 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/no-time-to-die-poster-1570438717.jpg?resize=480:*'),
(4, 'Doraibu mai kâ', 'Pese a no ser capaz de recuperarse de un drama personal, Yusuke Kafuku, actor y director de teatro, acepta montar la obra "Tío Vania" en un festival de Hiroshima. Allí, conoce a Misaki, una joven reservada que le han asignado como chófer.', 7 , 'https://cinemagavia.es/wp-content/uploads/2022/02/Drive-my-car-poster.jpg'),
(5, 'The Power of the Dog', 'Montana, 1925. Los acaudalados hermanos Phil (Cumberbatch) y George Burbank (Plemons) son las dos caras de la misma moneda. Phil es impetuoso y cruel, mientras George es impasible y amable. Juntos son copropietarios... ', 6.4  , 'https://www.moviementarios.com/wp-content/uploads/2021/11/el-poder-del-perro-1.jpg'),
(6, 'Don´t Look Up', 'Kate Dibiasky (Jennifer Lawrence), estudiante de posgrado de Astronomía, y su profesor, el doctor Randall Mindy (Leonardo DiCaprio) hacen un descubrimiento tan asombros como terrorífico: un enorme cometa lleva un rumbo...', 6.7 , 'https://es.web.img2.acsta.net/pictures/21/11/29/17/20/1865984.jpg'),
(7,'The Secrets of Dumbledore','El profesor Albus Dumbledore sabe que el poderoso mago oscuro Gellert Grindelwald está haciendo planes para apoderarse del mundo mágico. Incapaz de detenerlo él solo, confía en el Magizoólogo Newt Scamander para dirigir un intrépido equipo de magos.', 6.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/yOeuJdwag4bAlnvgrdweRoiuXGC.jpg'),
(8,'Morbius','Peligrosamente enfermo de un extraño trastorno sanguíneo, y determinado a salvar a otras personas que padecen su mismo destino, el doctor Morbius intenta una apuesta desesperada.',6.4,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/4jcJHqIVsb4MFdYrDajXeEVlDvH.jpg'),
(9,'Doctor Strange 2','Viaja a lo desconocido con el Doctor Strange, quien, con la ayuda de tanto antiguos como nuevos aliados místicos, recorre las complejas y peligrosas realidades alternativas del multiverso para enfrentarse a un nuevo y misterioso adversario.',7.4,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/vThe85YlGE5r7fqEVFePETqnWzk.jpg'),
(10,'Uncharted','Un descendiente del explorador Sir Francis Drake descubre la ubicación de la legendaria ciudad de El Dorado. Con la ayuda de su mentor Victor Sullivan y la ambiciosa periodista Elena Fischer, Nathan Drake trabajará para descubrir sus secretos.',7.2,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8FiWi61YRbkN95xmH668iq5sCo1.jpg'),
(11,'The Batman','Cuando un asesino se dirige a la élite de Gotham con una serie de maquinaciones sádicas, un rastro de pistas crípticas envía Batman a una investigación en los bajos fondos.',7.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/zFTLPipninMF4THDbdkQUZLWMEw.jpg'),
(12,'Los Tipos Malos','Cinco villanos notorios: el Sr. Wolf, Mr. Snake, Mr. Piranha, Mr. Shark y Ms. Tarantula, que han pasado toda una vida juntos realizando grandes atracos.',7.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/wFdwJh3fbhp5aiRbQelVz1mbbwP.jpg'),
(13,'Top Gun: Maverick ','Después de más de 30 años de servicio como uno de los mejores aviadores de la Armada, Pete "Mavericks" Mitchel (Tom Cruise) se encuentra dónde siempre quiso estar.',8.3,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/AlWpEpQq0RgZIXVHAHZtFhEvRgd.jpg'),
(14,'The Contractor','Después de ser dado de baja involuntariamente de las Fuerzas Especiales de EE. UU., James Harper decide apoyar a su familia uniéndose a una organización de contratación privada junto a su mejor amigo y bajo el mando de un compañero veterano.',6.6,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/uboar85WH92Q5Ct2Y0B2YEdYRNF.jpg'),
(15,'Chip y Chop','Chip y Chop, viven en LA entre dibujos animados y humanos. Chip lleva una vida rutinaria como vendedor de seguros y Chop se ha hecho la cirugía 3D y se dedica a explotar la nostalgia de convención en convención, desesperado por revivir sus días de gloria.',7.2,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/cVE6Mop3gCqIZfnQEkvGV2rG0IM.jpg'),
(16,'Ambulance','Dos hermanos roban una ambulancia tras un atraco que sale mal y deberán de trabajar juntos para escapar de la policía que los persigue.',7,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/hUbgg3mMSbY9PlpTxBo4IFUVSd6.jpg'),
(17,'Sonic 2 La película','Después de establecerse en Green Hills, Sonic se muere por demostrar que tiene madera de auténtico héroe, pero Robotnik regresa con nuevo compañero Knuckles, en busca de una esmeralda que tiene el poder de destruir civilizaciones,le ayudará Tails.',7.7,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/sJiHVM0A3OXDVxl4Z6a7ihMPHfm.jpg'),
(18,'La memoria de un asesino','Alex, un asesino a sueldo, descubre que se ha convertido en un objetivo después de que se niega a completar un trabajo para una peligrosa organización criminal. Con el sindicato del crimen y el FBI persiguiéndolo.',7.3,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/4Q1n3TwieoULnuaztu9aFjqHDTI.jpg'),
(19,'Red','Mei Lee, una niña de 13 años un poco rara pero segura de sí misma, se debate entre ser la hija obediente que su madre quiere que sea y el caos propio de la adolescencia. Ming, su protectora y ligeramente exigente madre, no se separa nunca de ella.',7.5,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/hUupIkIKPpNLYniPGRxRpEQFrX3.jpg'),
(20,'El Exorcismo De Dios','Un sacerdote estadounidense que trabaja en México es considerado un santo por muchos feligreses locales. Sin embargo, debido a un exorcismo fallido, guarda un secreto que lo está comiendo vivo hasta que tenga la oportunidad de enfrentarse a su demonio.',6.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/wHA9cysdFmGDfIvu9iEpu19w9GK.jpg'),
(21,'Cadena perpetua','Acusado del asesinato de su mujer, Andrew Dufresne, tras ser condenado a cadena perpetua, es enviado a la prisión de Shawshank. Con el paso de los años conseguirá ganarse la confianza del director del centro y el respeto de sus compañeros presidiarios.',8.7,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/dc1fX265fZIIY5Hab8I7CdETyJy.jpg'),
(22,'El Padrino','Don Vito Corleone, conocido dentro de los círculos del hampa como "El Padrino", es el patriarca de una de las cinco familias que ejercen el mando de la Cosa Nostra en Nueva York en los años cuarenta.',8.7,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/wLXd1Cd0XW7DhXayfC0Ok5ago9r.jpg'),
(23,'El viaje de Chihiro','Chihiro es una niña de diez años que está mudándose con sus padres a un nuevo hogar. Por el camino, la familia se topa con un enorme edificio rojo en cuyo centro se abre un largo túnel. Al otro lado del pasadizo se dibuja una ciudad fantasma.',8.5,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/vlsi5iZcfDChKNGNvRp7Zp3SULH.jpg'),
(24,'your name.','Taki y Mitsuha descubren un día que durante el sueño sus cuerpos se intercambian, y comienzan a comunicarse por medio de notas.',8.5,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/iaiy3tg9QVkDpObm1IGqmbC9A5C.jpg'),
(25,'Parásitos','Tanto Gi Taek como su familia están sin trabajo. Cuando su hijo mayor, Gi Woo, empieza a recibir clases particulares en casa de Park, las dos familias, que tienen mucho en común pese a pertenecer a dos mundos totalmente distintos.',8.5,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/4N55tgxDW0RRATyrZHbx0q9HUKv.jpg'),
(26,'El bueno el feo y el malo','Durante la Guerra de Secesión, tres cazadores de recompensas se lanzan a la búsqueda de un tesoro que ninguno de los tres truhanes puede localizar sin la ayuda de los otros dos. ','8.3','https://www.themoviedb.org/t/p/w600_and_h900_bestv2/vd9uj5KLlOrJnvNH03exLDlMAE0.jpg'),
(27,'Marmaduke','Un perro faldero demasiado grande, con una veta irascible y una inclinación por las travesuras, se atempera con un profundo sentido de amor y responsabilidad por su familia.',5.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/v6DRsmj7PQdV9v6Dou20LukmIys.jpg'),
(28,'Corazón de Fuego','Georgia Nolan sueña con ser la primera mujer bombero del mundo, pero todos quieren convencerla de que esa no es una profesión para chicas.',7.2,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/fJlDrKbzGkkPxZumwT0mNMX8qQn.jpg'),
(29,'Jujutsu Kaisen 0','Yuta Okkotsu es un nervioso estudiante de instituto que sufre un grave problema: su amiga de la infancia Rika se ha convertido en una maldición y no le deja en paz. Como Rika no es una maldición cualquiera.',7.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/eiSlgyx7G61Ey69K9MmCw9OaHMA.jpg'),
(30,'Lola Índigo: La Niña','Se acerca el concierto del Wizink Center y Lola Índigo prepara el show junto a todo su equipo. Para esta estrella española del pop supone cumplir un sueño que lleva persiguiendo desde niña.',7.2,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/g7MFsfcV9nm8LZBFpN4c5PTeEnw.jpg'),
(31,'El secreto de Vicky','Stéphane decide mudarse a una bonita región montañosa del centro de Francia para retomar la relación con su hija de 8 años, Victoria, que ha perdido el habla desde que murió su madre.',7.2,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/y8MObKaFdpQoWeVhJBOBv7d8hrq.jpg'),
(32,'Ojos de fuego','Andy y Vicky son unos padres que llevan más de una década huyendo en un desesperado intento de esconder a su hija Charlie de una oscura agencia estadounidense...',6.2,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/lWHe42Fc8TKzvirq19AsfLfbGaX.jpg'),
(33,'Book of Love','La novela del joven y tenso escritor inglés Henry es un rotundo fracaso. Está encantado de saber que su libro es un éxito sorpresa en México, pero cuando lo invitan allí para promocionarlo.',5.1,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/qZb0Jm1vV56iITq5S8M6PLDPWpx.jpg'),
(34,'Bob´s Burgers','Bob´s Burgers La Película es una comedia de animación para la gran pantalla. La historia arranca cuando la rotura de una tubería de agua crea un enorme socavón justo delante del Bob´s Burgers.',6.6,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/31vliI2mopLlh5kUoWpJZ19cF8y.jpg'),
(35,'Sin ti no puedo','David es un empresario de éxito que tiene una vida acomodada junto a su novio Álex, un atractivo monitor de gimnasio. Álex siempre ha querido ser padre y a menudo se plantea qué camino seguir para lograrlo...',5,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/vB52z6G05RzpsQEtee6nnpqTOAQ.jpg'),
(36,'Hatching','Una joven gimnasta que intenta desesperadamente complacer a su exigente madre, descubre un extraño huevo. Ella lo esconde y lo mantiene caliente, pero cuando sale del cascarón, lo que emerge los sorprende a todos.',6.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/gZ653k1rT3TSK5HcP73t1wb2RSR.jpg'),
(37,'El aparcacoches','La mundialmente famosa estrella de cine Olivia enfrenta un desastre de relaciones públicas cuando un paparazzi le toma una foto con su amante casado, Vincent.',7.9,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/d27yNLvnSESdJSqOnlYNJKMFXvL.jpg'),
(38,'Jurassic World: Dominion','Cuatro años después de la destrucción de Isla Nublar, los dinosaurios conviven – y cazan – con los seres humanos en todo el mundo.',6.8,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/sXeWfpT1EhG7f4uBouqraOhmouH.jpg'),
(39,'Hasta el último hombre','Narra la historia de Desmond Doss, un joven médico militar que participó en la sangrienta batalla de Okinawa, en el Pacífico durante la II Guerra Mundial, y se convirtió en el primer objetor de conciencia estadounidense en recibir la Medalla de Honor.',9.3,'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/m3jj8IJ7uP5p4MqMzgtGW5l4ECd.jpg');



INSERT INTO dbo.[Peliculas/Genero]
(Id_Pelicula,Id_Genero)
VALUES
(1,1),
(2,1),
(3,1),
(7,1),
(8,1),
(9,1),
(10,1),
(11,1),
(14,1),
(16,1),
(18,1),
(22,1),
(26,1),
(28,1),
(29,1),
(32,1),
(38,1),
(39,1),
(1,2),
(4,2),
(5,2),
(6,2),
(10,2),
(12,2),
(15,2),
(17,2),
(19,2),
(23,2),
(24,2),
(27,2),
(28,2),
(31,2),
(32,2),
(35,2),
(38,2),
(1,3),
(2,3),
(7,3),
(8,3),
(9,3),
(29,3),
(38,3),
(12,4),
(15,4),
(30,4),
(33,4),
(34,4),
(37,4),
(1,5),
(4,5),
(5,5),
(6,5),
(11,5),
(16,5),
(23,5),
(25,5),
(26,5),
(31,5),
(32,5),
(35,5),
(1,6),
(2,6),
(7,6),
(8,6),
(9,6),
(24,6),
(28,6),
(29,6),
(30,6),
(30,7),
(3,8),
(4,8),
(5,8),
(6,8),
(11,8),
(14,8),
(18,8),
(20,8),
(21,8),
(22,8),
(25,8),
(26,8),
(31,8),
(32,8),
(35,8),
(36,8),
(38,8),
(39,8),
(8,9),
(9,9),
(11,9),
(18,9),
(20,9),
(39,9),
(30,10),
(33,10),
(37,10);

