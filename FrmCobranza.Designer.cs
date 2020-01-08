namespace EnvioCartasCobranzas
{
    partial class frmCobranza
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLeer = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimerVcto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaUltimaAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSeleccionarTodos = new System.Windows.Forms.Button();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensajes = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbVencidos = new System.Windows.Forms.RadioButton();
            this.rbPorVencer = new System.Windows.Forms.RadioButton();
            this.dtpVencidosDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoEmail = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpVencidosHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGrupoCtaCte = new System.Windows.Forms.ComboBox();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGrupoCobranza = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUltimaAccion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametrosToolStripMenuItem,
            this.limpiarToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // parametrosToolStripMenuItem
            // 
            this.parametrosToolStripMenuItem.Name = "parametrosToolStripMenuItem";
            this.parametrosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.parametrosToolStripMenuItem.Text = "Parametros";
            this.parametrosToolStripMenuItem.Click += new System.EventHandler(this.ParametrosToolStripMenuItem_Click);
            // 
            // limpiarToolStripMenuItem
            // 
            this.limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            this.limpiarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.limpiarToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.limpiarToolStripMenuItem.Text = "Limpiar";
            this.limpiarToolStripMenuItem.Click += new System.EventHandler(this.LimpiarToolStripMenuItem_Click);
            // 
            // btnLeer
            // 
            this.btnLeer.Location = new System.Drawing.Point(639, 43);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(80, 23);
            this.btnLeer.TabIndex = 3;
            this.btnLeer.Text = "Leer";
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.BtnLeer_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToOrderColumns = true;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rut,
            this.Nombre,
            this.eMail,
            this.Cuenta,
            this.NombreCuenta,
            this.Saldo,
            this.PrimerVcto,
            this.UltimaAccion,
            this.FechaUltimaAccion,
            this.Seleccion});
            this.dgvDatos.Location = new System.Drawing.Point(12, 149);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(975, 316);
            this.dgvDatos.TabIndex = 4;
            // 
            // Rut
            // 
            this.Rut.HeaderText = "Rut";
            this.Rut.Name = "Rut";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // eMail
            // 
            this.eMail.HeaderText = "eMail";
            this.eMail.Name = "eMail";
            // 
            // Cuenta
            // 
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            // 
            // NombreCuenta
            // 
            this.NombreCuenta.HeaderText = "NombreCuenta";
            this.NombreCuenta.Name = "NombreCuenta";
            // 
            // Saldo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            // 
            // PrimerVcto
            // 
            this.PrimerVcto.HeaderText = "PrimerVcto";
            this.PrimerVcto.Name = "PrimerVcto";
            // 
            // UltimaAccion
            // 
            this.UltimaAccion.HeaderText = "UltimaAccion";
            this.UltimaAccion.Name = "UltimaAccion";
            // 
            // FechaUltimaAccion
            // 
            this.FechaUltimaAccion.HeaderText = "FechaUltimaAccion";
            this.FechaUltimaAccion.Name = "FechaUltimaAccion";
            // 
            // Seleccion
            // 
            this.Seleccion.HeaderText = "Seleccion";
            this.Seleccion.Name = "Seleccion";
            // 
            // btnSeleccionarTodos
            // 
            this.btnSeleccionarTodos.Location = new System.Drawing.Point(814, 43);
            this.btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            this.btnSeleccionarTodos.Size = new System.Drawing.Size(105, 23);
            this.btnSeleccionarTodos.TabIndex = 5;
            this.btnSeleccionarTodos.Text = "Seleccionar Todos";
            this.btnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodos.Click += new System.EventHandler(this.BtnSeleccionarTodos_Click);
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.Location = new System.Drawing.Point(725, 43);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(83, 23);
            this.btnEnviarEmail.TabIndex = 6;
            this.btnEnviarEmail.Text = "Envíar Email";
            this.btnEnviarEmail.UseVisualStyleBackColor = true;
            this.btnEnviarEmail.Click += new System.EventHandler(this.BtnEnviarEmail_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(420, 471);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMensajes});
            this.statusStrip1.Location = new System.Drawing.Point(0, 468);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(995, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslMensajes
            // 
            this.tsslMensajes.Name = "tsslMensajes";
            this.tsslMensajes.Size = new System.Drawing.Size(39, 17);
            this.tsslMensajes.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbVencidos);
            this.groupBox1.Controls.Add(this.rbPorVencer);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 76);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Docto";
            // 
            // rbVencidos
            // 
            this.rbVencidos.AutoSize = true;
            this.rbVencidos.Location = new System.Drawing.Point(6, 45);
            this.rbVencidos.Name = "rbVencidos";
            this.rbVencidos.Size = new System.Drawing.Size(69, 17);
            this.rbVencidos.TabIndex = 4;
            this.rbVencidos.TabStop = true;
            this.rbVencidos.Text = "Vencidos";
            this.rbVencidos.UseVisualStyleBackColor = true;
            this.rbVencidos.CheckedChanged += new System.EventHandler(this.RbVencidos_CheckedChanged_1);
            // 
            // rbPorVencer
            // 
            this.rbPorVencer.AutoSize = true;
            this.rbPorVencer.Location = new System.Drawing.Point(6, 22);
            this.rbPorVencer.Name = "rbPorVencer";
            this.rbPorVencer.Size = new System.Drawing.Size(78, 17);
            this.rbPorVencer.TabIndex = 3;
            this.rbPorVencer.TabStop = true;
            this.rbPorVencer.Text = "Por Vencer";
            this.rbPorVencer.UseVisualStyleBackColor = true;
            this.rbPorVencer.CheckedChanged += new System.EventHandler(this.RbPorVencer_CheckedChanged_1);
            // 
            // dtpVencidosDesde
            // 
            this.dtpVencidosDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencidosDesde.Location = new System.Drawing.Point(114, 57);
            this.dtpVencidosDesde.Name = "dtpVencidosDesde";
            this.dtpVencidosDesde.Size = new System.Drawing.Size(102, 20);
            this.dtpVencidosDesde.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vencidos Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tipo Email";
            // 
            // cbTipoEmail
            // 
            this.cbTipoEmail.FormattingEnabled = true;
            this.cbTipoEmail.Items.AddRange(new object[] {
            "eMail_1",
            "eMail_2",
            "eMail_3"});
            this.cbTipoEmail.Location = new System.Drawing.Point(341, 57);
            this.cbTipoEmail.Name = "cbTipoEmail";
            this.cbTipoEmail.Size = new System.Drawing.Size(160, 21);
            this.cbTipoEmail.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Vencidos Hasta";
            // 
            // dtpVencidosHasta
            // 
            this.dtpVencidosHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencidosHasta.Location = new System.Drawing.Point(226, 57);
            this.dtpVencidosHasta.Name = "dtpVencidosHasta";
            this.dtpVencidosHasta.Size = new System.Drawing.Size(102, 20);
            this.dtpVencidosHasta.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Grupo";
            // 
            // cbGrupoCtaCte
            // 
            this.cbGrupoCtaCte.FormattingEnabled = true;
            this.cbGrupoCtaCte.Location = new System.Drawing.Point(114, 103);
            this.cbGrupoCtaCte.Name = "cbGrupoCtaCte";
            this.cbGrupoCtaCte.Size = new System.Drawing.Size(160, 21);
            this.cbGrupoCtaCte.TabIndex = 17;
            // 
            // cbVendedor
            // 
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(284, 103);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(160, 21);
            this.cbVendedor.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cobrador";
            // 
            // cbGrupoCobranza
            // 
            this.cbGrupoCobranza.FormattingEnabled = true;
            this.cbGrupoCobranza.Location = new System.Drawing.Point(451, 103);
            this.cbGrupoCobranza.Name = "cbGrupoCobranza";
            this.cbGrupoCobranza.Size = new System.Drawing.Size(160, 21);
            this.cbGrupoCobranza.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Grupo de Cobranza";
            // 
            // cbUltimaAccion
            // 
            this.cbUltimaAccion.FormattingEnabled = true;
            this.cbUltimaAccion.Items.AddRange(new object[] {
            "eMail_1",
            "eMail_2",
            "eMail_3"});
            this.cbUltimaAccion.Location = new System.Drawing.Point(617, 103);
            this.cbUltimaAccion.Name = "cbUltimaAccion";
            this.cbUltimaAccion.Size = new System.Drawing.Size(160, 21);
            this.cbUltimaAccion.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(614, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Última Acción";
            // 
            // frmCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 490);
            this.Controls.Add(this.cbUltimaAccion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbGrupoCobranza);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbVendedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbGrupoCtaCte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpVencidosHasta);
            this.Controls.Add(this.cbTipoEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpVencidosDesde);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.btnEnviarEmail);
            this.Controls.Add(this.btnSeleccionarTodos);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnLeer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCobranza";
            this.Text = "Envío Email de Cobranza";
            this.Load += new System.EventHandler(this.FrmCobranza_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosToolStripMenuItem;
        private System.Windows.Forms.Button btnLeer;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnSeleccionarTodos;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMensajes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbVencidos;
        private System.Windows.Forms.RadioButton rbPorVencer;
        private System.Windows.Forms.DateTimePicker dtpVencidosDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpVencidosHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGrupoCtaCte;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGrupoCobranza;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem limpiarToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbUltimaAccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimerVcto;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaUltimaAccion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
    }
}

