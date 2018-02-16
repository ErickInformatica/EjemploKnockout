	CREATE DATABASE Opiniones;
	USE Opiniones;



	CREATE TABLE Opinion(
		OpinionId INT IDENTITY (1,1) NOT NULL,
		Nombre VARCHAR(100) NOT NULL,
		PRIMARY KEY (OpinionId)
	);

		CREATE TABLE Usuario(
		UsuarioId INT IDENTITY(1,1) NOT NULL,
		Nombre VARCHAR(100) NOT NULL,
		Apellido VARCHAR(100) NOT NULL,
		Correo VARCHAR(100) NOT NULL,
		Comentario TEXT NOT NULL,
		OpinionId INT NOT NULL,
		PRIMARY KEY(UsuarioId),
		FOREIGN KEY(OpinionId) REFERENCES Opinion(OpinionId)
	);

	INSERT INTO Opinion(Nombre)
	VALUES('Prueba')

	INSERT INTO Usuario(Nombre, Apellido, Correo, Comentario, OpinionId)
	VALUES('Prueba', 'Prueba', 'Prueba123', 'Prueba', 1)

	SELECT * FROM Opinion;
	SELECT * FROM Usuario;