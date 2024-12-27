namespace HVLH.SistemaCaja.AppWin.Inicio
{
	partial class FormCambioClave
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
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnCambiar = new System.Windows.Forms.Button();
			this.lnkCancelar = new System.Windows.Forms.LinkLabel();
			this.txtRepetirClave = new System.Windows.Forms.TextBox();
			this.txtNuevaClave = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(69, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cambio de clave";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Lavender;
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
			this.splitContainer1.Panel2.Controls.Add(this.btnCambiar);
			this.splitContainer1.Panel2.Controls.Add(this.lnkCancelar);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.txtRepetirClave);
			this.splitContainer1.Panel2.Controls.Add(this.txtNuevaClave);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Size = new System.Drawing.Size(575, 247);
			this.splitContainer1.SplitterDistance = 276;
			this.splitContainer1.TabIndex = 3;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.encrypted;
			this.pictureBox1.Location = new System.Drawing.Point(54, 55);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(168, 136);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// btnCambiar
			// 
			this.btnCambiar.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCambiar.ForeColor = System.Drawing.Color.White;
			this.btnCambiar.Location = new System.Drawing.Point(59, 171);
			this.btnCambiar.Name = "btnCambiar";
			this.btnCambiar.Size = new System.Drawing.Size(176, 23);
			this.btnCambiar.TabIndex = 1;
			this.btnCambiar.Text = "Cambiar";
			this.btnCambiar.UseVisualStyleBackColor = false;
			this.btnCambiar.Click += new System.EventHandler(this.BtnCambiar_Click);
			// 
			// lnkCancelar
			// 
			this.lnkCancelar.AutoSize = true;
			this.lnkCancelar.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lnkCancelar.LinkColor = System.Drawing.SystemColors.MenuHighlight;
			this.lnkCancelar.Location = new System.Drawing.Point(224, 216);
			this.lnkCancelar.Name = "lnkCancelar";
			this.lnkCancelar.Size = new System.Drawing.Size(51, 13);
			this.lnkCancelar.TabIndex = 1;
			this.lnkCancelar.TabStop = true;
			this.lnkCancelar.Text = "Cancelar";
			this.lnkCancelar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkCancelar_LinkClicked);
			// 
			// txtRepetirClave
			// 
			this.txtRepetirClave.Location = new System.Drawing.Point(59, 139);
			this.txtRepetirClave.Name = "txtRepetirClave";
			this.txtRepetirClave.PasswordChar = '*';
			this.txtRepetirClave.Size = new System.Drawing.Size(176, 20);
			this.txtRepetirClave.TabIndex = 2;
			// 
			// txtNuevaClave
			// 
			this.txtNuevaClave.Location = new System.Drawing.Point(59, 91);
			this.txtNuevaClave.Name = "txtNuevaClave";
			this.txtNuevaClave.PasswordChar = '*';
			this.txtNuevaClave.Size = new System.Drawing.Size(176, 20);
			this.txtNuevaClave.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(61, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Reptir clave";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(61, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nueva clave";
			// 
			// FormCambioClave
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 247);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FormCambioClave";
			this.Text = "FormCambioClave";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.LinkLabel lnkCancelar;
		private System.Windows.Forms.Button btnCambiar;
		private System.Windows.Forms.TextBox txtRepetirClave;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNuevaClave;
		private System.Windows.Forms.Label label2;
	}
}