using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioReal
{
    class GestionarBloque_Pisos
    {
        public static int RegistrarBloque(Bloque_Piso bloque)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO bloques( id_Urbanizacion, nombreBloque, nroPisos, direccion)" +
                                               "VALUES ({0}, '{1}', {2}, '{3}')",
                                               bloque.Id_Urbanizacion, bloque.NombreBloque, bloque.Nro_Pisos, bloque.Direccion),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        public static int RegistrarPiso(Bloque_Piso pisos)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO pisos( id_Bloque, nombreNumeroPiso, nroViviendas)" +
                                               "VALUES ({0}, '{1}', {2})",
                                               pisos.Id_Bloque, pisos.Nombre_NroPiso, pisos.Nros_Departamentos),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        //Para registrar el Historial Bloque
        public static int HistorialBloque(Departamento departamento, Habitante habitante, DateTime fechaInicioVivencia, DateTime fechaFinVivencia, bool titular)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO historial_representantes( id_Vivienda, id_Habitante, fechaInicioVivencia, fechaFinVivencia, titular)" +
                                               "VALUES ({0}, {1}, '{2}', '{3}', {4})",
                                               habitante.Id_Habitante, habitante.Id_Habitante, fechaInicioVivencia, fechaFinVivencia, titular),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        //Para registrar el Historial Departamento
        public static int HistorialBloque(Habitante habitante, Bloque_Piso bloque, DateTime fechaInicio, DateTime fechaConclusion)
        {
            int retorno = 0;
            //Instanciamos en una variable la conexion a nuestra BD
            BDConexion cn = new BDConexion();
            //Elaboramos el comando en insercion
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO historial_representantes( id_Habitante, id_Bloque, fechaInicio, fechaConclusion)" +
                                               "VALUES ({0}, {1}, '{2}', '{3}')",
                                               habitante.Id_Habitante, bloque.Id_Bloque, fechaInicio, fechaConclusion),
                                               cn.ObtenerConexion());
            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
    }
}
