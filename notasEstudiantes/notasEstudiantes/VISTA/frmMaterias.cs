﻿using System;
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
    public partial class frmMaterias : Form
    {
        public frmMaterias()
        {
            InitializeComponent();
        }
        
        materia mat = new materia();

        void cargarDatos() 
        {
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1())
            {
                dtvMateria.DataSource = db.materia.ToList();
            }
        }


        void LimpiarDatos() 
        {
            txtMateria.Text = "";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1()) 
            {
                
                mat.nombre_materia = txtMateria.Text;
                db.materia.Add(mat);
                db.SaveChanges();
            }
            cargarDatos();
            LimpiarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1()) 
            {     
            String Id = dtvMateria.CurrentRow.Cells[0].Value.ToString();
            int IdC = int.Parse(Id);
            mat = db.materia.Where(Verificar_ID => Verificar_ID.id_materia == IdC).First();
            mat.nombre_materia = txtMateria.Text;
            db.Entry(mat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            }
            cargarDatos();
            LimpiarDatos();
        }

        private void dtvMateria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String Materia = dtvMateria.CurrentRow.Cells[1].Value.ToString();
            txtMateria.Text = Materia;
        }

       
        private void Materias_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            materia mat = new materia();
            using (notasEstudiantesEntities1 db = new notasEstudiantesEntities1()) 
            {
                string Id = dtvMateria.CurrentRow.Cells[0].Value.ToString();
                mat = db.materia.Find(int.Parse(Id));
                db.materia.Remove(mat);
                db.SaveChanges();
            }
            cargarDatos();
            LimpiarDatos();
        }
    }
}
