using EstudianteABM.DAO.Query;
using EstudianteABM.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace EstudianteABM.Pruebas
{
	[TestClass]
	public class QueryTest
	{
		[TestMethod]
		public void SelectTest()
		{
			EstudianteDAOQuery query = new EstudianteDAOQuery();
			IEnumerable<Estudiante> estudiantes = query.Listar();
		}
	}
}
