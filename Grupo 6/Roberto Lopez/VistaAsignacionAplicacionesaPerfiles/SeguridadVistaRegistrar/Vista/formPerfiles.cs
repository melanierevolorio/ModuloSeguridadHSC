using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguridadVistaRegistrar.Vista
{
    public partial class formPerfiles : Form
    {
        public formPerfiles()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void formAsignacionAplicaciones_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'aplicacion._aplicacion' Puede moverla o quitarla según sea necesario.
            this.aplicacionTableAdapter.Fill(this.aplicacion._aplicacion);

        }
    }
}
