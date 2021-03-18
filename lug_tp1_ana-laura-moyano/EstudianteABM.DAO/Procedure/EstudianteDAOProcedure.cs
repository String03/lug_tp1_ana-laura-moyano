using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EstudianteABM.Conexiones;
using EstudianteABM.Modelos;

namespace EstudianteABM.DAO.Procedure
{
	public class EstudianteDAOProcedure : IEstudianteDAO
	{
		public void Actualizar(Estudiante estudiante)
		{
			string comando = "MODIFICAR_ESTUDIANTE_SP";
			SqlParameter[] parameters = new SqlParameter[7];
			parameters[0] = new SqlParameter("@Id", estudiante.Id);
			parameters[1] = new SqlParameter("@Nombre", estudiante.Nombre);
			parameters[2] = new SqlParameter("@Apellido", estudiante.Apellido);
			parameters[3] = new SqlParameter("@Matricula", estudiante.Matricula);
			parameters[4] = new SqlParameter("@Telefono", ((object)estudiante.Telefono) ?? DBNull.Value);
			parameters[5] = new SqlParameter("@Email", ((object)estudiante.Email) ?? DBNull.Value);
			parameters[6] = new SqlParameter("@Ciudad", ((object)estudiante.Ciudad) ?? DBNull.Value);
			EjecutarComando(comando, parameters);
		}

		public void Eliminar(Estudiante estudiante)
		{
			string comando = "ELIMINAR_ESTUDIANTE_SP";
			SqlParameter[] parameters = new SqlParameter[1];
			parameters[0] = new SqlParameter("@ID", estudiante.Id);
			EjecutarComando(comando, parameters);
		}

		public void Insertar(Estudiante estudiante)
		{
			string comando = "INSERTAR_ESTUDIANTE_SP";
			SqlParameter[] parameters = new SqlParameter[6];
			parameters[0] = new SqlParameter("@Nombre", estudiante.Nombre);
			parameters[1] = new SqlParameter("@Apellido", estudiante.Apellido);
			parameters[2] = new SqlParameter("@Matricula", estudiante.Matricula);
			parameters[3] = new SqlParameter("@Telefono", ((object)estudiante.Telefono) ?? DBNull.Value);
			parameters[4] = new SqlParameter("@Email", ((object)estudiante.Email) ?? DBNull.Value);
			parameters[5] = new SqlParameter("@Ciudad", ((object)estudiante.Ciudad) ?? DBNull.Value);
			EjecutarComando(comando, parameters);
		}

		public IEnumerable<Estudiante> Listar()
		{
			string comando = "LEER_ESTUDIANTES_SP";
			return EjecutarComandoLectura(comando)
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

		private IEnumerable<object[]> EjecutarComandoLectura(string comando)
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

		private void EjecutarComando(string comando, SqlParameter[] parameters)
		{
			using (SqlConnection conexion = (SqlConnection)ConexionEstudiante.CrearConexion)
			{
				if (conexion.State != ConnectionState.Open)
					conexion.Open();
				SqlCommand cmd = new SqlCommand(comando, conexion);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddRange(parameters);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
