using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using notasEstudiantes.Model;

namespace notasEstudiantes.VISTA
{
    public partial class frmNotas : Form
    {
        public frmNotas()
        {
            InitializeComponent();
        }

        void cargardatos() 
        {      
                using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1())
                {
                var jointables = from estudiante in db.estudiante
                                 from materia in db.materia
                                 from notas in db.notas
                                 where estudiante.id_estudiante == notas.id_usuario && materia.id_materia == notas.id_materia

                                 select new
                                 {
                                     Id = notas.id_notas,
                                     Id_Alumno = estudiante.id_estudiante,
                                     Nombre_Alumno = estudiante.nombre_estudiante + " " + estudiante.apellido,
                                     Id_Materia = materia.id_materia,
                                     Materia = materia.nombre_materia,
                                     Nota = notas.notas1

                                 };
                    dtvNotas.DataSource = jointables.ToList();
                    //dtvNotas.Columns[1].Visible = false;
                    //dtvNotas.Columns[3].Visible = false;
                }
            
        }

        void limpiardatos() 
        {
            txtIdEstudiante.Text = "";
            txtIdMat.Text = "";
            txtNota.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            notas notasEstudiantes = new notas();
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1())
            {
                notasEstudiantes.id_usuario = Convert.ToInt32(txtIdEstudiante.Text);
                notasEstudiantes.id_materia = Convert.ToInt32(txtIdMat.Text);
                notasEstudiantes.notas1 = Convert.ToInt32(txtNota.Text);
                db.notas.Add(notasEstudiantes);
                db.SaveChanges();
                
            }
            cargardatos();
            limpiardatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            notas notasEstudiantes = new notas();
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1()) 
            {
                string Id = dtvNotas.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                notasEstudiantes = db.notas.Where(VerificarId => VerificarId.id_notas == IdC).First();
                notasEstudiantes.id_usuario = Convert.ToInt32(txtIdEstudiante.Text);
                notasEstudiantes.id_materia = Convert.ToInt32(txtIdMat.Text);
                notasEstudiantes.notas1 = Convert.ToInt32(txtNota.Text);
                db.Entry(notasEstudiantes).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            cargardatos();
            limpiardatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            notas notasEstudiantes = new notas();
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1())
            {
                string Id = dtvNotas.CurrentRow.Cells[0].Value.ToString();

                notasEstudiantes = db.notas.Find(int.Parse(Id));
                db.notas.Remove(notasEstudiantes);
                db.SaveChanges();
            }
            cargardatos();
            limpiardatos();
         }

        private void dtvNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String IdUsuario = dtvNotas.CurrentRow.Cells[1].Value.ToString();
            String IdMat = dtvNotas.CurrentRow.Cells[3].Value.ToString();
            String Nota = dtvNotas.CurrentRow.Cells[4].Value.ToString();
            txtIdEstudiante.Text = IdUsuario;
            txtIdMat.Text = IdMat;
            txtNota.Text = Nota;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1())
            {
                var jointables = from estudiante in db.estudiante
                                 from materia in db.materia
                                 from notas in db.notas
                                 where estudiante.id_estudiante == notas.id_usuario && materia.id_materia == notas.id_materia

                                 select new
                                 {
                                     Id = notas.id_notas,
                                     Id_Alumno = estudiante.id_estudiante,
                                     Nombre_Alumno = estudiante.nombre_estudiante + " " + estudiante.apellido,
                                     Id_Materia = materia.id_materia,
                                     Materia = materia.nombre_materia,
                                     Nota = notas.notas1

                                 };
                dtvNotas.DataSource = jointables.ToList();
                //dtvNotas.Columns[1].Visible = false;
                //dtvNotas.Columns[3].Visible = false;
            }
        }
    }
}
