namespace CondominioReal
{
    partial class frmGestionarHabitante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionarHabitante));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscarHabitante = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAsignarDepartamento = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoNoTitulares = new System.Windows.Forms.RadioButton();
            this.rdoTitulares = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tblHabitantes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblHabitantes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscarHabitante);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 86);
            this.panel1.TabIndex = 67;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(-22, -10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 104);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 68;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(91, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(611, 46);
            this.label6.TabIndex = 51;
            this.label6.Text = "REGISTRO DE HABITANTES";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Location = new System.Drawing.Point(945, 41);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 39);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscarHabitante
            // 
            this.txtBuscarHabitante.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarHabitante.Location = new System.Drawing.Point(705, 47);
            this.txtBuscarHabitante.Name = "txtBuscarHabitante";
            this.txtBuscarHabitante.Size = new System.Drawing.Size(236, 27);
            this.txtBuscarHabitante.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 23);
            this.label5.TabIndex = 85;
            this.label5.Text = "Salir";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.LightGray;
            this.btnVolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVolver.BackgroundImage")));
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Location = new System.Drawing.Point(-93, 421);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(273, 86);
            this.btnVolver.TabIndex = 86;
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(86, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 46);
            this.label7.TabIndex = 83;
            this.label7.Text = "Asignar\r\nDepartamento";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnAsignarDepartamento
            // 
            this.btnAsignarDepartamento.BackColor = System.Drawing.Color.LightGray;
            this.btnAsignarDepartamento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAsignarDepartamento.BackgroundImage")));
            this.btnAsignarDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAsignarDepartamento.Location = new System.Drawing.Point(-93, 338);
            this.btnAsignarDepartamento.Name = "btnAsignarDepartamento";
            this.btnAsignarDepartamento.Size = new System.Drawing.Size(273, 86);
            this.btnAsignarDepartamento.TabIndex = 84;
            this.btnAsignarDepartamento.UseVisualStyleBackColor = false;
            this.btnAsignarDepartamento.Click += new System.EventHandler(this.btnAsignarDepartamento_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 81;
            this.label3.Text = "Eliminar";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnDarDeBaja
            // 
            this.btnDarDeBaja.BackColor = System.Drawing.Color.LightGray;
            this.btnDarDeBaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDarDeBaja.BackgroundImage")));
            this.btnDarDeBaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDarDeBaja.Location = new System.Drawing.Point(-93, 258);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(273, 86);
            this.btnDarDeBaja.TabIndex = 82;
            this.btnDarDeBaja.UseVisualStyleBackColor = false;
            this.btnDarDeBaja.Click += new System.EventHandler(this.btnDarDeBaja_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 79;
            this.label2.Text = "Modificar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.LightGray;
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.Location = new System.Drawing.Point(-93, 177);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(273, 86);
            this.btnActualizar.TabIndex = 80;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 77;
            this.label4.Text = "Registrar";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.LightGray;
            this.btnRegistrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrar.BackgroundImage")));
            this.btnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegistrar.Location = new System.Drawing.Point(-93, 92);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(273, 86);
            this.btnRegistrar.TabIndex = 78;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-8, 304);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 216);
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoNoTitulares);
            this.panel2.Controls.Add(this.rdoTitulares);
            this.panel2.Location = new System.Drawing.Point(730, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 35);
            this.panel2.TabIndex = 89;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // rdoNoTitulares
            // 
            this.rdoNoTitulares.AutoSize = true;
            this.rdoNoTitulares.Location = new System.Drawing.Point(157, 9);
            this.rdoNoTitulares.Name = "rdoNoTitulares";
            this.rdoNoTitulares.Size = new System.Drawing.Size(82, 17);
            this.rdoNoTitulares.TabIndex = 1;
            this.rdoNoTitulares.TabStop = true;
            this.rdoNoTitulares.Text = "No Titulares";
            this.rdoNoTitulares.UseVisualStyleBackColor = true;
            this.rdoNoTitulares.CheckedChanged += new System.EventHandler(this.rdoNoTitulares_CheckedChanged);
            // 
            // rdoTitulares
            // 
            this.rdoTitulares.AutoSize = true;
            this.rdoTitulares.Location = new System.Drawing.Point(50, 9);
            this.rdoTitulares.Name = "rdoTitulares";
            this.rdoTitulares.Size = new System.Drawing.Size(65, 17);
            this.rdoTitulares.TabIndex = 0;
            this.rdoTitulares.TabStop = true;
            this.rdoTitulares.Text = "Titulares";
            this.rdoTitulares.UseVisualStyleBackColor = true;
            this.rdoTitulares.CheckedChanged += new System.EventHandler(this.rdoTitulares_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 19);
            this.label1.TabIndex = 88;
            this.label1.Text = "Seleccionar un habitante para cualquiera acción";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tblHabitantes
            // 
            this.tblHabitantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblHabitantes.GridColor = System.Drawing.Color.SeaShell;
            this.tblHabitantes.Location = new System.Drawing.Point(302, 132);
            this.tblHabitantes.Name = "tblHabitantes";
            this.tblHabitantes.Size = new System.Drawing.Size(684, 261);
            this.tblHabitantes.TabIndex = 87;
            this.tblHabitantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblHabitantes_CellContentClick);
            // 
            // frmGestionarHabitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(993, 512);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblHabitantes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAsignarDepartamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDarDeBaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmGestionarHabitante";
            this.Text = "frmGestionarHabitante";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblHabitantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscarHabitante;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAsignarDepartamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDarDeBaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoNoTitulares;
        private System.Windows.Forms.RadioButton rdoTitulares;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblHabitantes;
    }
}