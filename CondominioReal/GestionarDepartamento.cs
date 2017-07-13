using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CondominioReal
{
    class GestionarDepartamento
    {
        //Instanciamos a la clase donde recibiremos la conexion a nuestra BD
        MySqlConnection conexionBD = new MySqlConnection();

        public MySqlDataReader BuscarDepartamento(Departamento departamento)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarDepartamento = "SELECT v.oferta, v.nombre, v.superficie, v.nroHabitaciones, v.nroBanho, v.precioVentaActual, v.precioCompraOriginal, v.descripcion, v.id_Vivienda, hv.titular " +
                                        "FROM vivienda v, historial_vivienda hv " +
                                        "WHERE v.id_Vivienda = hv.id_Vivienda " +
                                        "AND v.nombre = '" + departamento.Nombre + "'";

            /*[CONSULTA] TITULARES[B2][D19][D21]     NO TITULARES[A11][][]
                SELECT v.oferta, v.nombre, v.superficie, v.nroHabitaciones, v.nroBanho, v.precioVentaActual, v.precioCompraOriginal, v.descripcion, v.id_Vivienda, hv.titular
                FROM vivienda v, historial_vivienda hv
                WHERE v.id_Vivienda = hv.id_Vivienda
                AND v.nombre = 'D21'
             * 
             * [ADICIONAR UNA CLOMUNA DE IAMGENES]
             ALTER TABLE multimedia_vivienda ADD imagen MediumBlob not null
                                    AFTER tipoMultimedia;
             * 
             * [MODIFICAR UNA COLUMNA]
                ALTER TABLE 
            * */

            try
            {
                //Nos creamos una variable para la conexion y luego la consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion para nuestra conexion
                cmd.Connection = conexionBD;
                //le pasamos la consulta
                cmd.CommandText = buscarDepartamento;
                //Creamos una variable donde obtendremos todos los datos
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message);
            }

            return obtenerDatos;
        }

        public DataTable MostrarDepartamentos()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaDepartamento = "SELECT id_Vivienda as CODIGO, nombre as NOMBRE, superficie as SUPERFICIE, descripcion as DESCRIPCIóN " +
                                          "FROM vivienda ";

            /*[CONSULTA]
             SELECT id_Vivienda as CODIGO, nombre as NOMBRE, superficie as SUPERFICIE, descripcion as DESCRIPCIóN
             FROM vivienda;
             * */
            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaDepartamento;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message);
            }
            //retorno de todos los datos obtenidos
            return datos;
        }

        public DataTable MostrarDepartamentos(Departamento departamento)
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaDepartamento = "SELECT id_Vivienda as CODIGO, nombre as NOMBRE, superficie as SUPERFICIE, descripcion as DESCRIPCION " +
                                          "FROM vivienda " +
                                          "WHERE nombre LIKE '%" + departamento.Nombre + "%'";

            /*[CONSULTA]
             SELECT id_Vivienda as CODIGO, nombre as NOMBRE, superficie as SUPERFICIE, descripcion as DESCRIPCIóN
             FROM vivienda
             WHERE nombre LIKE '%E%';
             * */
            try
            {
                //creamos una variable para nuestra consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion a la BD
                cmd.Connection = conexionBD;
                //Pasamos la consulta a nuestra conexion de BD
                cmd.CommandText = consultaDepartamento;
                //Extraemos los datos obtenidos de la consulta
                datosObtenidos.SelectCommand = cmd;
                //Y lo pasamos a una tabla ficticia
                datosObtenidos.Fill(datos);
            }
            catch (Exception ex)
            {
                //Un mensaje de un posible error en nuestra consulta
                MessageBox.Show("Error en la Consulta" + ex.Message);
            }
            //retorno de todos los datos obtenidos
            return datos;
        }

        public static int GuardarImagen(Departamento departamento)
        {
            MemoryStream ms = new MemoryStream();
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();

            departamento.Fotografias.Save(ms, ImageFormat.Jpeg);
            byte[] imgArr = ms.ToArray();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO multimedia_vivienda( id_Vivienda, tipoMultimedia, imagen, rutaMultimedia)" +
                                               "VALUES ({0}, '{1}', {2}, '{3}')",
                                               departamento.ID_Vivienda, departamento.TipoMultimedia, departamento.Fotografias, departamento.RutaMultimedia),
                                               cn.ObtenerConexion());

            cmd.Parameters["{2}"].Value = ms.GetBuffer();
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        public static int AsiganrVivienda(Departamento departamento, Habitante habitante)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO historial_vivienda( id_Vivienda, id_Habitante, fechaInicioVivencia, fechaFinVivencia, titular)" +
                                               "VALUES ({0}, {1}, '{2}', '{3}', {4})",
                                               departamento.ID_Vivienda, habitante.Id_Habitante, habitante.FechaInicio, habitante.FechaFinal, habitante.Titular),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        //Para Obtener los Departamentos del Bloque seleccionado [Asiganar Servicios]
        public DataTable ObtenerDepartamentos(string Bloque)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            DataTable datoObtenido = new DataTable();


            string buscarDepartamento = "SELECT v.nombre " +
                                        "FROM vivienda v,  pisos p, bloques b " +
                                        "WHERE v.id_Pisos = p.id_Pisos " +
                                        "AND p.id_Bloque = b.id_Bloque " +
                                        "AND b.nombreBloque = '" + Bloque + "'";

            /*[CONSULTA]
                SELECT v.nombre 
                FROM vivienda v,  pisos p, bloques b
                WHERE v.id_Pisos = p.id_Pisos
                AND p.id_Bloque = b.id_Bloque
                AND b.nombreBloque = 'Las Torrez';
             * 
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
        //Para obtener el ID_Departamento [Asiganar Servicio]
        public MySqlDataReader Obtener_IdDepartamento(Departamento departamento)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarDepartamento = "SELECT id_Vivienda " +
                                        "FROM vivienda " +
                                        "WHERE nombre = '" + departamento.Nombre + "'";

            /*[CONSULTA] 
                SELECT id_Vivienda 
                FROM vivienda
                WHERE nombre = 'C12';
             * 
             * */

            try
            {
                //Nos creamos una variable para la conexion y luego la consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion para nuestra conexion
                cmd.Connection = conexionBD;
                //le pasamos la consulta
                cmd.CommandText = buscarDepartamento;
                //Creamos una variable donde obtendremos todos los datos
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message);
            }

            return obtenerDatos;
        }

        //Para obtener el ID_Servicio y para luego comparar si el servicio no se repite en en departamento [Asiganar Servicio]
        public MySqlDataReader BuscarServicio_en_Departamento(Departamento departamento, Servicios servicio)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarDepartamento = "SELECT es.id_EmpresaServicio " +
                                        "FROM vivienda v, servicios s, empresa_servicio es " +
                                        "WHERE v.id_Vivienda = s.id_Vivienda " +
                                        "AND s.id_EmpresaServicio = es.id_EmpresaServicio " +
                                        "AND v.nombre = '" + departamento.Nombre + "'" +
                                        "AND es.nombre_EmpresaServicio = '" + servicio.Empresa + "'" +
                                        "AND es.servicio = '" + servicio.Servicio + "'";

            /*[CONSULTA]
                SELECT es.id_EmpresaServicio
                FROM vivienda v, servicios s, empresa_servicio es
                WHERE v.id_Vivienda = s.id_Vivienda
                AND s.id_EmpresaServicio = es.id_EmpresaServicio
                AND v.nombre = 'A1'
                AND es.nombre_EmpresaServicio = 'Entel'
                AND es.servicio = 'Telefonia';
             * 
                SELECT COUNT(id_Habitante)
                FROM historial_vivienda
                WHERE id_Vivienda = 21;
             * */

            try
            {
                //Nos creamos una variable para la conexion y luego la consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion para nuestra conexion
                cmd.Connection = conexionBD;
                //le pasamos la consulta
                cmd.CommandText = buscarDepartamento;
                //Creamos una variable donde obtendremos todos los datos
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message, "ERROR");
            }

            return obtenerDatos;
        }

        //Para obtener el ID_Servicio y para luego comparar si el servicio no se repite en en departamento [Asiganar Servicio]
        public MySqlDataReader ContidadHabitante(int IdDepartamento)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarDepartamento = "SELECT COUNT(id_Habitante) " +
                                        "FROM historial_vivienda " +
                                        "WHERE id_Vivienda = " + IdDepartamento;

            /*[CONSULTA]
                SELECT COUNT(id_Habitante)
                FROM historial_vivienda
                WHERE id_Vivienda = 1;
             * */

            try
            {
                //Nos creamos una variable para la conexion y luego la consulta
                MySqlCommand cmd = new MySqlCommand();
                //Abrimos la conexion para nuestra conexion
                cmd.Connection = conexionBD;
                //le pasamos la consulta
                cmd.CommandText = buscarDepartamento;
                //Creamos una variable donde obtendremos todos los datos
                obtenerDatos = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message, "ERROR");
            }

            return obtenerDatos;
        }

        //Para Obtener todos Los Bloques [Asiganar Servicios]
        public DataTable ObtenerBloques()
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            DataTable datoObtenido = new DataTable();


            string buscarDepartamento = "SELECT nombreBloque " +
                                        "FROM bloques";

            /*[CONSULTA]
                SELECT nombreBloque 
                FROM bloques
             * 
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
        //PARA TENER UNA LISTA DE LOS DEPARTAMENTOS QUE SE ENCUENTRAN DIFERENTE A NO HABITADO [frmHomeValido]
        public MySqlDataReader DeparatamentosDiferentes_a_NoHabitado()
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarHabitante = "SELECT v.id_Vivienda, v.nombre " +
                                     "FROM vivienda v, estado_vivienda ev " +
                                     "WHERE v.id_Estado = ev.id_Estado " +
                                     "AND NOT (ev.tipoEstado = 'No Habitado')";

            /*[CONSULTA]
             SELECT v.id_Vivienda, v.nombre  as DEPARTAMENTO, ev.tipoEstado AS ESTADO
             FROM vivienda v, estado_vivienda ev
             WHERE v.id_Estado = ev.id_Estado
             AND NOT (ev.tipoEstado = 'No Habitado')
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
