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

namespace notasEstudiantes
{
    public partial class Logueo : Form
    {
        public Logueo()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities db = new notasEstudiantesEntities()) 
            {
                var lista = from usuario in db.estudiante
                            where usuario.usuario == txtUsuario.Text
                            && usuario.contrasena == txtContra.Text
                            select usuario;

                if (lista.Count() > 0)
                {
                    MessageBox.Show("Bienvenido");
                }
                else 
                {
                    MessageBox.Show("Usuario o Contraseña incorrecta");
                }
            }
        }
    }
}
