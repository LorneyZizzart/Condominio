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
    public partial class frmRegistrarHabitante : Form
    {

        //Para recibir las validaciones de los datos requeridos
        bool pName = false, sName = false, pLastname = false, mLastname = false, ci = false, sexo = false, calle = false,
             zona = false, celular = false, telephono = false, parentesco = false;
        //Para recibir los rdos marcados y recibir la validacion de carnet
        int tipoHabitante, ci2 = 0;
        //Nos vreamos una variable para recibir la direccion de la imagen
        String ubicacion;
        //Variable para el ENUM del Sexo
        string sex;

        public frmRegistrarHabitante()
        {
            InitializeComponent();
        }

        private void txtPrimer_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite letras", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pName = false;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                pName = true;
            }
            return;
        }

        private void txtSegundo_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite letras", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sName = false;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                sName = true;
            }
            return;
        }

        private void txtApellido_Paterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite letras", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pLastname = false;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                pLastname = true;
            }
            return;
        }

        private void txtApellido_Materno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite letras", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mLastname = false;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                mLastname = true;
            }
            return;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite letras", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                telephono = false;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                telephono = true;
            }
            return;
        }

        private void txtCarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite números", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ci2 = 1;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                ci2 = 0;
            }
            return;
        }

        private void cboxCarnet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ci2 == 1 && cboxCarnet.Text != "")
            {
                ci = true;
            }
        }

        private void cboxSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSexo.SelectedItem.ToString() != "")
            {
                sexo = true;
                if (cboxSexo.SelectedItem.ToString() == "Masculino")
                {
                    sex = "M";
                }
                else
                    sex = "F";
            }
        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            if (txtCalle.Text != null)
            {
                calle = true;
            }
        }

        private void txtZona_TextChanged(object sender, EventArgs e)
        {
            if (txtZona.Text != null)
            {
                zona = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se perimite letras", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                celular = false;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                celular = true;
            }
            return;
        }

        private void rdoDuenio_CheckedChanged(object sender, EventArgs e)
        {
            tipoHabitante = 1;
            parentesco = true;
            return;
        }

        private void rdoFamiliarDuenio_CheckedChanged(object sender, EventArgs e)
        {
            tipoHabitante = 2;
            parentesco = true;
            return;
        }

        private void rdoInquilinoAnticretista_CheckedChanged(object sender, EventArgs e)
        {
            tipoHabitante = 3;
            parentesco = true;
            return;
        }

        private void rdoInquilinoAlquiler_CheckedChanged(object sender, EventArgs e)
        {
            tipoHabitante = 4;
            parentesco = true;
            return;
        }

        private void btnBuscarFotografia_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();

            abrir.Title = "Abrir";
            abrir.Filter = "Archivo JPG|*.jpg";

            //para campurar la direccion de la imagen

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                ubicacion = abrir.FileName;
                Bitmap Picture = new Bitmap(ubicacion);
                pictureFotografia.Image = Image.FromFile(abrir.FileName);
                MessageBox.Show(ubicacion);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistrarHabitante frm = new frmRegistrarHabitante();
            frm.Show();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Habitante habitante = new Habitante();

            if (txtPrimer_Nombre.Text != null && txtApellido_Paterno.Text != null && txtApellido_Materno.Text != null
                && txtCarnet.Text != null && cboxCarnet.Text != "" && cboxSexo.Text != "" && txtCalle.Text != null
                && txtZona.Text != null)
            {
                habitante.Id_TipoHabitante = tipoHabitante;
                habitante.PrimerNombre = txtPrimer_Nombre.Text;
                habitante.SegundoNombre = txtSegundo_Nombre.Text;
                habitante.ApellidoPaterno = txtApellido_Paterno.Text;
                habitante.ApellidoMaterno = txtApellido_Materno.Text;
                habitante.Carnet = txtCarnet.Text;
                habitante.ExtencionCI = cboxCarnet.SelectedItem.ToString();
                habitante.Sexo = sex;
                habitante.Calle = txtCalle.Text;
                habitante.Zona = txtZona.Text;
                habitante.Fotografia = ubicacion.ToString();

                int resultado = GestionarHabitante.AgregarHabitante(habitante);
                if (resultado > 0)
                {
                    MessageBox.Show("El Habitante se registro exitosamente!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se logro registrar el habitante", "Error en el registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos requeridos obligatoriamente [*]", "Error en el registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmGestionarHabitante frm = new frmGestionarHabitante();
            frm.Show();
            this.Hide();
        }

        private void txtPrimer_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCarnet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
