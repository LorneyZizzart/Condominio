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
    public partial class frmHomeValido : Form
    {
        GestionarDepartamento gtrDepartamentos = new GestionarDepartamento();
        GestionarServicios gtrServicios = new GestionarServicios();
        GestionarExpensas gtrExpensas = new GestionarExpensas();
        Departamento departamento = new Departamento();
        List<Departamento> listaDepartamento = new List<Departamento>();
        int totalAgua = 0, totalPagar = 0, ultimoMes = 0;
        public frmHomeValido()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro que desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnServiciosBasicos_Click(object sender, EventArgs e)
        {
            frmServicios frm = new frmServicios();
            frm.Show();
            this.Hide();
        }

        private void btnBloques_Click(object sender, EventArgs e)
        {
            frmGestionarBloque frm = new frmGestionarBloque();
            frm.Show();
            this.Hide();
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHabitantes_Click(object sender, EventArgs e)
        {
            frmGestionarHabitante frm = new frmGestionarHabitante();
            frm.Show();
            this.Hide();
        }

        private void btnPisos_Click(object sender, EventArgs e)
        {
            frmMultimedia frm = new frmMultimedia();
            frm.Show();
            this.Hide();
        }

        private void btnCobroExpensas_Click(object sender, EventArgs e)
        {
            frmCalendario frm = new frmCalendario();
            frm.Show();
            this.Hide();
        }
        #region COMO HACER UN DELETE EN MYSQL
        /*
         DELETE FROM pago_servicio WHERE id_PagoServicio = 26;
         */

        #endregion

        public void CargaAutomatica_TotalExpensas()
        {
            int auxMes = 0;
            #region Para obtener los nombres y ID de los departamentos en una lista para luego ver su estado_vivienda
            MySqlDataReader obternerDepartamentos = gtrDepartamentos.DeparatamentosDiferentes_a_NoHabitado();

            if (obternerDepartamentos.HasRows)
            {
                while (obternerDepartamentos.Read())
                {
                    listaDepartamento.Add(new Departamento()
                    {
                        Nombre = Convert.ToString(obternerDepartamentos["nombre"]),
                        ID_Vivienda = Convert.ToInt32(obternerDepartamentos["id_Vivienda"])
                    });
                }
            }
            #endregion
            #region Luego comparamos todos los departamentos de la lista para ver su estado_vivienda
            for (int i = 0; i < listaDepartamento.Count; i++)
            {
                departamento.Nombre = listaDepartamento[i].Nombre;
                departamento.ID_Vivienda = listaDepartamento[i].ID_Vivienda;
            #endregion
                #region Para ver el estado del departamento si ees diferente a no habitado
                MySqlDataReader departametoEstado = gtrServicios.EstadoDepartamento(departamento);
                if (departametoEstado.HasRows)
                {
                    while (departametoEstado.Read())
                    {
                        //PARA VER EL ESTADO DEL DEPARTAMENTO
                        if (departametoEstado.GetString(0).ToUpper() != "NO HABITADO")
                        {
                #endregion
                            #region Para ver la ultima fecha de pago_Servicio
                            MySqlDataReader obtener_UltimoMes = gtrExpensas.MostrarUltimaFecha_PagoServicio(departamento);
                            if (obtener_UltimoMes.HasRows)
                            {
                                while (obtener_UltimoMes.Read())
                                {
                                    //Para corregir el error de extraccion del mes en la consulta
                                    //que se incrementaba el mes automaticamente y para corregirlo 
                                    //construimos un algoritmo donde ya no se incremente el ultimo mes obtenido
                                    string dateTime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                                    if (obtener_UltimoMes.GetString(0) == dateTime)
                                    {
                                        
                                    }
                                    else
                                    {
                                        //para registrar la fecha siguiente que le toca pagar al departamento
                                        string fechaPago = DateTime.Now.Year + "-" + DateTime.Now.Month + "-10";
                            #endregion
                                        #region Para obtener el el saldo total del agua y el saldo de los otros servicios
                                        //Para obtener el el saldo total del agua y el saldo de los otros servicios
                                        MySqlDataReader obternerSaldo = gtrServicios.TotalPagoExpensas(departamento);
                                        if (obternerSaldo.HasRows)
                                        {
                                            while (obternerSaldo.Read())
                                            {
                                                totalPagar = obternerSaldo.GetInt32(0) - obternerSaldo.GetInt32(1);
                                                totalAgua = obternerSaldo.GetInt32(1);
                                            }
                                        }
                                        #endregion
                                        #region Para obterner la cantidad de habitantes en cada departamento
                                        //obtenemos el id_departamento
                                        int idDepartamento = departamento.ID_Vivienda;
                                        MySqlDataReader obterner_CantidadHabitante = gtrDepartamentos.ContidadHabitante(idDepartamento);
                                        if (obterner_CantidadHabitante.HasRows)
                                        {
                                            while (obterner_CantidadHabitante.Read())
                                            {
                                                //multiplicamos el agua por la cantidad de habitantes
                                                totalAgua = totalAgua * obterner_CantidadHabitante.GetInt32(0);
                                            }
                                        }
                                        #endregion
                                        //La suma total de todo las expensas que tiene que pagar 
                                        totalPagar = totalPagar + totalAgua;
                                        string auxTotalPago = Convert.ToString(totalPagar) + ".00";
                                        //para poner el estado de cancelado  =  NO
                                        bool cancelado = false;
                                        #region Insersion de pago de servicios del departameto
                                        int resulInsert_PagoServicio = GestionarExpensas.Pago_Servicio(departamento, fechaPago, auxTotalPago, cancelado);

                                        if (resulInsert_PagoServicio > 0)
                                        {
                                            MessageBox.Show("Se actualizo la base de datos de registro de pago de servicios de cada departameto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se logro actualizar la base de datos de pago de servicios de los departamentos", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
