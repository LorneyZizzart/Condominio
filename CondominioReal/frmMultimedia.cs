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
    public partial class frmMultimedia : Form
    {

        //Instanciamos a la clase Departamento para hacer la busqueda
        Departamento departamento = new Departamento();
        //Creamos una variable entera para recibir la posicion de la columna del DataGried
        int posicion;
        //Creamos una variable para obtener el codigo del Departamento
        string codigo;
        //Creamos una variable booleana para verificar que si se esta obteniendo el codigo del Departamento
        bool validarCodigo = false;
        //Creamos una variable donde recibiremos nuestra imagen
        Image image;
        public frmMultimedia()
        {
            InitializeComponent();
            CargarDepartamentos();
        }
        public void CargarDepartamentos()
        {
            //Instanciamos a la clase para obtener los datos
            GestionarDepartamento mostrarDepartamentos = new GestionarDepartamento();
            //Llenamos el DataGrid con los datos otenidos
            tblDepartamentos.DataSource = mostrarDepartamentos.MostrarDepartamentos();
            //Refrescamos nuestro DataGried
            tblDepartamentos.Refresh();
        }
        private void btnBuscarDepartamento_Click(object sender, EventArgs e)
        {
            departamento.Nombre = txtBuscarDepartamentos.Text;
            //Instanciamos a la clase para obtener los datos
            GestionarDepartamento mostrarDepartamentos = new GestionarDepartamento();
            //Llenamos el DataGrid con los datos otenidos
            tblDepartamentos.DataSource = mostrarDepartamentos.MostrarDepartamentos(departamento);
            //Refrescamos nuestro DataGried
            tblDepartamentos.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmHomeValido frm = new frmHomeValido();
            frm.Show();
            this.Hide();
        }

        private void tblDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Para que automaticamente recivamos la pocion en las columnas
            posicion = tblDepartamentos.CurrentRow.Index;
            //Asignamos el valor obtenido
            codigo = tblDepartamentos[0, posicion].Value.ToString();

            if (codigo != null)
            {
                validarCodigo = true;
            }
            else
                validarCodigo = false;
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            //Instanciamos a la Clase para abrir imagenes
            OpenFileDialog abrir = new OpenFileDialog();

            abrir.Title = "Abrir";
            abrir.Filter = "Archivo JPG|*.jpg";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                pictureImage.Image = Image.FromFile(abrir.FileName);
                departamento.ID_Vivienda = (int)tblDepartamentos[0, posicion].Value;
                departamento.TipoMultimedia = "Foto";
                departamento.RutaMultimedia = abrir.FileName;
            }
        }

        private void btnAgregarVideo_Click(object sender, EventArgs e)
        {

        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureVideo_Click(object sender, EventArgs e)
        {

        }

        private void pictureImage_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
