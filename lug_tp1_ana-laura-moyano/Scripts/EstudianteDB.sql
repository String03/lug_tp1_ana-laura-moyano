USE master 
GO
CREATE DATABASE EstudianteDB
GO
USE EstudianteDB
GO

CREATE TABLE Estudiantes(
	Id INT PRIMARY KEY IDENTITY (1,1),
	Nombre VARCHAR(50) NOT NULL,
	Apellido VARCHAR(50) NOT NULL,
	Matricula INT NOT NULL UNIQUE,
	Telefono VARCHAR(15),
	Email VARCHAR(MAX),
	Ciudad VARCHAR(MAX)
)

GO

CREATE PROCEDURE LEER_ESTUDIANTES_SP
AS
	SELECT * FROM Estudiantes
GO

CREATE PROCEDURE ELIMINAR_ESTUDIANTE_SP
	@ID INT
AS
BEGIN
	DELETE FROM Estudiantes WHERE ID = @ID
END
GO

CREATE PROCEDURE INSERTAR_ESTUDIANTE_SP
@Nombre varchar(50),
@Apellido varchar(50),
@Matricula int,
@Telefono varchar(15),
@Email varchar(max),
@Ciudad varchar(max)
AS
BEGIN
INSERT INTO [dbo].[Estudiantes]
           ([Nombre]
           ,[Apellido]
           ,[Matricula]
           ,[Telefono]
           ,[Email]
           ,[Ciudad])
     VALUES
           (@Nombre
           ,@Apellido
           ,@Matricula
           ,@Telefono
           ,@Email
           ,@Ciudad)
END
GO

CREATE PROCEDURE MODIFICAR_ESTUDIANTE_SP
@Id	int,
@Nombre varchar(50),
@Apellido varchar(50),
@Matricula int,
@Telefono varchar(15),
@Email varchar(max),
@Ciudad varchar(max)
AS
BEGIN
UPDATE [dbo].[Estudiantes]
           SET [Nombre] = @Nombre
           ,[Apellido] = @Apellido
           ,[Matricula] = @Matricula
           ,[Telefono] = @Telefono
           ,[Email] = @Email
           ,[Ciudad] = @Ciudad
		   WHERE Id = @Id
END