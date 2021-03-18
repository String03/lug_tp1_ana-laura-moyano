using EstudianteABM.Modelos;
using System.Collections.Generic;

namespace EstudianteABM.DAO
{
	public interface IEstudianteDAO
	{
		IEnumerable<Estudiante> Listar();
		void Insertar(Estudiante estudiante);
		void Actualizar(Estudiante estudiante);
		void Eliminar(Estudiante estudiante);
	}
}
