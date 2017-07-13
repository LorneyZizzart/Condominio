using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CondominioReal
{
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
            MostrarServicios();
        }

        public void MostrarServicios()
        {
            //Instanciamos a la clase para obtener los datos
            GestionarServicios mostrarServicios = new GestionarServicios();
            //Llenamos el DataGrid con los datos otenidos
            tblServicios.DataSource = mostrarServicios.MostrarServicios();
            //Refrescamos nuestro DataGried
            tblServicios.Refresh();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRegistrarServicio frm = new frmRegistrarServicio();
            frm.Show();
            this.Hide();
        }

        private void btnAsignarServicios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmHomeValido frm = new frmHomeValido();
            frm.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Instanciamos a la clase para obtener los datos
            GestionarServicios mostrarServicios = new GestionarServicios();
            //Llenamos el DataGrid con los datos otenidos
            tblServicios.DataSource = mostrarServicios.BuscarXServicio(txtBuscarServicio.Text);
            //Refrescamos nuestro DataGried
            tblServicios.Refresh();
        }

        private void txtBuscarServicio_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarServicio.Text == "")
            {
                MostrarServicios();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAsignarDepartamento_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tblServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
