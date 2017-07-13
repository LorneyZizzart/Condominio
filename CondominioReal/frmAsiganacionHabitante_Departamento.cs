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
    public partial class frmAsiganacionHabitante_Departamento : Form
    {

        //Instanciamos a la clase para utilizar la consulta para la bsuqueda de carnet's
        GestionarHabitante newHabitante = new GestionarHabitante();
        //Instanciamos a la clase de Departamentto
        Departamento departamento = new Departamento();
        //Instanciamos a la clase para la consulta de los departamentos
        GestionarDepartamento newDepartamento = new GestionarDepartamento();
        //Instanciamos a la clase de Habitante
        Habitante habitante = new Habitante();
        //Creamos una variable para recibir el codigo del habitante
        int codigoHabitante;
        //Otro para recibir el codigo del deaprtamento
        int codigoDepartamento;
        //Creamos un variable booleana para ver SI es titular o NO
        bool titular;
        //Creamos una variable de comprobacion de titulares exixtentes
        bool titularExixtente = false;

        public frmAsiganacionHabitante_Departamento()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lblNombres.Text != "" && lblNombreDepartamento.Text != "" && (titular == true || titular == false))
            {
                if (titularExixtente != true)
                {
                    departamento.ID_Vivienda = codigoDepartamento;
                    habitante.Id_Habitante = codigoHabitante;
                    habitante.FechaInicio = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    habitante.FechaFinal = null;
                    habitante.Titular = titular;

                    int resultado = GestionarDepartamento.AsiganrVivienda(departamento, habitante);
                    if (resultado > 0)
                    {
                        MessageBox.Show("La asiganción de Departamento al Habitante fue exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se logro asignar el Departamento al Habitante", "Error en el registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El departamento ya tiene Titular registrado", "Error en el registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No se logro asignar el Habitante a un departamento \n\tdebe marcar la titularidad", "Error en el registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarHabitante_Click(object sender, EventArgs e)
        {
            //Le signamos el numero a buscar
            habitante.Carnet = txtBuscarHabitante.Text;
            //Instanciamos a la clase de consulta de busqueda por Carnet
            MySqlDataReader obtenerCarnet = newHabitante.BuscarHabitante(habitante);

            if (obtenerCarnet.HasRows && txtBuscarHabitante.Text != null)
            {
                while (obtenerCarnet.Read())
                {
                    string sexo = obtenerCarnet.GetString(5);

                    if (sexo == "M")
                    {
                        sexo = "Masculino";
                    }
                    else
                    {
                        sexo = "Femenino";
                    }
                    codigoHabitante = Convert.ToInt32(obtenerCarnet.GetString(0));
                    lblNombres.Text = obtenerCarnet.GetString(1);
                    lblApellidos.Text = obtenerCarnet.GetString(2);
                    lblCarnet.Text = obtenerCarnet.GetString(3);
                    lblDireccion.Text = obtenerCarnet.GetString(4);
                    lblTelefono.Text = "7845133";
                    lblSexo.Text = sexo;
                    lblHabitante.Text = obtenerCarnet.GetString(6);
                }
                obtenerCarnet.Close();
            }
        }

        private void btnBuscarDepartamento_Click(object sender, EventArgs e)
        {
            //Le pasamos el nombre del departamento
            departamento.Nombre = txtBuscarDepartamento.Text;
            //Instanciamos a la clase para la consulta de busqueda del departamento
            MySqlDataReader obtenerDepartamento = newDepartamento.BuscarDepartamento(departamento);

            if (obtenerDepartamento.HasRows && txtBuscarDepartamento.Text != null)
            {
                while (obtenerDepartamento.Read())
                {
                    string estado = obtenerDepartamento.GetString(0);

                    if (estado.ToUpper() == "TRUE")
                    {
                        estado = "Ocupado";
                    }
                    else
                    {
                        estado = "Libre";
                    }

                    lblEstado.Text = estado;
                    lblNombreDepartamento.Text = obtenerDepartamento.GetString(1);
                    lblSuperficie.Text = obtenerDepartamento.GetString(2);
                    lblNroHabitaciones.Text = obtenerDepartamento.GetString(3);
                    lblNroSanitario.Text = obtenerDepartamento.GetString(4);
                    lblPrecioVenta.Text = obtenerDepartamento.GetString(5) + " Bs.";
                    lblPrecioCompra.Text = obtenerDepartamento.GetString(6) + " Bs.";
                    lblDescripcion.Text = obtenerDepartamento.GetString(7);
                    codigoDepartamento = Convert.ToInt32(obtenerDepartamento.GetString(8));
                    titularExixtente = Convert.ToBoolean(obtenerDepartamento.GetString(9));
                    //MessageBox.Show(titularExixtente.ToString());

                }
                obtenerDepartamento.Close();
            }
        }

        private void rdoSi_CheckedChanged(object sender, EventArgs e)
        {
            titular = true;
        }

        private void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            titular = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmGestionarHabitante frm = new frmGestionarHabitante();
            frm.Show();
            this.Hide();
        }
    }
}
