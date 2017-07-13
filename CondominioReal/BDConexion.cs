using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CondominioReal
{
    class BDConexion
    {
        MySqlConnection conexion;
        String servidor = "localhost";
        String puerto = "3306";
        String usuario = "root";
        String password = "";
        String database = "condominio";

        public BDConexion() { }
        public MySqlConnection ObtenerConexion()
        {
            //Cadena de conexion
            String cn = String.Format("server={0}; port={1}; user id={2}; password={3}; " +
                                           "database={4}; pooling=false;" +
                                           "Allow Zero Datetime=False;Convert Zero Datetime=True",
                                            servidor, puerto, usuario, password, database);
            try
            {
                conexion = new MySqlConnection(cn);
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            conexion.Close();
            MessageBox.Show("La conexion termino");
        }
    }
}
