namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	partial class FormUsuario
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnNuevo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEditar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRoles = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEliminar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgvUsuarios = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCajero = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnResetearClave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnEditar,
            this.toolStripSeparator4,
            this.btnResetearClave,
            this.toolStripSeparator5,
            this.btnRoles,
            this.toolStripSeparator2,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(503, 38);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnNuevo
			// 
			this.btnNuevo.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.archivo;
			this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(46, 35);
			this.btnNuevo.Text = "Nuevo";
			this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnNuevo.Click += new System.EventHandler(this.BtnNuevoClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// btnEditar
			// 
			this.btnEditar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.editar;
			this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(41, 35);
			this.btnEditar.Text = "Editar";
			this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEditar.Click += new System.EventHandler(this.BtnEditarClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
			// 
			// btnRoles
			// 
			this.btnRoles.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.agregar_usuario;
			this.btnRoles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRoles.Name = "btnRoles";
			this.btnRoles.Size = new System.Drawing.Size(39, 35);
			this.btnRoles.Text = "Roles";
			this.btnRoles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRoles.Click += new System.EventHandler(this.BtnRoles_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.Remove;
			this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(54, 35);
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEliminar.Click += new System.EventHandler(this.BtnEliminarClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// btnSalir
			// 
			this.btnSalir.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.logout__1_;
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(33, 35);
			this.btnSalir.Text = "Salir";
			this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSalir.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgvUsuarios);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(503, 332);
			this.panel1.TabIndex = 3;
			// 
			// dgvUsuarios
			// 
			this.dgvUsuarios.AllowUserToAddRows = false;
			this.dgvUsuarios.AllowUserToDeleteRows = false;
			this.dgvUsuarios.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColLogin,
            this.ColNombres,
            this.ColCajero,
            this.ColEstado});
			this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvUsuarios.Location = new System.Drawing.Point(0, 40);
			this.dgvUsuarios.MultiSelect = false;
			this.dgvUsuarios.Name = "dgvUsuarios";
			this.dgvUsuarios.ReadOnly = true;
			this.dgvUsuarios.RowHeadersWidth = 20;
			this.dgvUsuarios.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvUsuarios.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvUsuarios.Size = new System.Drawing.Size(503, 292);
			this.dgvUsuarios.TabIndex = 5;
			this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsuariosCellDoubleClick);
			// 
			// ColId
			// 
			this.ColId.HeaderText = "Id";
			this.ColId.Name = "ColId";
			this.ColId.ReadOnly = true;
			this.ColId.Visible = false;
			// 
			// ColLogin
			// 
			this.ColLogin.HeaderText = "Login";
			this.ColLogin.Name = "ColLogin";
			this.ColLogin.ReadOnly = true;
			// 
			// ColNombres
			// 
			this.ColNombres.HeaderText = "Nombres";
			this.ColNombres.Name = "ColNombres";
			this.ColNombres.ReadOnly = true;
			this.ColNombres.Width = 200;
			// 
			// ColCajero
			// 
			this.ColCajero.HeaderText = "Cajero";
			this.ColCajero.Name = "ColCajero";
			this.ColCajero.ReadOnly = true;
			this.ColCajero.Width = 80;
			// 
			// ColEstado
			// 
			this.ColEstado.HeaderText = "Estado";
			this.ColEstado.Name = "ColEstado";
			this.ColEstado.ReadOnly = true;
			// 
			// btnResetearClave
			// 
			this.btnResetearClave.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.ok;
			this.btnResetearClave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnResetearClave.Name = "btnResetearClave";
			this.btnResetearClave.Size = new System.Drawing.Size(85, 35);
			this.btnResetearClave.Text = "Resetear clave";
			this.btnResetearClave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnResetearClave.Click += new System.EventHandler(this.BtnResetearClave_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
			// 
			// FormUsuario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(503, 332);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Name = "FormUsuario";
			this.Text = "FormUsuario";
			this.Load += new System.EventHandler(this.FormUsuario_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnNuevo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnEditar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnEliminar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgvUsuarios;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColLogin;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColNombres;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColCajero;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnRoles;
		private System.Windows.Forms.ToolStripButton btnResetearClave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
	}
}