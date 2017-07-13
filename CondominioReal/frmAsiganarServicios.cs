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
    public partial class frmAsiganarServicios : Form
    {
        Servicios servicio = new Servicios();
        Departamento departamento = new Departamento();
        GestionarServicios obtenerServicios = new GestionarServicios();
        GestionarDepartamento obtenerDepartamento = new GestionarDepartamento();
        //Para obtener el Id del Departamento y Id del Servicio
        int idDepartamento;
        //Para obtener la cantidad de Habitantes que viven en el departamento
        int CantidadHabitante = 0;
        //Para obtener el precio del servicio
        string precioAgua, totalExpensas;
        int totalAgua;
        public frmAsiganarServicios()
        {
            InitializeComponent();
            CargarBloques();
            lblBloque.Text = "GUANAY";
        }

        //Para cargar todos los bloques
        public void CargarBloques()
        {
            GestionarDepartamento obtenerDatos = new GestionarDepartamento();
            cboxBloque.DataSource = obtenerDatos.ObtenerBloques();
            cboxBloque.DisplayMember = "nombreBloque";
            GestionarDepartamento obtenerDepartamentos = new GestionarDepartamento();
            cboxDepartamento.DataSource = obtenerDepartamentos.ObtenerDepartamentos(cboxBloque.Text);
            cboxDepartamento.DisplayMember = "nombre";
            lblBloque.Text = cboxBloque.Text.ToUpper();
        }

        public void ObtenerIdDepartamento()
        {
            //Para obtener el ID_Departamnto 
            //Recivimos el  nombre del departamento
            //Consultamos atraves del nombre el Id_Departamento
            MySqlDataReader obtener_IdDepartamento = obtenerDepartamento.Obtener_IdDepartamento(departamento);
            //Leemos Los datos adquiridos
            if (obtener_IdDepartamento.HasRows)
            {
                while (obtener_IdDepartamento.Read())
                {
                    idDepartamento = Convert.ToInt32(obtener_IdDepartamento.GetString(0));

                    MySqlDataReader obtener_CantidadHabitante = obtenerDepartamento.ContidadHabitante(idDepartamento);
                    if (obtener_CantidadHabitante.HasRows)
                    {
                        while (obtener_CantidadHabitante.Read())
                        {
                            CantidadHabitante = obtener_CantidadHabitante.GetInt32(0);
                        }
                    }
                }
                obtener_IdDepartamento.Close();
            }
        }
        //Cargar el Total de expensas
        //public void CargarTotalExpensas()
        //{
        //    departamento.Nombre = lblDepartamento.Text;

        //    MySqlDataReader precioExpensas = obtenerServicios.TotalPagoExpensas(departamento);
        //    if (precioExpensas.HasRows)
        //    {
        //        while (precioExpensas.Read())
        //        {
        //            if (precioExpensas.GetString(1) == null || precioExpensas.GetString(0) == null)
        //            {
        //                precioAgua = "00.00";
        //                totalExpensas = "00.00";
        //            }
        //            else
        //            {
        //                precioAgua = precioExpensas.GetString(1);
        //                totalExpensas = precioExpensas.GetString(0);
        //            }

        //        }
        //    }
        //    lblTotalExpensas.Text = totalExpensas + ".00 Bolivianos ";
        //    //totalAgua = CantidadHabitante * Convert.ToInt32(precioAgua);
        //    //lblTotalExpensas.Text = totalAgua.ToString();
        //    //totalExpensas = totalAgua - precioAgua;
        //    //lblTotalExpensas.Text = totalExpensas.ToString() + " Bs./ctvs.";
        //}
        
        private void cboxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            //Para cargar el cboxServicios
            if (cboxDepartamento.Text != "")
            {
                cboxServicio.DisplayMember = "servicio";
                cboxServicio.DataSource = obtenerServicios.ObtenerServicios();
                //Para ver todos los servicios que tiene registrado el departamento
                departamento.Nombre = cboxDepartamento.Text;
                MySqlDataReader departametoEstado = obtenerServicios.EstadoDepartamento(departamento);

                if (departametoEstado.HasRows)
                {
                    while (departametoEstado.Read())
                    {
                        //PARA VER EL ESTADO DEL DEPARTAMENTO
                        if (departametoEstado.GetString(0).ToUpper() != "NO HABITADO")
                        {
                            tblServicios.DataSource = obtenerServicios.BuscarServicios_Depa(departamento);
                            tblServicios.Refresh();
                        }
                        else
                        {
                            tblServicios.DataSource = obtenerServicios.Departamento_SinServicios();
                            tblServicios.Refresh();
                            DialogResult result = MessageBox.Show("El departamento no cuenta con ningun servicio regsitrado y no podra\n    asignar ningún servicio al departamento " + cboxDepartamento.Text + " por que su estado se\nencuentra en NO HABITADO" +
                                            "¿Desea cambiar el estado del departameto?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {

                            }
                        }
                    }
                }

            }
            //Para cargar el cboxEmpresaServicio depediendo el cboxServicio
            if (cboxServicio.Text != "")
            {
                servicio.Servicio = cboxServicio.Text;
                cboxEmpresa.DisplayMember = "nombre_EmpresaServicio";
                cboxEmpresa.DataSource = obtenerServicios.ObtenerEmpresaServicio(servicio);
            }
            //Para ver que departamento fue seleccionado en DETALLES
            lblDepartamento.Text = cboxDepartamento.Text;
            //Para cargar el total de expensas
            //CargarTotalExpensas();
        }

        private void cboxServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            //Para el llenado el cboxServicios
            servicio.Servicio = cboxServicio.Text;
            cboxEmpresa.DataSource = obtenerServicios.ObtenerEmpresaServicio(servicio);
            cboxEmpresa.DisplayMember = "nombre_EmpresaServicio";
            //Para saber si es obligatorio el Servicio y el Precio
            MySqlDataReader obtenerPrecio = obtenerServicios.PrecioServicio(cboxServicio.Text, cboxEmpresa.Text);

            if (obtenerPrecio.HasRows && cboxServicio.Text != "")
            {
                while (obtenerPrecio.Read())
                {
                    txtPrecio.Text = obtenerPrecio.GetString(1);
                    //Para comparar y luego sacar SI es Obligatorio o  NO
                    if (Convert.ToBoolean(obtenerPrecio.GetString(2)) == true)
                    {
                        lblSI_NO.Text = "SI";
                    }
                    else
                        lblSI_NO.Text = "NO";
                    
                }
                obtenerPrecio.Close();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Recivimos el  nombre del departamento
            departamento.Nombre = cboxDepartamento.Text;
            MySqlDataReader departametoEstado = obtenerServicios.EstadoDepartamento(departamento);

            if (departametoEstado.HasRows)
            {
                while (departametoEstado.Read())
                {
                    //PARA VER EL ESTADO DEL DEPARTAMENTO
                    if (departametoEstado.GetString(0).ToUpper() != "NO HABITADO")
                    {
                        servicio.Servicio = cboxServicio.Text;
                        servicio.Empresa = cboxEmpresa.Text;
                        //Para obtener el ID del servicio que se quiere registrar al Departamento para luego verificar si el servicio no se repite
                        MySqlDataReader id_Servicio = obtenerDepartamento.BuscarServicio_en_Departamento(departamento, servicio);
                        int auxIdServicio = 0;
                        if (id_Servicio.HasRows)
                        {
                            while (id_Servicio.Read())
                            {
                                auxIdServicio = Convert.ToInt32(id_Servicio.GetString(0));
                            }
                        }

                        //Para obtener el id departamento
                        ObtenerIdDepartamento();
                        //Para obtener el Id del Servicio
                        MySqlDataReader obtenerPrecio = obtenerServicios.PrecioServicio(cboxServicio.Text, cboxEmpresa.Text);

                        if (obtenerPrecio.HasRows && cboxServicio.Text != "")
                        {
                            while (obtenerPrecio.Read())
                            {
                                //Para obtener el ID de la empresaServicio para luego guardar
                                servicio.IdServicio = Convert.ToInt32(obtenerPrecio.GetString(0));
                                //txtPrecio.Text = Convert.ToString(obtenerPrecio.GetString(0));
                            }
                            obtenerPrecio.Close();
                        }
                        //Para verificar el txtObservaciones si esta vacio o no
                        string auxObservaciones;
                        if (txtObservaciones.Text != "")
                        {
                            auxObservaciones = txtObservaciones.Text;
                        }
                        else
                        {
                            auxObservaciones = null;
                        }
                        //Para verificar si el servicio ya se encuentra registrado en el departamento
                        if (auxIdServicio != servicio.IdServicio)
                        {
                            //Para registrar el servicio al Departamento
                            int resulAsigServicio = GestionarServicios.AgregarServicio_Depa(servicio.IdServicio, idDepartamento, auxObservaciones);

                            if (resulAsigServicio > 0)
                            {
                                MessageBox.Show("La asignación del servicio al departamento se realizo exitosamente", "REGISTRO EXITOSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se logro asignar el servicio al departamento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El departamento ya cuenta con el servicio de " + servicio.Servicio + "\nno se puede volver a asignar el mismo servicio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        //Para cargar nuevamente la tabla de servicios del Departamento
                        tblServicios.DataSource = obtenerServicios.BuscarServicios_Depa(departamento);
                        tblServicios.Refresh();
                    }
                    else
                    {
                        tblServicios.DataSource = obtenerServicios.Departamento_SinServicios();
                        tblServicios.Refresh();
                        DialogResult result = MessageBox.Show("No se le puede asignar un servicio al departamento \n   porque se encuentra en estado NO HABITADO" +
                                        "\n    ¿Desea cambiar el estado del departameto?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            
                        }
                    }
                }
            }


            //CargarTotalExpensas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cboxDepartamento.Text = null; cboxServicio.Text = null; cboxEmpresa.Text = null;
            txtPrecio.Text = null; txtObservaciones.Text = null; tblServicios.DataSource = null;
            lblBloque.Text = null; lblDepartamento.Text = null; lblSI_NO.Text = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmServicios frm = new frmServicios();
            frm.Show();
            this.Hide();
        }

        private void cboxBloque_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxBloque.DropDownStyle = ComboBoxStyle.DropDownList;
            GestionarDepartamento obtenerDatos = new GestionarDepartamento();
            cboxDepartamento.DataSource = obtenerDatos.ObtenerDepartamentos(cboxBloque.Text);
            cboxDepartamento.DisplayMember = "nombre";
            lblBloque.Text = cboxBloque.Text.ToUpper();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void cboxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
