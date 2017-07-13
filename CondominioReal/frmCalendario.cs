using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CondominioReal
{
    public partial class frmCalendario : Form
    {
        Departamento departamento = new Departamento();
        Servicios servicio = new Servicios();
        GestionarExpensas gtrExpensas = new GestionarExpensas();
        //Para obtener el Maximo Id Pago_Servicio
        int idPagoServicio;
        //Para obtner el Mes del ultimo mes de pago de expensas
        int mesMaximo, mesMinimo;

        public frmCalendario()
        {
            InitializeComponent();
            CargarDeudas(); 
        }

        public void CargarDeudas()
        {
            tblResultados.DataSource = gtrExpensas.MostrarDuedas();
            tblResultados.Refresh();
        }

        public string Mes(int mes)
        {
            string auxMes = null;
            if (mes <= 1) { auxMes = "Enero"; }
            if (mes == 2) { auxMes = "Febrero"; }
            if (mes == 3) { auxMes = "Marzo"; }
            if (mes == 4) { auxMes = "Abril"; }
            if (mes == 5) { auxMes = "Mayo"; }
            if (mes == 6) { auxMes = "Junio"; }
            if (mes == 7) { auxMes = "Julio"; }
            if (mes == 8) { auxMes = "Agosto"; }
            if (mes == 9) { auxMes = "Septiembre"; }
            if (mes == 10) { auxMes = "Octubre"; }
            if (mes == 11) { auxMes = "Noviembre"; }
            if (mes >= 12) { auxMes = "Diciembre"; }
            return auxMes;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmHomeValido frm = new frmHomeValido();
            frm.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            departamento.Nombre = txtDepartamentoBuscar.Text;
            tblResultados.DataSource = gtrExpensas.Departamentos_Deudores(departamento);
            tblResultados.Refresh();

            if (txtDepartamentoBuscar.Text != "")
            {
                MySqlDataReader obtenerSaldo = gtrExpensas.BuscarDepartamento(departamento);
                if (obtenerSaldo.HasRows)
                {
                    while (obtenerSaldo.Read())
                    {
                        if (obtenerSaldo.GetTextReader(1) == null || obtenerSaldo.GetString(0) == null || obtenerSaldo.GetString(2)== null || obtenerSaldo.GetString (3) == null)
                        {
                            txtSaldo.Text = "00.00";
                            idPagoServicio = 0;
                            mesMaximo = 0;
                            mesMaximo = 0;
                        }
                        else
                        {
                            mesMaximo = obtenerSaldo.GetInt32(3);
                            mesMinimo = obtenerSaldo.GetInt32(2);
                            txtSaldo.Text = obtenerSaldo.GetString(1);
                            idPagoServicio = obtenerSaldo.GetInt32(0);
                        }
                        txtDepartamento.Text = txtDepartamentoBuscar.Text.ToUpper();
                        txtFecha.Text = DateTime.Now.ToLongDateString();
                    }
                }
                obtenerSaldo.Close();
            }
        }

        private void btnDepartamentos_que_Cancelaron_Click(object sender, EventArgs e)
        {
            tblResultados.DataSource = gtrExpensas.Departamentos_Cancelaron();
            tblResultados.Refresh();
        }

        private void btnDeudas_Click(object sender, EventArgs e)
        {
            tblResultados.DataSource = gtrExpensas.Departamentos_Deudores();
            tblResultados.Refresh();
        }

        private void btnMostrarDepartamentos_Click(object sender, EventArgs e)
        {
            tblResultados.DataSource = gtrExpensas.Departamentos_NoHabitados();
            tblResultados.Refresh();
        }

        private void txtDepartamentoBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtDepartamentoBuscar.Text == "" )
            {
                CargarDeudas();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string fecha = monthCalendar1.SelectionStart.Year + "-" + monthCalendar1.SelectionStart.Month + "-" + monthCalendar1.SelectionStart.Day;
            tblResultados.DataSource = gtrExpensas.MostrarDeudasFechas(fecha);
            tblResultados.Refresh();
        }

        private void txtMontoCancelacion_TextChanged(object sender, EventArgs e)
        {
            
            if (txtMontoCancelacion.Text == "")
            {
                txtDeuda.Text = txtSaldo.Text;
            }
            else
            {
                if (Convert.ToInt32(txtMontoCancelacion.Text) <= Convert.ToInt32(txtSaldo.Text))
                {
                int auxSaldo = Convert.ToInt32(txtSaldo.Text) - Convert.ToInt32(txtMontoCancelacion.Text);
                txtDeuda.Text = auxSaldo.ToString();                    
                }
                else
                {
                    txtMontoCancelacion.Text = "";
                    MessageBox.Show("El monto de cancelación no puede ser mayor al Saldo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txtMontoCancelacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            return;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            servicio.IdServicio = idPagoServicio;
            string fechaCancelacion = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            string auxMes = Mes(mesMaximo);
            int resultado = GestionarExpensas.Registro_Pago_Servicio(servicio, fechaCancelacion, Convert.ToInt32(txtDeuda.Text), auxMes, Convert.ToInt32(txtMontoCancelacion.Text));
            
            if (resultado > 0)
            {
                MessageBox.Show("El registro de pago de servicios se realizo satisfactoriamente", "Registro exitoso".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se logro registro el pago de servicios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int resultadoUpdate =0;
            for (int i = mesMinimo; i <= mesMaximo+1; i++)
            {
                resultadoUpdate = GestionarExpensas.Update_Pago_Servicios(i);
            }
            if (resultadoUpdate > 0)
            {
                MessageBox.Show("Bien");
            }
            else
            {
                MessageBox.Show("Mal");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
