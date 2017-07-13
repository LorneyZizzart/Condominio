using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CondominioReal
{
    class Usuario
    {
        MySqlConnection conexionBD = new MySqlConnection();

        public MySqlDataReader VerificarUsuario(String usuario)
        {
            BDConexion cn = new BDConexion();
            conexionBD = cn.ObtenerConexion();
            MySqlDataReader recuperandoUsuarios = null;

            string consultaUsuario = " SELECT *" +
                                     " FROM usuarios u, roles r" +
                                     " WHERE u.usuario = '" + usuario + "'" +
                                     " AND u.id_Rol = r.id_Rol" +
                                     " AND r.tipoRol = 'Administrador'";

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexionBD;
                cmd.CommandText = consultaUsuario;
                recuperandoUsuarios = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message);
            }
            return recuperandoUsuarios;
        }

        public int ValidarUser(int num)
        {
            if (num > 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
