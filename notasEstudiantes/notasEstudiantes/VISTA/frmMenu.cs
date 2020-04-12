using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using notasEstudiantes.VISTA;
using notasEstudiantes.Model;

namespace notasEstudiantes.VISTA
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void datosEstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios usu = new frmUsuarios();
            usu.Show();
        }

        private void manteniminetoMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaterias mat = new frmMaterias();
            mat.Show();
        }

        private void ingresarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotas notas = new frmNotas();
            notas.Show();
        }
    }
}
