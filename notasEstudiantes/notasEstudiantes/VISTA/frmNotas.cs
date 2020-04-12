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
            using (notasEstudiantesEntities db = new notasEstudiantesEntities())
            {
                dataGridView1.DataSource = db.materia.ToList();
            }
        }
        notas notasEstudiantes = new notas();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities db = new notasEstudiantesEntities())
            {
                notasEstudiantes.id_estudiante = txtIdEstudiante.Text.Length;
                notasEstudiantes.id_materia = txtIdMat.Text.Length;
                notasEstudiantes.notas1 = txtNota.Text.Length;

                db.notas.Add(notasEstudiantes);
                db.SaveChanges();
            }
            cargardatos();
        }
    }
}
