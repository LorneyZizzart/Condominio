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
    class GestionarServicios
    {
        //Instanciamos a la clase donde recibiremos la conexion a nuestra BD
        MySqlConnection conexionBD = new MySqlConnection();

        //Agregar nuevo Servivio [Registrar Servicio]
        public static int AgregarServicio(Servicios servicio)
        {
            int retorno = 0;
            //Intanciamos a la clase de conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO empresa_servicio( nombre_EmpresaServicio, servicio, precio, obligatorio, telefono, descripcion)" +
                                               "VALUES ('{0}', '{1}', '{2}', {3}, {4}, '{5}')",
                                               servicio.Empresa, servicio.Servicio, servicio.Precio, servicio.Obligatorio, servicio.Telefono, servicio.Descripcion),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        //Para asignar servicios a los departamentos
        public static int AgregarServicio_Depa(int Id_EmpresaServicio, int Id_Vivienda, string Observaciones)
        {
            int retorno = 0;
            //Intanciamos a la clase de conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO servicios( id_EmpresaServicio, id_Vivienda, observaciones)" +
                                               "VALUES ({0}, {1}, '{2}')",
                                               Id_EmpresaServicio, Id_Vivienda, Observaciones),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        //Buscar un servicio en especifico [frmSERVICIOS]
        public DataTable BuscarXServicio( string NombreServicio)
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos de la consulta
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaServicio = "SELECT id_EmpresaServicio as CODIGO, nombre_EmpresaServicio as 'NOMBRE DE LA EMPRESA', servicio as SERVICIO, precio as PRECIO, obligatorio as OBLIGATORIO, telefono as TELEFONO, descripcion as DESCRIPCION " +
                                      "FROM empresa_servicio " +
                                      "WHERE servicio = '" + NombreServicio + "'";

            /*[CONSULTA]
                SELECT id_EmpresaServicio as CODIGO, nombre_EmpresaServicio as 'NOMBRE DE LA EMPRESA', servicio as SERVICIO, precio as PRECIO, obligatorio as OBLIGATORIO, telefono as TELEFONO
                FROM empresa_servicio;
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaServicio;
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

        //Mostrar todos los Servicios Registrados [Registrar Servicio]
        public DataTable MostrarServicios()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos de la consulta
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaServicio = "SELECT id_EmpresaServicio as CODIGO, nombre_EmpresaServicio as 'NOMBRE DE LA EMPRESA', servicio as SERVICIO, precio as PRECIO, obligatorio as OBLIGATORIO, telefono as TELEFONO, descripcion as DESCRIPCION " +
                                      "FROM empresa_servicio";

            /*[CONSULTA]
                SELECT id_EmpresaServicio as CODIGO, nombre_EmpresaServicio as 'NOMBRE DE LA EMPRESA', servicio as SERVICIO, precio as PRECIO, obligatorio as OBLIGATORIO, telefono as TELEFONO
                FROM empresa_servicio;
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaServicio;
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

        //Buscar nombre del Servicio [Registrar Servicio]
        public MySqlDataReader BuscarServicio(Servicios servicio)
        {
            //Instanciamos a la clase de conexion a nuestra BD Condominio
            BDConexion cn = new BDConexion();
            //Abrimos la conexion a  nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos los datos de nuestra consulta
            MySqlDataReader obtenerDatos = null;

            string buscarCliente = "SELECT nombre_EmpresaServicio, servicio " +
                                   "FROM empresa_servicio " +
                                   "WHERE  servicio = '" + servicio.Servicio + "'";
            /*[CONSULTA]
            SELECT nombre_EmpresaServicio, servicio
            FROM empresa_servicio
            WHERE servicio = 'Agua';
             * */

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexionBD;
                cmd.CommandText = buscarCliente;
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message);
            }
            return obtenerDatos;
        }

        //Para obtener los servicios registrados para [comBoxServicio de AsignarServicios]
        public DataTable ObtenerServicios()
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Donde recuperaremos los datos obtenidos de la consulta
            DataTable datoObtenido = new DataTable();


            string buscarDepartamento = "SELECT servicio " +
                                        "FROM empresa_servicio " +
                                        "WHERE obligatorio =  FALSE";

            /*[CONSULTA]
                SELECT nombre_EmpresaServicio, servicio
                FROM empresa_servicio
                WHERE obligatorio =  FALSE;
            * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = buscarDepartamento;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datoObtenido);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message, "ERROR");
            }

            return datoObtenido;
        }
        //Para obtener la nombre_EmpresaServicio registrados para [comBox_nombre_EmpresaServicio de AsignarServicios]
        public DataTable ObtenerEmpresaServicio(Servicios servicio)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Donde recuperaremos los datos obtenidos de la consulta
            DataTable datoObtenido = new DataTable();


            string buscarDepartamento = "SELECT nombre_EmpresaServicio " +
                                        "FROM empresa_servicio " +
                                        "WHERE servicio = '" + servicio.Servicio + "'";

            /*[CONSULTA]
                SELECT nombre_EmpresaServicio, servicio
                FROM empresa_servicio;
            * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = buscarDepartamento;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datoObtenido);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message, "ERROR");
            }

            return datoObtenido;
        }

        //Para obterner el precio del Servicio  mas el ID [Asignar Servicio]
        public MySqlDataReader PrecioServicio(string servicio, string empresa)
        {
            //Instanciamos a la clase de conexion a nuestra BD Condominio
            BDConexion cn = new BDConexion();
            //Abrimos la conexion a  nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos los datos de nuestra consulta
            MySqlDataReader obtenerDatos = null;

            string buscarCliente = "SELECT id_EmpresaServicio, precio, obligatorio " +
                                   "FROM empresa_servicio " +
                                   "WHERE servicio = '" + servicio + "' " +
                                   "AND nombre_EmpresaServicio = '" + empresa + "'";
            /*[CONSULTA]
            SELECT id_EmpresaServicio, precio, obligatorio
            FROM empresa_servicio
            WHERE servicio = 'Telefonia'
            AND nombre_EmpresaServicio = 'Tigo';
            **/

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexionBD;
                cmd.CommandText = buscarCliente;
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la consulta" + ex.Message, "ERROR");
            }
            return obtenerDatos;
        }

        //Mostrar todos los servicios que corresponde a un departamento selecionado [AsiganarServicio]
        public DataTable BuscarServicios_Depa(Departamento departamento)
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos de la consulta
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaServicio = "SELECT es.servicio as SERVICIO, es.precio as PRECIO, IF(es.obligatorio = TRUE, 'SI', 'NO') as OBLIGATORIO " +
                                      "FROM empresa_servicio es, servicios s, vivienda v " +
                                      "WHERE s.id_EmpresaServicio = es.id_EmpresaServicio " +
                                      "AND s.id_Vivienda = v.id_Vivienda " +
                                      "AND v.nombre = '" + departamento.Nombre + "'";

            /*[CONSULTA]
                SELECT (@rownum:=@rownum+1) as NUMERO, es.servicio as SERVICIO, es.precio as PRECIO, IF(es.obligatorio = TRUE, 'SI', 'NO') as OBLIGATORIO
                FROM (SELECT @rownum:=0) r, empresa_servicio es, servicios s, vivienda v
                WHERE s.id_EmpresaServicio = es.id_EmpresaServicio
                AND s.id_Vivienda = v.id_Vivienda
                AND v.nombre = 'A1';
             * 
                SELECT IF(1 = 1, '', '') AS SERVICIO, IF(2 = 2, '', '') AS PRECIO, IF(3 = 3, '', '') AS OBLIGATORIO 
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaServicio;
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
        //Mostrar una tabla ficticia sin valores [AsiganarServicio]
        public DataTable Departamento_SinServicios()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos de la consulta
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consulta = "SELECT IF(1 = 1, '', '') AS SERVICIO, IF(2 = 2, '', '') AS PRECIO, IF(3 = 3, '', '') AS OBLIGATORIO";

            /*[CONSULTA]
                SELECT IF(1 = 1, '', '') AS SERVICIO, IF(2 = 2, '', '') AS PRECIO, IF(3 = 3, '', '') AS OBLIGATORIO 
             * */

            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consulta;
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
        //Para obtener el total que tiene que pagar cada departamento por las expensas y por la agua [ASIGNAR SERVICIOS]
        public MySqlDataReader TotalPagoExpensas(Departamento departamento)
        {
            //Instanciamos a la clase de conexion a nuestra BD Condominio
            BDConexion cn = new BDConexion();
            //Abrimos la conexion a  nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos los datos de nuestra consulta
            MySqlDataReader obtenerDatos = null;

            string buscarCliente = "SELECT SUM(es.precio) as PRECIO, ( " +
                                                                       "SELECT SUM(es.precio) " +
                                                                       "FROM empresa_servicio es, servicios s, vivienda v " +
                                                                       "WHERE s.id_EmpresaServicio = es.id_EmpresaServicio " +
                                                                       "AND s.id_Vivienda = v.id_Vivienda " +
                                                                       "AND v.nombre = '" + departamento.Nombre + "' " +
                                                                       "AND es.servicio = 'Agua' " +
                                                                       ") as AGUA " +
                                   "FROM empresa_servicio es, servicios s, vivienda v " +
                                   "WHERE s.id_EmpresaServicio = es.id_EmpresaServicio " +
                                   "AND s.id_Vivienda = v.id_Vivienda " +
                                   "AND v.nombre = '" + departamento.Nombre + "' ";
            /*[CONSULTA]
                SELECT SUM(es.precio) as PRECIO, ( 
                                                    SELECT SUM(es.precio) 
                                                    FROM empresa_servicio es, servicios s, vivienda v
                                                    WHERE es.id_EmpresaServicio = s.id_EmpresaServicio
                                                    AND s.id_Vivienda = v.id_Vivienda
                                                    AND es.servicio = 'Agua'
                                                    AND v.nombre = 'A1' 
                                                 ) as AGUA
                FROM empresa_servicio es, servicios s, vivienda v, estado_vivienda ev
                WHERE ev.id_Estado = v.id_Estado
                AND s.id_EmpresaServicio = es.id_EmpresaServicio
                AND s.id_Vivienda = v.id_Vivienda
                AND NOT (ev.tipoEstado = 'No Habitado') 
                AND v.nombre = 'A1';
            **/

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexionBD;
                cmd.CommandText = buscarCliente;
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la consulta" + ex.Message, "ERROR");
            }
            return obtenerDatos;
        }
        //PARA VER EL ESTADO DEL DEPARTAMENTO [frmAsignarServicios]
        public MySqlDataReader EstadoDepartamento(Departamento departamento)
        {
            //Instanciamos a la clase de conexion a nuestra BD Condominio
            BDConexion cn = new BDConexion();
            //Abrimos la conexion a  nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos los datos de nuestra consulta
            MySqlDataReader obtenerDatos = null;

            string buscarCliente = "SELECT ev.tipoEstado as ESTADO " +
                                   "FROM vivienda v, estado_vivienda ev " +
                                   "WHERE v.id_Estado = ev.id_Estado " +
                                   "AND v.nombre = '" + departamento.Nombre + "' ";
            /*[CONSULTA]
             SELECT ev.tipoEstado as ESTADO
             FROM vivienda v, estado_vivienda ev
             WHERE v.id_Estado =  ev.id_Estado 
             AND v.nombre = 'A1';
            **/

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexionBD;
                cmd.CommandText = buscarCliente;
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la consulta" + ex.Message, "ERROR");
            }
            return obtenerDatos;
        }
    }
}