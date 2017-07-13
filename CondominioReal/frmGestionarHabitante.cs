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
    public partial class frmGestionarHabitante : Form
    {
        public frmGestionarHabitante()
        {
            InitializeComponent();
            CargarHabitantes();
        }

        public void CargarHabitantes()
        {
            //Instanciamos a la clase donde recibiremos los datos obtenidos
            GestionarHabitante mostrarHabitantes = new GestionarHabitante();
            //Asignamos a nuestra DataGrid los dotos obtenidos
            tblHabitantes.DataSource = mostrarHabitantes.MostrarHabitantes();
            //Refrescamos el DataGrid
            tblHabitantes.Refresh();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarHabitante frm = new frmRegistrarHabitante();
            frm.Show();
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmHomeValido frm = new frmHomeValido();
            frm.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Instanciamos a la clase donde recibiremos los datos obtenidos
            GestionarHabitante mostrarHabitantes = new GestionarHabitante();
            //Asignamos a nuestra DataGrid los dotos obtenidos
            tblHabitantes.DataSource = mostrarHabitantes.ReporteTitulares();
            //Refrescamos el DataGrid
            tblHabitantes.Refresh();
        }

        private void rdoTitulares_CheckedChanged(object sender, EventArgs e)
        {
            //Instanciamos a la clase donde recibiremos los datos obtenidos
            GestionarHabitante mostrarHabitantes = new GestionarHabitante();
            //Asignamos a nuestra DataGrid los dotos obtenidos
            tblHabitantes.DataSource = mostrarHabitantes.ReporteTitulares();
            //Refrescamos el DataGrid
            tblHabitantes.Refresh();
        }

        private void rdoNoTitulares_CheckedChanged(object sender, EventArgs e)
        {
            //Instanciamos a la clase donde recibiremos los datos obtenidos
            GestionarHabitante mostrarHabitantes = new GestionarHabitante();
            //Asignamos a nuestra DataGrid los dotos obtenidos
            tblHabitantes.DataSource = mostrarHabitantes.ReporteNoTitulares();
            //Refrescamos el DataGrid
            tblHabitantes.Refresh();
        }

        private void btnAsignarDepartamento_Click(object sender, EventArgs e)
        {
            frmAsiganacionHabitante_Departamento frm = new frmAsiganacionHabitante_Departamento();
            frm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tblHabitantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
