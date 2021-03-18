using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudianteABM.Conexiones
{
	public static class ConexionEstudiante
	{
		public static IDbConnection CrearConexion => 
			new SqlConnection(ConfigurationManager.ConnectionStrings["EstudianteDB"].ConnectionString);
	}
}
