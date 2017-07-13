using MySql.Data.MySqlClient;
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
    public partial class frmRegistrarServicio : Form
    {
        //Instanciamos a la clase para nuestra consulta y el registro
        Servicios servicio = new Servicios();
        //Instanciamos a la clase para manejar los datos
        GestionarServicios gServicios = new GestionarServicios();
        //Donde obtendremos el nombre de la Empresa
        string empresa;
        //Para validar el campo del precio
        bool Servicio_precio = false;
        //Variable auxiliar para almacenar el precio
        String auxPrecio;
        //Variable auxiliar para verificar el txtPrecio este deacuerdo a lo requerido si es SI ó NO
        bool auxVerificar_precio = false;
        //Para enviar el precio a servicio.Obligatorio
        bool serObligatorio;

        public frmRegistrarServicio()
        {
            InitializeComponent();
            CargarRegistroServicios();
            rdoSI.Checked = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Para mostrar todos los Servicios Registrados
        public void CargarRegistroServicios()
        {
            GestionarServicios obtenerDatos = new GestionarServicios();
            tblServicios.DataSource = obtenerDatos.MostrarServicios();
            tblServicios.Refresh();
        }

        private void txtNombreEmpresa_TextChanged(object sender, EventArgs e)
        {
            txtNombreEmpresa.MaxLength = 15;
            if (txtNombreEmpresa.Text != null)
            {
                empresa = txtNombreEmpresa.Text;
            }

            if (txtServicio.Text != "")
            {
                servicio.Servicio = txtServicio.Text;
                //Donde obtendrempos los datos de la consulta
                MySqlDataReader obtenerDatos = gServicios.BuscarServicio(servicio);

                if (obtenerDatos.HasRows && txtServicio.Text != null)
                {
                    while (obtenerDatos.Read())
                    {
                        if (empresa == obtenerDatos.GetString(0) && txtServicio.Text == obtenerDatos.GetString(1))
                        {
                            MessageBox.Show("El servicio ya se encuentra registrado", "AVISO");
                            txtNombreEmpresa.Text = "";
                            txtServicio.Text = "";
                        }
                    }
                }
            }
        }

        private void txtServicio_TextChanged_1(object sender, EventArgs e)
        {
            txtServicio.MaxLength = 15;
            if (txtServicio.Text != "")
            {
                servicio.Servicio = txtServicio.Text;
                //Donde obtendrempos los datos de la consulta
                MySqlDataReader obtenerDatos = gServicios.BuscarServicio(servicio);

                if (obtenerDatos.HasRows && txtServicio.Text != null)
                {
                    while (obtenerDatos.Read())
                    {
                        if (empresa.ToUpper() == obtenerDatos.GetString(0).ToUpper() && txtServicio.Text.ToUpper() == obtenerDatos.GetString(1).ToUpper())
                        {
                            MessageBox.Show("El servicio ya se encuentra registrado", "AVISO");
                            txtNombreEmpresa.Text = "";
                            txtServicio.Text = "";
                        }
                    }

                }
            }
        }

        private void rdoSI_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecio.Enabled = true;
            txtPrecio.BackColor = Color.White;
            Servicio_precio = false;
            serObligatorio = true;
        }

        private void rdoNO_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecio.Enabled = false;
            txtPrecio.BackColor = Color.Silver;
            Servicio_precio = true;
            serObligatorio = false;
            txtPrecio.Text = "";
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtPrecio.Text.Length; i++)
            {
                if (txtPrecio.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                //precio = true;
                e.Handled = false;
            }
            else if (e.KeyChar == 46)
            {
            //    precio = true;
                e.Handled = (IsDec) ? true : false;
            }
            else
            {
                MessageBox.Show("Solo se perimite numeros, con dos decimales", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                //precio = false;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.MaxLength = 8;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite números", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string auxTelephone = txtTelefono.Text;
            if (auxTelephone.Length == 8)
            {
                if (txtNombreEmpresa.Text != "" && txtServicio.Text != "" && Servicio_precio == false)
                {
                    if (txtPrecio.Text != "")
                    {
                        auxPrecio = txtPrecio.Text;
                        auxVerificar_precio = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe asignar un precio al Servicio \n\tque desea registrar", "AVISO");
                        auxVerificar_precio = false;
                    }
                }

                else if (txtNombreEmpresa.Text != "" && txtServicio.Text != "" && Servicio_precio == true)
                {
                    auxPrecio = "00.00";
                    auxVerificar_precio = true;
                }
                else
                {
                    MessageBox.Show("Depe llenar todos los capos antes requeridos \n          antes de registrar el nuevo Servicio", "AVISO");
                }

                if (auxVerificar_precio == true)
                {
                    servicio.Empresa = txtNombreEmpresa.Text;
                    servicio.Servicio = txtServicio.Text;
                    servicio.Precio = auxPrecio;
                    servicio.Obligatorio = serObligatorio;
                    if (txtTelefono.Text != "" || txtDescripción.Text != "")
                    {
                        servicio.Descripcion = txtDescripción.Text;
                        servicio.Telefono = Convert.ToInt32(txtTelefono.Text);
                    }
                    else
                    {
                        servicio.Descripcion = null;
                        servicio.Telefono = Convert.ToInt32(null);
                    }

                    int resultadoInsert = GestionarServicios.AgregarServicio(servicio);
                    if (resultadoInsert > 0)
                    {
                        MessageBox.Show("El Servicio se registro exitosamente", "GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se logro registrar el Servicio", "Error en el registro".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CargarRegistroServicios();
                }
            }
            else
            {
                MessageBox.Show("El número telefónico no es valido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmServicios frm = new frmServicios();
            frm.Show();
            this.Hide();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombreEmpresa.Text = "";
            txtServicio.Text = "";
            txtPrecio.Text = "";
            txtTelefono.Text = "";
            txtDescripción.Text = "";
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            txtPrecio.MaxLength = 7;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripción_TextChanged(object sender, EventArgs e)
        {
            txtDescripción.MaxLength = 30;
        }
    }
}