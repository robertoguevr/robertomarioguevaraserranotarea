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


        void cargardatos() 
        {
            //dtvUsuarios.Rows.Clear();
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1())
            {
                //var usuarios = db.estudiante;
                //foreach (var iterarDatos in usuarios) 
                //{
                //    dtvUsuarios.Rows.Add(iterarDatos.id_estudiante, iterarDatos.nombre_estudiante, iterarDatos.apellido,
                //        iterarDatos.usuario, iterarDatos.contrasena);
                //}
                dtvUsuarios.DataSource = db.estudiante.ToList();
            }
               
        }

        void limpiarDatos() 
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtUsuario.Text = "";
            txtContra.Text = "";
        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1()) 
            {
                
                user.usuario = txtUsuario.Text;
                user.contrasena = txtContra.Text;
                user.nombre_estudiante = txtNombre.Text;
                user.apellido = txtApellido.Text;

                db.estudiante.Add(user);
                db.SaveChanges();
            }
            cargardatos();
            limpiarDatos();
        }

        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            estudiante user = new estudiante();
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1()) 
            {
                String Id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                user = db.estudiante.Where(VerificarId => VerificarId.id_estudiante == IdC).First();
                user.nombre_estudiante = txtNombre.Text;
                user.apellido = txtApellido.Text;
                user.usuario = txtUsuario.Text;
                user.contrasena = txtContra.Text;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            cargardatos();
            //limpiarDatos();
            
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            cargardatos();
           
        }

        private void dtvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String nombre = dtvUsuarios.CurrentRow.Cells[1].Value.ToString();
            String apellido = dtvUsuarios.CurrentRow.Cells[2].Value.ToString();
            String usuario = dtvUsuarios.CurrentRow.Cells[3].Value.ToString();
            String contrasena = dtvUsuarios.CurrentRow.Cells[4].Value.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtUsuario.Text = usuario;
            txtContra.Text = contrasena;
        }
    }
}
