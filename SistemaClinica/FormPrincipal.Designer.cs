namespace SistemaClinica
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuRegistrar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNuevoMedico = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNuevoPaciente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabCitas = new System.Windows.Forms.TabPage();
            this.grpCitaSeleccionada = new System.Windows.Forms.GroupBox();
            this.txtHistoria = new System.Windows.Forms.TextBox();
            this.lblHistoria = new System.Windows.Forms.Label();
            this.btnCancelarCita = new System.Windows.Forms.Button();
            this.btnAtender = new System.Windows.Forms.Button();
            this.txtResumen = new System.Windows.Forms.TextBox();
            this.lblResumen = new System.Windows.Forms.Label();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.colCitaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCitaFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCitaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCitaPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCitaMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCitaMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCitaEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpNuevaCita = new System.Windows.Forms.GroupBox();
            this.btnNuevoMedicoRapido = new System.Windows.Forms.Button();
            this.btnNuevoPacienteRapido = new System.Windows.Forms.Button();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.lblCitaMedico = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblCitaPaciente = new System.Windows.Forms.Label();
            this.tabPacientes = new System.Windows.Forms.TabPage();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.colPacienteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPacienteNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPacienteTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarPaciente = new System.Windows.Forms.Button();
            this.btnEditarPaciente = new System.Windows.Forms.Button();
            this.btnAgregarPaciente = new System.Windows.Forms.Button();
            this.tabMedicos = new System.Windows.Forms.TabPage();
            this.dgvMedicos = new System.Windows.Forms.DataGridView();
            this.colMedicoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicoEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarMedico = new System.Windows.Forms.Button();
            this.btnEditarMedico = new System.Windows.Forms.Button();
            this.btnAgregarMedico = new System.Windows.Forms.Button();
            this.menuPrincipal.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabCitas.SuspendLayout();
            this.grpCitaSeleccionada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.grpNuevaCita.SuspendLayout();
            this.tabPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.tabMedicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).BeginInit();
            this.SuspendLayout();
            //
            // menuPrincipal
            //
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegistrar});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(944, 24);
            this.menuPrincipal.TabIndex = 0;
            //
            // mnuRegistrar
            //
            this.mnuRegistrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevoMedico,
            this.mnuNuevoPaciente,
            this.mnuSeparador,
            this.mnuSalir});
            this.mnuRegistrar.Name = "mnuRegistrar";
            this.mnuRegistrar.Size = new System.Drawing.Size(67, 20);
            this.mnuRegistrar.Text = "&Registrar";
            //
            // mnuNuevoMedico
            //
            this.mnuNuevoMedico.Name = "mnuNuevoMedico";
            this.mnuNuevoMedico.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuNuevoMedico.Size = new System.Drawing.Size(220, 22);
            this.mnuNuevoMedico.Text = "Nuevo &médico...";
            this.mnuNuevoMedico.Click += new System.EventHandler(this.btnAgregarMedico_Click);
            //
            // mnuNuevoPaciente
            //
            this.mnuNuevoPaciente.Name = "mnuNuevoPaciente";
            this.mnuNuevoPaciente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuNuevoPaciente.Size = new System.Drawing.Size(220, 22);
            this.mnuNuevoPaciente.Text = "Nuevo &paciente...";
            this.mnuNuevoPaciente.Click += new System.EventHandler(this.btnAgregarPaciente_Click);
            //
            // mnuSeparador
            //
            this.mnuSeparador.Name = "mnuSeparador";
            this.mnuSeparador.Size = new System.Drawing.Size(217, 6);
            //
            // mnuSalir
            //
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(220, 22);
            this.mnuSalir.Text = "&Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            //
            // tabPrincipal
            //
            this.tabPrincipal.Controls.Add(this.tabCitas);
            this.tabPrincipal.Controls.Add(this.tabPacientes);
            this.tabPrincipal.Controls.Add(this.tabMedicos);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 24);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(944, 621);
            this.tabPrincipal.TabIndex = 1;
            //
            // tabCitas
            //
            this.tabCitas.Controls.Add(this.grpCitaSeleccionada);
            this.tabCitas.Controls.Add(this.dgvCitas);
            this.tabCitas.Controls.Add(this.grpNuevaCita);
            this.tabCitas.Location = new System.Drawing.Point(4, 22);
            this.tabCitas.Name = "tabCitas";
            this.tabCitas.Padding = new System.Windows.Forms.Padding(3);
            this.tabCitas.Size = new System.Drawing.Size(936, 595);
            this.tabCitas.TabIndex = 0;
            this.tabCitas.Text = "Citas";
            this.tabCitas.UseVisualStyleBackColor = true;
            //
            // grpCitaSeleccionada
            //
            this.grpCitaSeleccionada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCitaSeleccionada.Controls.Add(this.txtHistoria);
            this.grpCitaSeleccionada.Controls.Add(this.lblHistoria);
            this.grpCitaSeleccionada.Controls.Add(this.btnCancelarCita);
            this.grpCitaSeleccionada.Controls.Add(this.btnAtender);
            this.grpCitaSeleccionada.Controls.Add(this.txtResumen);
            this.grpCitaSeleccionada.Controls.Add(this.lblResumen);
            this.grpCitaSeleccionada.Location = new System.Drawing.Point(12, 412);
            this.grpCitaSeleccionada.Name = "grpCitaSeleccionada";
            this.grpCitaSeleccionada.Size = new System.Drawing.Size(910, 170);
            this.grpCitaSeleccionada.TabIndex = 2;
            this.grpCitaSeleccionada.TabStop = false;
            this.grpCitaSeleccionada.Text = "Cita seleccionada";
            //
            // txtHistoria
            //
            this.txtHistoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistoria.Location = new System.Drawing.Point(465, 40);
            this.txtHistoria.Multiline = true;
            this.txtHistoria.Name = "txtHistoria";
            this.txtHistoria.ReadOnly = true;
            this.txtHistoria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistoria.Size = new System.Drawing.Size(430, 116);
            this.txtHistoria.TabIndex = 5;
            this.txtHistoria.TabStop = false;
            //
            // lblHistoria
            //
            this.lblHistoria.AutoSize = true;
            this.lblHistoria.Location = new System.Drawing.Point(462, 22);
            this.lblHistoria.Name = "lblHistoria";
            this.lblHistoria.Size = new System.Drawing.Size(84, 13);
            this.lblHistoria.TabIndex = 4;
            this.lblHistoria.Text = "Historia clínica:";
            //
            // btnCancelarCita
            //
            this.btnCancelarCita.Location = new System.Drawing.Point(150, 128);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(130, 28);
            this.btnCancelarCita.TabIndex = 3;
            this.btnCancelarCita.Text = "Cancelar cita";
            this.btnCancelarCita.UseVisualStyleBackColor = true;
            this.btnCancelarCita.Click += new System.EventHandler(this.btnCancelarCita_Click);
            //
            // btnAtender
            //
            this.btnAtender.Location = new System.Drawing.Point(12, 128);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(130, 28);
            this.btnAtender.TabIndex = 2;
            this.btnAtender.Text = "Atender cita";
            this.btnAtender.UseVisualStyleBackColor = true;
            this.btnAtender.Click += new System.EventHandler(this.btnAtender_Click);
            //
            // txtResumen
            //
            this.txtResumen.Location = new System.Drawing.Point(12, 40);
            this.txtResumen.Multiline = true;
            this.txtResumen.Name = "txtResumen";
            this.txtResumen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumen.Size = new System.Drawing.Size(430, 80);
            this.txtResumen.TabIndex = 1;
            //
            // lblResumen
            //
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(9, 22);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(240, 13);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "Resumen / diagnóstico (necesario para atender):";
            //
            // dgvCitas
            //
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCitaId,
            this.colCitaFecha,
            this.colCitaHora,
            this.colCitaPaciente,
            this.colCitaMedico,
            this.colCitaMotivo,
            this.colCitaEstado});
            this.dgvCitas.Location = new System.Drawing.Point(12, 100);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(910, 302);
            this.dgvCitas.TabIndex = 1;
            this.dgvCitas.CurrentCellChanged += new System.EventHandler(this.dgvCitas_CurrentCellChanged);
            //
            // colCitaId
            //
            this.colCitaId.FillWeight = 8F;
            this.colCitaId.HeaderText = "N°";
            this.colCitaId.Name = "colCitaId";
            this.colCitaId.ReadOnly = true;
            //
            // colCitaFecha
            //
            this.colCitaFecha.FillWeight = 13F;
            this.colCitaFecha.HeaderText = "Fecha";
            this.colCitaFecha.Name = "colCitaFecha";
            this.colCitaFecha.ReadOnly = true;
            //
            // colCitaHora
            //
            this.colCitaHora.FillWeight = 9F;
            this.colCitaHora.HeaderText = "Hora";
            this.colCitaHora.Name = "colCitaHora";
            this.colCitaHora.ReadOnly = true;
            //
            // colCitaPaciente
            //
            this.colCitaPaciente.FillWeight = 20F;
            this.colCitaPaciente.HeaderText = "Paciente";
            this.colCitaPaciente.Name = "colCitaPaciente";
            this.colCitaPaciente.ReadOnly = true;
            //
            // colCitaMedico
            //
            this.colCitaMedico.FillWeight = 20F;
            this.colCitaMedico.HeaderText = "Médico";
            this.colCitaMedico.Name = "colCitaMedico";
            this.colCitaMedico.ReadOnly = true;
            //
            // colCitaMotivo
            //
            this.colCitaMotivo.FillWeight = 18F;
            this.colCitaMotivo.HeaderText = "Motivo";
            this.colCitaMotivo.Name = "colCitaMotivo";
            this.colCitaMotivo.ReadOnly = true;
            //
            // colCitaEstado
            //
            this.colCitaEstado.FillWeight = 12F;
            this.colCitaEstado.HeaderText = "Estado";
            this.colCitaEstado.Name = "colCitaEstado";
            this.colCitaEstado.ReadOnly = true;
            //
            // grpNuevaCita
            //
            this.grpNuevaCita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNuevaCita.Controls.Add(this.btnNuevoMedicoRapido);
            this.grpNuevaCita.Controls.Add(this.btnNuevoPacienteRapido);
            this.grpNuevaCita.Controls.Add(this.btnAgendar);
            this.grpNuevaCita.Controls.Add(this.txtMotivo);
            this.grpNuevaCita.Controls.Add(this.lblMotivo);
            this.grpNuevaCita.Controls.Add(this.dtpHora);
            this.grpNuevaCita.Controls.Add(this.lblHora);
            this.grpNuevaCita.Controls.Add(this.dtpFecha);
            this.grpNuevaCita.Controls.Add(this.lblFecha);
            this.grpNuevaCita.Controls.Add(this.cmbMedico);
            this.grpNuevaCita.Controls.Add(this.lblCitaMedico);
            this.grpNuevaCita.Controls.Add(this.cmbPaciente);
            this.grpNuevaCita.Controls.Add(this.lblCitaPaciente);
            this.grpNuevaCita.Location = new System.Drawing.Point(12, 8);
            this.grpNuevaCita.Name = "grpNuevaCita";
            this.grpNuevaCita.Size = new System.Drawing.Size(910, 85);
            this.grpNuevaCita.TabIndex = 0;
            this.grpNuevaCita.TabStop = false;
            this.grpNuevaCita.Text = "Nueva cita";
            //
            // btnNuevoMedicoRapido
            //
            this.btnNuevoMedicoRapido.Location = new System.Drawing.Point(565, 21);
            this.btnNuevoMedicoRapido.Name = "btnNuevoMedicoRapido";
            this.btnNuevoMedicoRapido.Size = new System.Drawing.Size(26, 23);
            this.btnNuevoMedicoRapido.TabIndex = 5;
            this.btnNuevoMedicoRapido.Text = "+";
            this.toolTip.SetToolTip(this.btnNuevoMedicoRapido, "Registrar un médico nuevo");
            this.btnNuevoMedicoRapido.UseVisualStyleBackColor = true;
            this.btnNuevoMedicoRapido.Click += new System.EventHandler(this.btnAgregarMedico_Click);
            //
            // btnNuevoPacienteRapido
            //
            this.btnNuevoPacienteRapido.Location = new System.Drawing.Point(265, 21);
            this.btnNuevoPacienteRapido.Name = "btnNuevoPacienteRapido";
            this.btnNuevoPacienteRapido.Size = new System.Drawing.Size(26, 23);
            this.btnNuevoPacienteRapido.TabIndex = 2;
            this.btnNuevoPacienteRapido.Text = "+";
            this.toolTip.SetToolTip(this.btnNuevoPacienteRapido, "Registrar un paciente nuevo");
            this.btnNuevoPacienteRapido.UseVisualStyleBackColor = true;
            this.btnNuevoPacienteRapido.Click += new System.EventHandler(this.btnAgregarPaciente_Click);
            //
            // btnAgendar
            //
            this.btnAgendar.Location = new System.Drawing.Point(790, 50);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(105, 25);
            this.btnAgendar.TabIndex = 12;
            this.btnAgendar.Text = "Agendar cita";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            //
            // txtMotivo
            //
            this.txtMotivo.Location = new System.Drawing.Point(75, 52);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(700, 20);
            this.txtMotivo.TabIndex = 11;
            //
            // lblMotivo
            //
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(12, 55);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 10;
            this.lblMotivo.Text = "Motivo:";
            //
            // dtpHora
            //
            this.dtpHora.CustomFormat = "HH:mm";
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(815, 22);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(80, 20);
            this.dtpHora.TabIndex = 9;
            //
            // lblHora
            //
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(775, 25);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 13);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "Hora:";
            //
            // dtpFecha
            //
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(655, 22);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(105, 20);
            this.dtpFecha.TabIndex = 7;
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(607, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            //
            // cmbMedico
            //
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(355, 22);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(205, 21);
            this.cmbMedico.TabIndex = 4;
            this.cmbMedico.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPersona_Format);
            //
            // lblCitaMedico
            //
            this.lblCitaMedico.AutoSize = true;
            this.lblCitaMedico.Location = new System.Drawing.Point(305, 25);
            this.lblCitaMedico.Name = "lblCitaMedico";
            this.lblCitaMedico.Size = new System.Drawing.Size(45, 13);
            this.lblCitaMedico.TabIndex = 3;
            this.lblCitaMedico.Text = "Médico:";
            //
            // cmbPaciente
            //
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(75, 22);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(185, 21);
            this.cmbPaciente.TabIndex = 1;
            this.cmbPaciente.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPersona_Format);
            //
            // lblCitaPaciente
            //
            this.lblCitaPaciente.AutoSize = true;
            this.lblCitaPaciente.Location = new System.Drawing.Point(12, 25);
            this.lblCitaPaciente.Name = "lblCitaPaciente";
            this.lblCitaPaciente.Size = new System.Drawing.Size(52, 13);
            this.lblCitaPaciente.TabIndex = 0;
            this.lblCitaPaciente.Text = "Paciente:";
            //
            // tabPacientes
            //
            this.tabPacientes.Controls.Add(this.dgvPacientes);
            this.tabPacientes.Controls.Add(this.btnEliminarPaciente);
            this.tabPacientes.Controls.Add(this.btnEditarPaciente);
            this.tabPacientes.Controls.Add(this.btnAgregarPaciente);
            this.tabPacientes.Location = new System.Drawing.Point(4, 22);
            this.tabPacientes.Name = "tabPacientes";
            this.tabPacientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPacientes.Size = new System.Drawing.Size(936, 595);
            this.tabPacientes.TabIndex = 1;
            this.tabPacientes.Text = "Pacientes";
            this.tabPacientes.UseVisualStyleBackColor = true;
            //
            // dgvPacientes
            //
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPacienteId,
            this.colPacienteNombre,
            this.colPacienteTelefono});
            this.dgvPacientes.Location = new System.Drawing.Point(12, 48);
            this.dgvPacientes.MultiSelect = false;
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.RowHeadersVisible = false;
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(910, 535);
            this.dgvPacientes.TabIndex = 3;
            this.dgvPacientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellDoubleClick);
            //
            // colPacienteId
            //
            this.colPacienteId.FillWeight = 25F;
            this.colPacienteId.HeaderText = "Cédula / Id";
            this.colPacienteId.Name = "colPacienteId";
            this.colPacienteId.ReadOnly = true;
            //
            // colPacienteNombre
            //
            this.colPacienteNombre.FillWeight = 45F;
            this.colPacienteNombre.HeaderText = "Nombre";
            this.colPacienteNombre.Name = "colPacienteNombre";
            this.colPacienteNombre.ReadOnly = true;
            //
            // colPacienteTelefono
            //
            this.colPacienteTelefono.FillWeight = 30F;
            this.colPacienteTelefono.HeaderText = "Teléfono";
            this.colPacienteTelefono.Name = "colPacienteTelefono";
            this.colPacienteTelefono.ReadOnly = true;
            //
            // btnEliminarPaciente
            //
            this.btnEliminarPaciente.Location = new System.Drawing.Point(258, 10);
            this.btnEliminarPaciente.Name = "btnEliminarPaciente";
            this.btnEliminarPaciente.Size = new System.Drawing.Size(100, 28);
            this.btnEliminarPaciente.TabIndex = 2;
            this.btnEliminarPaciente.Text = "Eliminar";
            this.btnEliminarPaciente.UseVisualStyleBackColor = true;
            this.btnEliminarPaciente.Click += new System.EventHandler(this.btnEliminarPaciente_Click);
            //
            // btnEditarPaciente
            //
            this.btnEditarPaciente.Location = new System.Drawing.Point(150, 10);
            this.btnEditarPaciente.Name = "btnEditarPaciente";
            this.btnEditarPaciente.Size = new System.Drawing.Size(100, 28);
            this.btnEditarPaciente.TabIndex = 1;
            this.btnEditarPaciente.Text = "Editar";
            this.btnEditarPaciente.UseVisualStyleBackColor = true;
            this.btnEditarPaciente.Click += new System.EventHandler(this.btnEditarPaciente_Click);
            //
            // btnAgregarPaciente
            //
            this.btnAgregarPaciente.Location = new System.Drawing.Point(12, 10);
            this.btnAgregarPaciente.Name = "btnAgregarPaciente";
            this.btnAgregarPaciente.Size = new System.Drawing.Size(130, 28);
            this.btnAgregarPaciente.TabIndex = 0;
            this.btnAgregarPaciente.Text = "Agregar paciente";
            this.btnAgregarPaciente.UseVisualStyleBackColor = true;
            this.btnAgregarPaciente.Click += new System.EventHandler(this.btnAgregarPaciente_Click);
            //
            // tabMedicos
            //
            this.tabMedicos.Controls.Add(this.dgvMedicos);
            this.tabMedicos.Controls.Add(this.btnEliminarMedico);
            this.tabMedicos.Controls.Add(this.btnEditarMedico);
            this.tabMedicos.Controls.Add(this.btnAgregarMedico);
            this.tabMedicos.Location = new System.Drawing.Point(4, 22);
            this.tabMedicos.Name = "tabMedicos";
            this.tabMedicos.Padding = new System.Windows.Forms.Padding(3);
            this.tabMedicos.Size = new System.Drawing.Size(936, 595);
            this.tabMedicos.TabIndex = 2;
            this.tabMedicos.Text = "Médicos";
            this.tabMedicos.UseVisualStyleBackColor = true;
            //
            // dgvMedicos
            //
            this.dgvMedicos.AllowUserToAddRows = false;
            this.dgvMedicos.AllowUserToDeleteRows = false;
            this.dgvMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMedicoId,
            this.colMedicoNombre,
            this.colMedicoEspecialidad});
            this.dgvMedicos.Location = new System.Drawing.Point(12, 48);
            this.dgvMedicos.MultiSelect = false;
            this.dgvMedicos.Name = "dgvMedicos";
            this.dgvMedicos.ReadOnly = true;
            this.dgvMedicos.RowHeadersVisible = false;
            this.dgvMedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicos.Size = new System.Drawing.Size(910, 535);
            this.dgvMedicos.TabIndex = 3;
            this.dgvMedicos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicos_CellDoubleClick);
            //
            // colMedicoId
            //
            this.colMedicoId.FillWeight = 25F;
            this.colMedicoId.HeaderText = "Cédula / Id";
            this.colMedicoId.Name = "colMedicoId";
            this.colMedicoId.ReadOnly = true;
            //
            // colMedicoNombre
            //
            this.colMedicoNombre.FillWeight = 40F;
            this.colMedicoNombre.HeaderText = "Nombre";
            this.colMedicoNombre.Name = "colMedicoNombre";
            this.colMedicoNombre.ReadOnly = true;
            //
            // colMedicoEspecialidad
            //
            this.colMedicoEspecialidad.FillWeight = 35F;
            this.colMedicoEspecialidad.HeaderText = "Especialidad";
            this.colMedicoEspecialidad.Name = "colMedicoEspecialidad";
            this.colMedicoEspecialidad.ReadOnly = true;
            //
            // btnEliminarMedico
            //
            this.btnEliminarMedico.Location = new System.Drawing.Point(258, 10);
            this.btnEliminarMedico.Name = "btnEliminarMedico";
            this.btnEliminarMedico.Size = new System.Drawing.Size(100, 28);
            this.btnEliminarMedico.TabIndex = 2;
            this.btnEliminarMedico.Text = "Eliminar";
            this.btnEliminarMedico.UseVisualStyleBackColor = true;
            this.btnEliminarMedico.Click += new System.EventHandler(this.btnEliminarMedico_Click);
            //
            // btnEditarMedico
            //
            this.btnEditarMedico.Location = new System.Drawing.Point(150, 10);
            this.btnEditarMedico.Name = "btnEditarMedico";
            this.btnEditarMedico.Size = new System.Drawing.Size(100, 28);
            this.btnEditarMedico.TabIndex = 1;
            this.btnEditarMedico.Text = "Editar";
            this.btnEditarMedico.UseVisualStyleBackColor = true;
            this.btnEditarMedico.Click += new System.EventHandler(this.btnEditarMedico_Click);
            //
            // btnAgregarMedico
            //
            this.btnAgregarMedico.Location = new System.Drawing.Point(12, 10);
            this.btnAgregarMedico.Name = "btnAgregarMedico";
            this.btnAgregarMedico.Size = new System.Drawing.Size(130, 28);
            this.btnAgregarMedico.TabIndex = 0;
            this.btnAgregarMedico.Text = "Agregar médico";
            this.btnAgregarMedico.UseVisualStyleBackColor = true;
            this.btnAgregarMedico.Click += new System.EventHandler(this.btnAgregarMedico_Click);
            //
            // FormPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 645);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.MinimumSize = new System.Drawing.Size(960, 520);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Clínica";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.tabPrincipal.ResumeLayout(false);
            this.tabCitas.ResumeLayout(false);
            this.grpCitaSeleccionada.ResumeLayout(false);
            this.grpCitaSeleccionada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.grpNuevaCita.ResumeLayout(false);
            this.grpNuevaCita.PerformLayout();
            this.tabPacientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.tabMedicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrar;
        private System.Windows.Forms.ToolStripMenuItem mnuNuevoMedico;
        private System.Windows.Forms.ToolStripMenuItem mnuNuevoPaciente;
        private System.Windows.Forms.ToolStripSeparator mnuSeparador;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabCitas;
        private System.Windows.Forms.TabPage tabPacientes;
        private System.Windows.Forms.TabPage tabMedicos;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicoEspecialidad;
        private System.Windows.Forms.Button btnAgregarMedico;
        private System.Windows.Forms.Button btnEditarMedico;
        private System.Windows.Forms.Button btnEliminarMedico;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPacienteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPacienteNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPacienteTelefono;
        private System.Windows.Forms.Button btnAgregarPaciente;
        private System.Windows.Forms.Button btnEditarPaciente;
        private System.Windows.Forms.Button btnEliminarPaciente;
        private System.Windows.Forms.GroupBox grpNuevaCita;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Button btnNuevoMedicoRapido;
        private System.Windows.Forms.Label lblCitaMedico;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Button btnNuevoPacienteRapido;
        private System.Windows.Forms.Label lblCitaPaciente;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitaFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitaPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitaMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitaMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitaEstado;
        private System.Windows.Forms.GroupBox grpCitaSeleccionada;
        private System.Windows.Forms.TextBox txtHistoria;
        private System.Windows.Forms.Label lblHistoria;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.TextBox txtResumen;
        private System.Windows.Forms.Label lblResumen;
    }
}
