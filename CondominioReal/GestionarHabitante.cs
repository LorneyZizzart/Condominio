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
    class GestionarHabitante
    {
        //Instanciamos a la clase donde recibiremos la conexion a nuestra BD
        MySqlConnection conexionBD = new MySqlConnection();

        public DataTable MostrarHabitantes()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT h.id_Habitante as CODIGO, concat_ws(' ', h.primerNombre, h.segundoNombre) as NOMBRES, concat_ws(' ', h.apellidoPaterno, h.apellidoMaterno) as APELLIDOS, concat_ws(' ', h.CI, h.extencionCI) as 'NUMERO DE CARNET', t.tipoHabitante as 'TIPO DE HABITANTE', h.sexo as SEXO, h.calle as DIRECCION " +
                                       "FROM habitante h, tipo_habitante t " +
                                       "WHERE h.id_TipoHabitante = t.id_TipoHabitante " +
                                       "ORDER BY h.Id_Habitante";

            /*[CONSULTA]
             SELECT h.id_Habitante as CODIGO, concat_ws(' ', h.primerNombre, h.segundoNombre) as NOMBRES, concat_ws(' ', h.apellidoPaterno, h.apellidoMaterno) as APELLIDOS, h.CI as 'NUMERO DE CARNET', t.tipoHabitante as 'TIPO DE HABITANTE', h.sexo as SEXO, h.calle as DIRECCION
             FROM habitante h, tipo_habitante t
             WHERE h.id_TipoHabitante = t.id_TipoHabitante
             ORDER BY h.Id_Habitante;
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
                MessageBox.Show("Error en la Consulta" + ex.Message);
            }
            //retorno de todos los datos obtenidos
            return datos;
        }

        public MySqlDataReader BuscarHabitante(Habitante habitante)
        {
            //Instanciamos a la clase de conexion a la BD
            BDConexion cn = new BDConexion();
            //Hacemos el enalce a nuestra BD
            conexionBD = cn.ObtenerConexion();
            //Creamos una variable donde obtendremos todos los datos
            MySqlDataReader obtenerDatos = null;

            string buscarHabitante = "SELECT h.id_Habitante, concat_ws(' ', h.primerNombre, h.segundoNombre) as NOMBRES, concat_ws(' ', h.apellidoPaterno, h.apellidoMaterno) as APELLIDOS, h.ci, concat_ws(' ', h.zona, h.calle) as DIRECCION, h.sexo, t.tipoHabitante as TIPO " +
                                     "FROM habitante h, tipo_habitante t " +
                                     "WHERE h.id_TipoHabitante = t.id_TipoHabitante " +
                                     "AND h.ci = '" + habitante.Carnet + "'";

            /*[CONSULTA]
              SELECT h.id_Habitante, concat_ws(' ', h.primerNombre, h.segundoNombre) as NOMBRES, concat_ws(' ', h.apellidoPaterno, h.apellidoMaterno) as APELLIDOS, h.ci, concat_ws(' ', h.zona, h.calle) as DIRECCION, h.sexo, t.tipoHabitante as TIPO
             FROM habitante h, tipo_habitante t
             WHERE h.id_TipoHabitante = t.id_TipoHabitante 
             AND h.ci = '6041597';
             * 
             * 
             ALTER TABLE habitante ADD extencionCI char(10) not null
                                    AFTER ci;
             * 
             * 
             SELECT concat_ws(' ', h.primerNombre, h.segundoNombre, h.apellidoPaterno, h.apellidoMaterno) as NOMBRE, v.nombre as 'NOMBRE DEPARTAMENTO', hv.titular as TITULAR
             FROM habitante h, vivienda v, historial_vivienda hv
             WHERE h.id_Habitante = hv.id_Habitante
             AND v.id_Vivienda = hv.id_Vivienda;
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

        public static int AgregarHabitante(Habitante habitante)
        {
            int retorno = 0;
            //Intanciamos a la clase de conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO habitante( id_TipoHabitante, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI, extencionCI, sexo, calle, zona, rutaFotoPerfil)" +
                                               "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
                                               habitante.Id_TipoHabitante, habitante.PrimerNombre, habitante.SegundoNombre, habitante.ApellidoPaterno, habitante.ApellidoMaterno, habitante.Carnet, habitante.ExtencionCI, habitante.Sexo, habitante.Calle, habitante.Zona, habitante.Fotografia),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }


        public DataTable ReporteTitulares()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT h.id_Habitante as CODIGO, h.CI as CARNET, concat_ws(' ',h.primerNombre, h.apellidoPaterno) as NOMBRES, concat_ws (' ', h.apellidoPaterno, h.apellidoMaterno) as APELLIDOS, b.nombreBloque as BLOQUE, th.tipoHabitante as TIPO, hv.titular as TITULAR " +
                                       "FROM tipo_habitante th, habitante h, historial_vivienda hv, vivienda v, pisos p, bloques b " +
                                       "WHERE th.id_TipoHabitante = h.id_TipoHabitante " +
                                       "AND h.id_Habitante = hv.id_Habitante " +
                                       "AND hv.id_Vivienda = v.id_Vivienda " +
                                       "AND v.id_Pisos = p.id_Pisos " +
                                       "AND p.id_Bloque = b.id_Bloque " +
                                       "AND hv.titular=TRUE " +
                                       "ORDER BY h.id_Habitante";

            /*[CONSULTA]
                SELECT concat_ws(' ',h.primerNombre, h.apellidoPaterno) as 'Nombre Completo', b.nombreBloque as Bloque, th.tipoHabitante as Tipo, hv.titular as TITULAR
                FROM tipo_habitante th, habitante h, historial_vivienda hv, vivienda v, pisos p, bloques b
                WHERE th.id_TipoHabitante=h.id_TipoHabitante
                AND h.id_Habitante=hv.id_Habitante
                AND hv.id_Vivienda=v.id_Vivienda
                AND v.id_Pisos=p.id_Pisos
                AND p.id_Bloque=b.id_Bloque 
                AND hv.titular=TRUE
                ORDER BY h.id_Habitante
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
                MessageBox.Show("Error en la Consulta" + ex.Message);
            }
            //retorno de todos los datos obtenidos
            return datos;
        }

        public DataTable ReporteNoTitulares()
        {
            //Creamos una variable donde vamos a recibir todos los datos obtenidos de la consulta
            DataTable datos = new DataTable();
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Donde obtendremos los datos
            MySqlDataAdapter datosObtenidos = new MySqlDataAdapter();
            //Le damos la conexion a nuestra BD Condominio
            conexionBD = cn.ObtenerConexion();

            string consultaHabitante = "SELECT h.id_Habitante as CODIGO, h.CI as CARNET, concat_ws(' ',h.primerNombre, h.apellidoPaterno) as NOMBRES, concat_ws (' ', h.apellidoPaterno, h.apellidoMaterno) as APELLIDOS, b.nombreBloque as BLOQUE, th.tipoHabitante as TIPO, hv.titular as TITULAR " +
                                       "FROM tipo_habitante th, habitante h, historial_vivienda hv, vivienda v, pisos p, bloques b " +
                                       "WHERE th.id_TipoHabitante = h.id_TipoHabitante " +
                                       "AND h.id_Habitante = hv.id_Habitante " +
                                       "AND hv.id_Vivienda = v.id_Vivienda " +
                                       "AND v.id_Pisos = p.id_Pisos " +
                                       "AND p.id_Bloque = b.id_Bloque " +
                                       "AND hv.titular=FALSE " +
                                       "ORDER BY h.id_Habitante";

            /*[CONSULTA]
                SELECT concat_ws(' ',h.primerNombre, h.apellidoPaterno) as 'Nombre Completo', b.nombreBloque as Bloque, th.tipoHabitante as Tipo, hv.titular as TITULAR
                FROM tipo_habitante th, habitante h, historial_vivienda hv, vivienda v, pisos p, bloques b
                WHERE th.id_TipoHabitante=h.id_TipoHabitante
                AND h.id_Habitante=hv.id_Habitante
                AND hv.id_Vivienda=v.id_Vivienda
                AND v.id_Pisos=p.id_Pisos
                AND p.id_Bloque=b.id_Bloque 
                AND hv.titular=TRUE
                ORDER BY h.id_Habitante
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
                MessageBox.Show("Error en la Consulta" + ex.Message);
            }
            //retorno de todos los datos obtenidos
            return datos;
        }
    }
}
