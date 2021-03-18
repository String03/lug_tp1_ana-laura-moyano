using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudianteABM.Conexiones;
using EstudianteABM.Modelos;

namespace EstudianteABM.DAO.Query
{
	public class EstudianteDAOQuery : IEstudianteDAO
	{
		public void Actualizar(Estudiante estudiante)
		{
			string comando = $@"UPDATE [dbo].[Estudiantes]
		   SET [Nombre] = '{estudiante.Nombre}'
		   ,[Apellido] = '{estudiante.Apellido}'
		   ,[Matricula] = {estudiante.Matricula}
		   ,[Telefono] = {(estudiante.Telefono == null ? ("NULL") : ("'" + estudiante.Telefono + "'"))}
		   ,[Email] = {(estudiante.Email == null ? ("NULL") : ("'" + estudiante.Email + "'"))}
		   ,[Ciudad] = {(estudiante.Ciudad == null ? ("NULL") : ("'" + estudiante.Ciudad + "'"))}
			WHERE [Id] = {estudiante.Id}";
			EjecutarComando(comando);
		}

		public void Eliminar(Estudiante estudiante)
		{
			string comando = $"DELETE FROM ESTUDIANTES WHERE ID = {estudiante.Id}";
			EjecutarComando(comando);
		}

		public void Insertar(Estudiante estudiante)
		{
			string comando = $@"INSERT INTO [dbo].[Estudiantes]
		   ([Nombre]
		   ,[Apellido]
		   ,[Matricula]
		   ,[Telefono]
		   ,[Email]
		   ,[Ciudad])
     VALUES
		   (
			'{estudiante.Nombre}'
		   ,'{estudiante.Apellido}'
		   ,{estudiante.Matricula}
		   ,{(estudiante.Telefono == null ? ("NULL") : ("'" + estudiante.Telefono + "'"))}
		   ,{(estudiante.Email == null ? ("NULL") : ("'" + estudiante.Email + "'"))}
		   ,{(estudiante.Ciudad == null ? ("NULL") : ("'" + estudiante.Ciudad + "'"))})";
			EjecutarComando(comando);
		}

		public IEnumerable<Estudiante> Listar()
		{
			string comando = "SELECT * FROM ESTUDIANTES";
			return EjecutarComando(comando)
				.Select(r => new Estudiante
				{
					Id = (int)r[0],
					Nombre = r[1].ToString(),
					Apellido = r[2].ToString(),
					Matricula = (int)r[3],
					Telefono = r[4].ToString(),
					Email = r[5].ToString(),
					Ciudad = r[6].ToString()
				})
				.ToList();
		}

		private IEnumerable<object[]> EjecutarComando(string comando)
		{
			using (var conexion = ConexionEstudiante.CrearConexion)
			{
				if (conexion.State != ConnectionState.Open)
					conexion.Open();
				using (var cmd = conexion.CreateCommand())
				{
					cmd.CommandText = comando;
					using (var reader = cmd.ExecuteReader())
					{
						List<object[]> filas = new List<object[]>();
						do
						{
							while (reader.Read())
							{
								object[] fila = new object[reader.FieldCount];
								reader.GetValues(fila);
								filas.Add(fila);
							}
						}
						while (reader.NextResult());
						return filas;
					}
				}
			}
		}
	}
}
