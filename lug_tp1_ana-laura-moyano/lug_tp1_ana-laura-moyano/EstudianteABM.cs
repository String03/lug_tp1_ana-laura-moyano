using EstudianteABM.DAO;
using EstudianteABM.DAO.Procedure;
using EstudianteABM.DAO.Query;
using EstudianteABM.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lug_tp1_ana_laura_moyano
{
	public partial class EstudianteABM : Form
	{
		private IEstudianteDAO estudianteQuery = new EstudianteDAOQuery();
		private IEstudianteDAO estudianteProcedure = new EstudianteDAOProcedure();

		public EstudianteABM()
		{
			InitializeComponent();
			RefrescarGrillaQuery();
		}

		private void btn_alta_query_Click(object sender, EventArgs e)
		{
			try
			{
				Estudiante estudiante = LeerEstudiante();
				estudianteQuery.Insertar(estudiante);
				RefrescarGrillaQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se pudo insertar el estudiante: " + ex.Message);
			}
		}

		private Estudiante LeerEstudiante()
		{
			if (string.IsNullOrWhiteSpace(txt_matricula_estudiante.Text) ||
				string.IsNullOrWhiteSpace(txt_nombre_estudiante.Text) || string.IsNullOrWhiteSpace(txt_apellido_estudiante.Text))
			{
				throw new Exception("Estudiante no válido");
			}
			Estudiante estudiante = new Estudiante
			{
				Matricula = Convert.ToInt32(txt_matricula_estudiante.Text),
				Nombre = txt_nombre_estudiante.Text,
				Apellido = txt_apellido_estudiante.Text,
				Telefono = txt_telefono_estudiante.Text,
				Email = txt_email_estudiante.Text,
				Ciudad = txt_ciudad_estudiante.Text
			};
			return estudiante;
		}

		private void btn_alta_procedure_Click(object sender, EventArgs e)
		{
			try
			{
				Estudiante estudiante = LeerEstudiante();
				estudianteProcedure.Insertar(estudiante);
				RefrescarGrillaProcedure();
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se pudo insertar el estudiante: " + ex.Message);
			}
		}

		private void btn_modificacion_query_Click(object sender, EventArgs e)
		{
			try
			{
				var estudiante = grillaEstudiante.SelectedRows[0].DataBoundItem as Estudiante;
				Estudiante estudiante_nuevo = LeerEstudiante();
				estudiante.Matricula = estudiante_nuevo.Matricula;
				estudiante.Nombre = estudiante_nuevo.Nombre;
				estudiante.Apellido = estudiante_nuevo.Apellido;
				estudiante.Telefono = estudiante_nuevo.Telefono;
				estudiante.Email = estudiante_nuevo.Email;
				estudiante.Ciudad = estudiante_nuevo.Ciudad;
				estudianteProcedure.Actualizar(estudiante);
				RefrescarGrillaQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se pudo modificar al estudiante: " + ex.Message);
			}
		}

		private void btn_modificacion_procedure_Click(object sender, EventArgs e)
		{
			try
			{
				var estudiante = grillaEstudiante.SelectedRows[0].DataBoundItem as Estudiante;
				Estudiante estudiante_nuevo = LeerEstudiante();
				estudiante.Matricula = estudiante_nuevo.Matricula;
				estudiante.Nombre = estudiante_nuevo.Nombre;
				estudiante.Apellido = estudiante_nuevo.Apellido;
				estudiante.Telefono = estudiante_nuevo.Telefono;
				estudiante.Email = estudiante_nuevo.Email;
				estudiante.Ciudad = estudiante_nuevo.Ciudad;
				estudianteProcedure.Actualizar(estudiante);
				RefrescarGrillaProcedure();
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se pudo modificar al estudiante: " + ex.Message);
			}
		}

		private void btn_baja_query_Click(object sender, EventArgs e)
		{
			try
			{
				var estudiante = grillaEstudiante.SelectedRows[0].DataBoundItem as Estudiante;
				estudianteQuery.Eliminar(estudiante);
				RefrescarGrillaQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se puede eliminar al estudiante: " + ex.Message);
			}
		}

		private void btn_baja_procedure_Click(object sender, EventArgs e)
		{
			try
			{
				var estudiante = grillaEstudiante.SelectedRows[0].DataBoundItem as Estudiante;
				estudianteProcedure.Eliminar(estudiante);
				RefrescarGrillaProcedure();
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se puede eliminar al estudiante: " + ex.Message);
			}
		}

		private void btn_seleccionar_query_Click(object sender, EventArgs e)
		{
			RefrescarGrillaQuery();
		}

		private void RefrescarGrillaQuery()
		{
			grillaEstudiante.DataSource = null;
			grillaEstudiante.DataSource = estudianteQuery.Listar();
		}

		private void btn_seleccionar_procedure_Click(object sender, EventArgs e)
		{
			RefrescarGrillaProcedure();
		}

		private void RefrescarGrillaProcedure()
		{
			grillaEstudiante.DataSource = null;
			grillaEstudiante.DataSource = estudianteProcedure.Listar();
		}
	}
}
