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
    public partial class frmIniciarSession : Form
    {

        string user = null, password = null;
        bool userValido = false, passwordValido = false;
        Usuario usuario = new Usuario();

        public frmIniciarSession()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            frm.Show();
            this.Hide();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            user = txtUser.Text;
            MySqlDataReader obtenerUsuario = usuario.VerificarUsuario(user);

            if (obtenerUsuario.HasRows && txtUser.Text != null)
            {
                while (obtenerUsuario.Read())
                {
                    pictureUser.Image = Image.FromFile(@"F:\6 Semestre\2.- Base de Datos II\3.- Tareas\Condominio Aplicacion\Condominio Aplicacion\Image\Bien.ico");
                    pictureUser.SizeMode = PictureBoxSizeMode.CenterImage;
                    userValido = true;
                }
                obtenerUsuario.Close();
            }
            else
            {
                userValido = false;
                pictureUser.Image = Image.FromFile(@"F:\6 Semestre\2.- Base de Datos II\3.- Tareas\Condominio Aplicacion\Condominio Aplicacion\Image\Error.ico");
                pictureUser.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            password = txtPassword.Text;
            MySqlDataReader obternerPassword = usuario.VerificarUsuario(user);

            if (obternerPassword.HasRows && txtPassword.Text != null)
            {
                while (obternerPassword.Read())
                {
                    string name = obternerPassword.GetString(5);
                    string pass = obternerPassword.GetString(6);

                    if (user == name && password == pass)
                    {
                        picturePassword.Image = Image.FromFile(@"F:\6 Semestre\2.- Base de Datos II\3.- Tareas\Condominio Aplicacion\Condominio Aplicacion\Image\Bien.ico");
                        picturePassword.SizeMode = PictureBoxSizeMode.CenterImage;
                        passwordValido = true;
                    }
                    else
                    {
                        passwordValido = false;
                        picturePassword.Image = Image.FromFile(@"F:\6 Semestre\2.- Base de Datos II\3.- Tareas\Condominio Aplicacion\Condominio Aplicacion\Image\Error.ico");
                        picturePassword.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }
                obternerPassword.Close();
            }
            else
            {
                picturePassword.Image = Image.FromFile(@"F:\6 Semestre\2.- Base de Datos II\3.- Tareas\Condominio Aplicacion\Condominio Aplicacion\Image\Error.ico");
                picturePassword.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (userValido == true && passwordValido == true)
            {
                MessageBox.Show("Usuario Valido");
                this.Hide();
                this.Hide();
                frmHomeValido frm = new frmHomeValido();
                frm.Show();

            }
            else
            {

                num = 0;
                usuario.ValidarUser(num);

                if (txtUser.Text == "" && txtPassword.Text == "")
                {
                    MessageBox.Show("Debe ser llenado los campos requerido");
                }
                else
                    MessageBox.Show("Usuario Invalido");
            }
        }
    }
}
