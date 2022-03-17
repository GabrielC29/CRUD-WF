using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFUsuarios.Models;

namespace WFUsuarios.Presentation
{
    public partial class DatosUsuarios : Form
    {
        public int? id;
        usuarios oUsuario = null;
        public DatosUsuarios(int? id = null)
        {
            InitializeComponent();
            
            this.id = id;
            if (id != null)
                CargaDatos();
        }

        private void CargaDatos()
        {
            using(FisiEntities1 db = new FisiEntities1())
            {
                oUsuario = db.usuarios.Find(id);

                txtNombre.Text = oUsuario.nombre;
                txtCorreo.Text = oUsuario.correo;
                dtpFechaNacimiento.Value = (DateTime)oUsuario.fecha_nacimiento;
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(FisiEntities1 db = new FisiEntities1())
            {
                if(id==null)
                    oUsuario = new usuarios();

                oUsuario.nombre = txtNombre.Text;
                oUsuario.correo = txtCorreo.Text;
                oUsuario.fecha_nacimiento = dtpFechaNacimiento.Value;

                if(id==null)
                    db.usuarios.Add(oUsuario);
                else
                {
                    db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                this.Close();
            }
        }

        private void DatosUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
