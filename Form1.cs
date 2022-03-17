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
using WFUsuarios.Presentation;

namespace WFUsuarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (FisiEntities1 db = new FisiEntities1())
            {
                Refrescar();
            }
        }

        #region HELPER
            private void Refrescar()
            {
                using (FisiEntities1 db = new FisiEntities1())
                {
                    var lst = from p in db.usuarios
                              select p;

                    dataGridView1.DataSource = lst.ToList();
                }
            }

            private int? GetId()
            {
                try
                {
                    return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                }
                catch 
                {
                    return null;
                };

            }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation.DatosUsuarios oDatosUsuario = new Presentation.DatosUsuarios();
            oDatosUsuario.ShowDialog();

            Refrescar();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Presentation.DatosUsuarios oDatosUsuario = new Presentation.DatosUsuarios(id);

                oDatosUsuario.ShowDialog();

                Refrescar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {

                using(FisiEntities1 db = new FisiEntities1())
                {
                    usuarios oUsuario = db.usuarios.Find(id);
                    db.usuarios.Remove(oUsuario);
                    db.SaveChanges();
                }
                Refrescar();
            }
        }
    }
}
