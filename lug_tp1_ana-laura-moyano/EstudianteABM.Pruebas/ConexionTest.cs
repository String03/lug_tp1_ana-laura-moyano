using EstudianteABM.Conexiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EstudianteABM.Pruebas
{
	[TestClass]
	public class ConexionTest
	{
		[TestMethod]
		public void ConectarTest()
		{
			using (var sqlCon = ConexionEstudiante.CrearConexion)
			{
				sqlCon.Open();
				Assert.IsTrue(sqlCon.State == ConnectionState.Open);
			}
		}
	}
}
