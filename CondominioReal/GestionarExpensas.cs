using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CondominioReal
{
    class GestionarExpensas
    {
        //Instanciamos a la clase donde recibiremos la conexion a nuestra BD
        MySqlConnection conexionBD = new MySqlConnection();
        //Para mostrar todas las Deudas [Gestionar Expensas]
        public DataTable MostrarDuedas()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT v.nombre as DEPARTAMENTO, ps.fechaPago as 'FECHA DE PAGO', ps.montoPagoObligatorio as 'MONTO DE CANCELACION' " +
                                       "FROM vivienda v, pago_servicio ps " +
                                       "WHERE ps.id_Vivienda = v.id_Vivienda " +
                                       "AND ps.cancelado = false";

            /*[CONSULTA]
             SELECT v.nombre as DEPARTAMENTO, ps.fechaPago as 'FECHA DE PAGO', ps.montoPagoObligatorio as 'MONTO DE CANCELACION'
             FROM vivienda v, pago_servicio ps
             WHERE ps.id_Vivienda = v.id_Vivienda
             AND ps.cancelado = false;
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaHabitante;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message, "ERROR");
            }
            //retorno de todos los datos obtenidos
            return datos;
        }
        //Para mostrar todas las Deudas por Fechas [Gestionar Expensas]
        public DataTable MostrarDeudasFechas(string fecha)
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT v.nombre as DEPARTAMENTO, ps.fechaPago as 'FECHA DE PAGO', ps.montoPagoObligatorio as 'MONTO DE CANCELACION' " +
                                      "FROM vivienda v, pago_servicio ps " +
                                      "WHERE ps.id_Vivienda = v.id_Vivienda " +
                                      "AND ps.cancelado = false " +
                                      "AND ps.fechaPago <= '" + fecha + "'";

            /*[CONSULTA]
             SELECT v.nombre as DEPARTAMENTO, ps.fechaPago as 'FECHA DE PAGO', ps.montoPagoObligatorio as 'MONTO DE CANCELACION'
             FROM vivienda v, pago_servicio ps
             WHERE ps.id_Vivienda = v.id_Vivienda
             AND ps.cancelado = false
             AND ps.fechaPago <= '2016-08-10';
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaHabitante;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message, "ERROR");
            }
            //retorno de todos los datos obtenidos
            return datos;
        }
        //Mostrar todos los departamentos no habitados y que su saldo sea 0 [frmCalendario]
        public DataTable Departamentos_NoHabitados()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT v.id_Vivienda AS ID, ev.tipoEstado as ESTADO, v.nombre as DEPARTAMENTO, IF(ev.tipoEstado = 'No Habitado', '00.00', '120.00') as SALDO " +
                                      "FROM vivienda v, estado_vivienda ev " +
                                      "WHERE v.id_Estado = ev.id_Estado " +
                                      "AND ev.tipoEstado = 'No Habitado' " +
                                      "ORDER BY v.nombre";

            /*[CONSULTA]
             SELECT v.id_Vivienda AS ID, ev.tipoEstado as ESTADO, v.nombre as DEPARTAMENTO, IF(ev.tipoEstado = 'No Habitado', '00.00', '120.00') as SALDO
             FROM vivienda v, estado_vivienda ev
             WHERE v.id_Estado = ev.id_Estado
             AND ev.tipoEstado = 'No Habitado'
             ORDER BY v.nombre;
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaHabitante;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message, "ERROR");
            }
            //retorno de todos los datos obtenidos
            return datos;
        }
        //Mostrar todos los departamentos que deben mas de un mes [frmCalendario]
        public DataTable Departamentos_Deudores()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT v.nombre, IF(( " +
                                                             "SELECT SUM(ps.montoPagoObligatorio) as TOTAL " +
                                                             "FROM vivienda v, pago_servicio ps " +
                                                             "WHERE ps.id_Vivienda = v.id_Vivienda " +
                                                             "AND ps.cancelado = false) = NULL, ' ', 'NO CANCELADO' ) AS DEUDA, ps.fechaPago as MES,  ps.montoPagoObligatorio as SALDO " +
                                       "FROM vivienda v, pago_servicio ps " +
                                       "WHERE ps.id_Vivienda = v.id_Vivienda " +
                                       "AND ps.cancelado = false";

            /*[CONSULTA]
             SELECT v.nombre, IF((
                      SELECT SUM(ps.montoPagoObligatorio) as TOTAL
                      FROM vivienda v, pago_servicio ps
                      WHERE ps.id_Vivienda = v.id_Vivienda
                      AND ps.cancelado = false) = NULL, ' ', 'NO CANCELO' ) AS DEUDA, ps.fechaPago as MES,  ps.montoPagoObligatorio as SALDO
              FROM vivienda v, pago_servicio ps
              WHERE ps.id_Vivienda = v.id_Vivienda
              AND ps.cancelado = false;
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaHabitante;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message, "ERROR");
            }
            //retorno de todos los datos obtenidos
            return datos;
        }

        //Mostrar todos los departamentos que cancelaron [frmCalendario]
        public DataTable Departamentos_Cancelaron()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT v.id_Vivienda AS ID, v.nombre AS DEPARTAMENTO, rps.mesesPagados AS 'ULTIMO MES', rps.deudaAcumulada AS DEUDA, rps.montoCancelado as 'MONTO CANCELADO', rps.fechaCancelacion as 'FECHA DE CANCELACION' " +
                                       "FROM vivienda v, pago_servicio ps, registro_pago_servicio rps " +
                                       "WHERE v.id_Vivienda = ps.id_Vivienda " +
                                       "AND ps.id_PagoServicio = rps.id_PagoServicio";

            /*[CONSULTA]
             SELECT v.id_Vivienda AS ID, v.nombre AS DEPARTAMENTO, rps.mesesPagados AS 'MESES CANCELADOS', rps.deudaAcumulada AS DEUDA, rps.montoCancelado as 'MONTO CANCELADO', rps.fechaCancelacion as 'FECHA DE CANCELACION'
              FROM vivienda v, pago_servicio ps, registro_pago_servicio rps
              WHERE v.id_Vivienda = ps.id_Vivienda
              AND ps.id_PagoServicio = rps.id_PagoServicio;
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaHabitante;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message, "ERROR");
            }
            //retorno de todos los datos obtenidos
            return datos;
        }
        //Buscar  departamento que deben mas de un mes [frmCalendario]
        public DataTable Departamentos_Deudores(Departamento departamento)
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT v.nombre, IF(( " +
                                                             "SELECT SUM(ps.montoPagoObligatorio) as TOTAL " +
                                                             "FROM vivienda v, pago_servicio ps " +
                                                             "WHERE ps.id_Vivienda = v.id_Vivienda " +
                                                             "AND ps.cancelado = FALSE) = NULL, ' ', 'NO CANCELADO' ) AS DEUDA, ps.fechaPago as MES,  ps.montoPagoObligatorio as SALDO " +
                                       "FROM vivienda v, pago_servicio ps " +
                                       "WHERE ps.id_Vivienda = v.id_Vivienda " +
                                       "AND ps.cancelado = false " +
                                       "AND v.nombre = '" + departamento.Nombre + "'";

            /*[CONSULTA]
             SELECT v.nombre, IF((  
                           SELECT SUM(ps.montoPagoObligatorio)
                            FROM vivienda v, pago_servicio ps
                            WHERE ps.id_Vivienda = v.id_Vivienda
                            AND ps.cancelado = false) = NULL, ' ', 'NO CANCELADO' ) AS DEUDA, ps.fechaPago as MES,  ps.montoPagoObligatorio as SALDO
              FROM vivienda v, pago_servicio ps
              WHERE ps.id_Vivienda = v.id_Vivienda
              AND ps.cancelado = false
              AND v.nombre = 'A1';
             * 
             SELECT IF('NO'='NO', 'IGUAL', 'DIFERERNTE') AS COMPARACION;
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaHabitante;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message, "ERROR");
            }
            //retorno de todos los datos obtenidos
            return datos;
        }
        //para mostrar el saldo del departamento [frmCALENDARIO]
        public MySqlDataReader BuscarDepartamento(Departamento departamento)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarHabitante = "SELECT MAX(ps.id_PagoServicio) AS ID, SUM(ps.montoPagoObligatorio), MONTH(MIN(ps.fechaPago)) as 'MES MINIMO',  MONTH(MAX(ps.fechaPago)) as 'MES MAXIMO' " +
                                     "FROM vivienda v, pago_servicio ps " +
                                     "WHERE ps.id_Vivienda = v.id_Vivienda " +
                                     "AND ps.cancelado = false " +
                                     "AND v.nombre = '" + departamento.Nombre + "'";

            /*[CONSULTA]
             SELECT MAX(ps.id_PagoServicio) AS ID, SUM(ps.montoPagoObligatorio) as SALDO, MONTH(MIN(ps.fechaPago)) as 'MES MINIMO', MONTH(MAX(ps.fechaPago)) as 'MES MAXIMO'
              FROM vivienda v, pago_servicio ps
              WHERE ps.id_Vivienda = v.id_Vivienda
              AND ps.cancelado = false
              AND v.nombre = 'A2'
              AND ps.id_PagoServicio = (
                                        SELECT MIN(ps.id_PagoServicio)
                                        FROM vivienda v, pago_servicio ps
                                        WHERE ps.id_Vivienda = v.id_Vivienda
                                        AND ps.cancelado = false
                                        AND v.nombre = 'A2'
                                        );
             * */

            try
            {
                //Nos creamos una variable para la conexion y luego la consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion para nuestra conexion
                cmd.Connection = conexionBD;
                //le pasamos la consulta
                cmd.CommandText = buscarHabitante;
                //Creamos una variable donde obtendremos todos los datos
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message);
            }

            return obtenerDatos;
        }

        //Para registrar el registro_pago_servicio
        public static int Registro_Pago_Servicio(Servicios servicio, String fechaCancelacion, int deudaAcumulada, string mesPaagado, int montoCancelado)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO registro_pago_servicio( id_PagoServicio, fechaCancelacion, deudaAcumulada, mesesPagados, montoCancelado)" +
                                               "VALUES ({0}, '{1}', {2}, '{3}', {4})",
                                               servicio.IdServicio, fechaCancelacion, deudaAcumulada, mesPaagado, montoCancelado),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        //para el update 
        public static int Update_Pago_Servicios(int id_PagoServicio)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE pago_servicio SET cancelado = TRUE WHERE id_PagoServicio = "+id_PagoServicio),
                                               cn.ObtenerConexion());

            //UPDATE table1 SET col_a='new' WHERE key_col='key';
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        //Para registrar el pago_servicio
        public static int Pago_Servicio(Departamento departamento, string fechaPago, string montoObligatorio, bool cancelado)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO pago_servicio(id_Vivienda, fechaPago, montoPagoObligatorio, cancelado)" +
                                               " VALUES ({0}, '{1}', '{2}', {3})",
                                               departamento.ID_Vivienda, fechaPago, montoObligatorio, cancelado),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        //PARA VER LA ULTIMA FECHA REGISTRADA PARA EL PAGO DE LAS EXPENSAS[frmHomeValido]
        public MySqlDataReader MostrarUltimaFecha_PagoServicio(Departamento departamento)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarHabitante = "SELECT MAX(fechaPago) as 'ULTIMA FECHA' " +
                                     "FROM pago_servicio ps, vivienda v " +
                                     "WHERE v.id_Vivienda = v.id_Vivienda " +
                                     "AND v.nombre = '" + departamento.Nombre + "'";

            /*[CONSULTA]
             SELECT MAX(fechaPago) as 'ULTIMA FECHA'
             FROM pago_servicio ps, vivienda v
             WHERE v.id_Vivienda = v.id_Vivienda
             AND v.nombre = 'A2'
             * */

            try
            {
                //Nos creamos una variable para la conexion y luego la consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion para nuestra conexion
                cmd.Connection = conexionBD;
                //le pasamos la consulta
                cmd.CommandText = buscarHabitante;
                //Creamos una variable donde obtendremos todos los datos
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message);
            }

            return obtenerDatos;
        }
    }
}
