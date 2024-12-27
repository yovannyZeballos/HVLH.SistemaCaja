namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	partial class FormRolMenu
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnAsociar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.tvMenus = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAsociar,
            this.toolStripSeparator1,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(329, 38);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnAsociar
			// 
			this.btnAsociar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.comprobar;
			this.btnAsociar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAsociar.Name = "btnAsociar";
			this.btnAsociar.Size = new System.Drawing.Size(50, 35);
			this.btnAsociar.Text = "Asociar";
			this.btnAsociar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAsociar.Click += new System.EventHandler(this.BtnAsociar_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// btnSalir
			// 
			this.btnSalir.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.logout__1_;
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(33, 35);
			this.btnSalir.Text = "Salir";
			this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
			// 
			// tvMenus
			// 
			this.tvMenus.CheckBoxes = true;
			this.tvMenus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tvMenus.Location = new System.Drawing.Point(0, 56);
			this.tvMenus.Name = "tvMenus";
			this.tvMenus.Size = new System.Drawing.Size(329, 301);
			this.tvMenus.TabIndex = 6;
			this.tvMenus.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvMenus_AfterCheck);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label1.Location = new System.Drawing.Point(0, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(329, 18);
			this.label1.TabIndex = 7;
			this.label1.Text = "Seleccionar menus";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormRolMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 357);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tvMenus);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormRolMenu";
			this.Text = "Asociar menus";
			this.Load += new System.EventHandler(this.FormRolMenu_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAsociar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.TreeView tvMenus;
		private System.Windows.Forms.Label label1;
	}
}