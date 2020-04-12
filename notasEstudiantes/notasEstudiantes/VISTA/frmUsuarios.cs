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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        estudiante user = new estudiante();
       

        //Limpiar datos de las cajas de texto

        void limpiarDatos() 
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtUsuario.Text = "";
            txtContra.Text = "";
        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities db = new notasEstudiantesEntities()) 
            {
                
                user.usuario = txtUsuario.Text;
                user.contrasena = txtContra.Text;
                user.nombre_estudiante = txtNombre.Text;
                user.apellido = txtApellido.Text;

                db.estudiante.Add(user);
                db.SaveChanges();
            }
            
        }

        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities db = new notasEstudiantesEntities()) 
            {
                
                //int IdC = int.Parse(Id);
                //user = db.estudiante.Where(Verificar_ID => Verificar_ID.id_estudiante == IdC).First();
                user.nombre_estudiante = txtNombre.Text;
                user.apellido = txtApellido.Text;
                user.usuario = txtUsuario.Text;
                user.contrasena = txtContra.Text;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
           
           
        }
    }
}
