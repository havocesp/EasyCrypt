namespace EasyCrypt
{
	partial class Principal
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
			if (disposing && (components != null)) {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
			this.btnSeleccionarFicheros = new System.Windows.Forms.Button();
			this.dlgFicheros = new System.Windows.Forms.OpenFileDialog();
			this.lblPaso1 = new System.Windows.Forms.Label();
			this.cmbAccion = new System.Windows.Forms.ComboBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.lblClave = new System.Windows.Forms.Label();
			this.lblFicheros = new System.Windows.Forms.Label();
			this.btnCifrar = new System.Windows.Forms.Button();
			this.cbBorrarFicheros = new System.Windows.Forms.CheckBox();
			this.lstFicheros = new System.Windows.Forms.ListView();
			this.barraEstado = new System.Windows.Forms.StatusStrip();
			this.lblBarraAvisoClave = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblArrastrar = new System.Windows.Forms.Label();
			this.menuListaFicheros = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cifrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.barraProgreso = new System.Windows.Forms.ProgressBar();
			this.barraEstado.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.menuListaFicheros.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSeleccionarFicheros
			// 
			this.btnSeleccionarFicheros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSeleccionarFicheros.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
			this.btnSeleccionarFicheros.Location = new System.Drawing.Point(12, 354);
			this.btnSeleccionarFicheros.Name = "btnSeleccionarFicheros";
			this.btnSeleccionarFicheros.Size = new System.Drawing.Size(133, 23);
			this.btnSeleccionarFicheros.TabIndex = 1;
			this.btnSeleccionarFicheros.Text = "&Seleccionar ficheros";
			this.btnSeleccionarFicheros.UseVisualStyleBackColor = true;
			this.btnSeleccionarFicheros.Click += new System.EventHandler(this.btnSeleccionarFicheros_Click);
			// 
			// dlgFicheros
			// 
			this.dlgFicheros.Filter = "Todos los ficheros|*.*\"";
			this.dlgFicheros.Multiselect = true;
			this.dlgFicheros.SupportMultiDottedExtensions = true;
			this.dlgFicheros.Title = "Seleccione ficheros";
			// 
			// lblPaso1
			// 
			this.lblPaso1.AutoSize = true;
			this.lblPaso1.Font = new System.Drawing.Font("Lucida Console", 10F);
			this.lblPaso1.Location = new System.Drawing.Point(9, 31);
			this.lblPaso1.Name = "lblPaso1";
			this.lblPaso1.Size = new System.Drawing.Size(63, 14);
			this.lblPaso1.TabIndex = 3;
			this.lblPaso1.Text = "Acción:";
			// 
			// cmbAccion
			// 
			this.cmbAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAccion.FormattingEnabled = true;
			this.cmbAccion.Items.AddRange(new object[] {
				"Cifrar",
				"Descifrar"
			});
			this.cmbAccion.Location = new System.Drawing.Point(12, 47);
			this.cmbAccion.Name = "cmbAccion";
			this.cmbAccion.Size = new System.Drawing.Size(157, 21);
			this.cmbAccion.TabIndex = 3;
			this.cmbAccion.SelectedIndexChanged += new System.EventHandler(this.cmbAccion_SelectedIndexChanged);
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(175, 47);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(226, 20);
			this.txtClave.TabIndex = 0;
			this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtClave.UseSystemPasswordChar = true;
			this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
			this.txtClave.Leave += new System.EventHandler(this.txtClave_Leave);
			// 
			// lblClave
			// 
			this.lblClave.AutoSize = true;
			this.lblClave.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClave.Location = new System.Drawing.Point(172, 31);
			this.lblClave.Name = "lblClave";
			this.lblClave.Size = new System.Drawing.Size(119, 14);
			this.lblClave.TabIndex = 5;
			this.lblClave.Text = "Contraseña de ";
			// 
			// lblFicheros
			// 
			this.lblFicheros.AutoSize = true;
			this.lblFicheros.Font = new System.Drawing.Font("Lucida Console", 10F);
			this.lblFicheros.Location = new System.Drawing.Point(9, 74);
			this.lblFicheros.Name = "lblFicheros";
			this.lblFicheros.Size = new System.Drawing.Size(159, 14);
			this.lblFicheros.TabIndex = 6;
			this.lblFicheros.Text = "Lista de ficheros a";
			// 
			// btnCifrar
			// 
			this.btnCifrar.Enabled = false;
			this.btnCifrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCifrar.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
			this.btnCifrar.Location = new System.Drawing.Point(268, 354);
			this.btnCifrar.Name = "btnCifrar";
			this.btnCifrar.Size = new System.Drawing.Size(133, 23);
			this.btnCifrar.TabIndex = 2;
			this.btnCifrar.Text = "&Cifrar";
			this.btnCifrar.UseVisualStyleBackColor = true;
			this.btnCifrar.Click += new System.EventHandler(this.btnCifrar_Click);
			// 
			// cbBorrarFicheros
			// 
			this.cbBorrarFicheros.AutoSize = true;
			this.cbBorrarFicheros.Checked = true;
			this.cbBorrarFicheros.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbBorrarFicheros.Font = new System.Drawing.Font("Lucida Console", 8F);
			this.cbBorrarFicheros.Location = new System.Drawing.Point(12, 331);
			this.cbBorrarFicheros.Name = "cbBorrarFicheros";
			this.cbBorrarFicheros.Size = new System.Drawing.Size(171, 15);
			this.cbBorrarFicheros.TabIndex = 8;
			this.cbBorrarFicheros.Text = "Borrar ficheros tras ";
			this.cbBorrarFicheros.UseVisualStyleBackColor = true;
			// 
			// lstFicheros
			// 
			this.lstFicheros.Location = new System.Drawing.Point(12, 91);
			this.lstFicheros.Name = "lstFicheros";
			this.lstFicheros.Size = new System.Drawing.Size(389, 234);
			this.lstFicheros.TabIndex = 11;
			this.lstFicheros.UseCompatibleStateImageBehavior = false;
			this.lstFicheros.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstFicheros_KeyUp);
			this.lstFicheros.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstFicheros_MouseClick);
			// 
			// barraEstado
			// 
			this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.lblBarraAvisoClave
			});
			this.barraEstado.Location = new System.Drawing.Point(0, 393);
			this.barraEstado.Name = "barraEstado";
			this.barraEstado.Size = new System.Drawing.Size(414, 22);
			this.barraEstado.TabIndex = 12;
			// 
			// lblBarraAvisoClave
			// 
			this.lblBarraAvisoClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblBarraAvisoClave.ForeColor = System.Drawing.Color.DarkRed;
			this.lblBarraAvisoClave.Name = "lblBarraAvisoClave";
			this.lblBarraAvisoClave.Size = new System.Drawing.Size(360, 17);
			this.lblBarraAvisoClave.Text = "RECUERDE: Si olvida la contraseña no podrá recuperar sus datos.";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.ayudaToolStripMenuItem
			});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.menuStrip1.Size = new System.Drawing.Size(414, 24);
			this.menuStrip1.TabIndex = 13;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ayudaToolStripMenuItem
			// 
			this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.actualizarToolStripMenuItem,
				this.acercaDeToolStripMenuItem
			});
			this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
			this.ayudaToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.ayudaToolStripMenuItem.Text = "&Ayuda";
			// 
			// actualizarToolStripMenuItem
			// 
			this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
			this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.actualizarToolStripMenuItem.Text = "Actualizar";
			this.actualizarToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
			// 
			// acercaDeToolStripMenuItem
			// 
			this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
			this.acercaDeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.acercaDeToolStripMenuItem.RightToLeftAutoMirrorImage = true;
			this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.acercaDeToolStripMenuItem.Text = "Acerca de ...";
			this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
			// 
			// lblArrastrar
			// 
			this.lblArrastrar.AutoSize = true;
			this.lblArrastrar.BackColor = System.Drawing.SystemColors.Window;
			this.lblArrastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblArrastrar.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lblArrastrar.Location = new System.Drawing.Point(34, 176);
			this.lblArrastrar.Name = "lblArrastrar";
			this.lblArrastrar.Size = new System.Drawing.Size(343, 40);
			this.lblArrastrar.TabIndex = 14;
			this.lblArrastrar.Text = "Tambien puedes arrastrar aquí directorios\r\no ficheros para cifrar / descifrar ..." +
			"";
			this.lblArrastrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// menuListaFicheros
			// 
			this.menuListaFicheros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.eliminarToolStripMenuItem,
				this.cifrarToolStripMenuItem
			});
			this.menuListaFicheros.Name = "menuListaFicheros";
			this.menuListaFicheros.Size = new System.Drawing.Size(118, 48);
			// 
			// eliminarToolStripMenuItem
			// 
			this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
			this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.eliminarToolStripMenuItem.Text = "Eliminar";
			this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
			// 
			// cifrarToolStripMenuItem
			// 
			this.cifrarToolStripMenuItem.Name = "cifrarToolStripMenuItem";
			this.cifrarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.cifrarToolStripMenuItem.Text = "Cifrar";
			this.cifrarToolStripMenuItem.Click += new System.EventHandler(this.cifrarToolStripMenuItem_Click);
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.ShowNewFolderButton = false;
			// 
			// barraProgreso
			// 
			this.barraProgreso.Location = new System.Drawing.Point(23, 292);
			this.barraProgreso.Name = "barraProgreso";
			this.barraProgreso.Size = new System.Drawing.Size(367, 23);
			this.barraProgreso.Step = 1;
			this.barraProgreso.Minimum = 0;
			this.barraProgreso.Value = 0;
			this.barraProgreso.TabIndex = 15;
			this.barraProgreso.Visible = false;
			// 
			// Principal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 415);
			this.Controls.Add(this.barraProgreso);
			this.Controls.Add(this.barraEstado);
			this.Controls.Add(this.lblArrastrar);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.lstFicheros);
			this.Controls.Add(this.cbBorrarFicheros);
			this.Controls.Add(this.btnCifrar);
			this.Controls.Add(this.lblFicheros);
			this.Controls.Add(this.lblClave);
			this.Controls.Add(this.txtClave);
			this.Controls.Add(this.cmbAccion);
			this.Controls.Add(this.lblPaso1);
			this.Controls.Add(this.btnSeleccionarFicheros);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Principal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SensibleInfo";
			this.Load += new System.EventHandler(this.Principal_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Principal_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Principal_DragEnter);
			this.barraEstado.ResumeLayout(false);
			this.barraEstado.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.menuListaFicheros.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.EventHandler listView1_DragDrop()
		{
			throw new System.NotImplementedException();
		}

		#endregion

		private System.Windows.Forms.Button btnSeleccionarFicheros;
		private System.Windows.Forms.OpenFileDialog dlgFicheros;
		private System.Windows.Forms.Label lblPaso1;
		private System.Windows.Forms.ComboBox cmbAccion;
		private System.Windows.Forms.Label lblClave;
		private System.Windows.Forms.Label lblFicheros;
		private System.Windows.Forms.Button btnCifrar;
		private System.Windows.Forms.CheckBox cbBorrarFicheros;
		private System.Windows.Forms.ListView lstFicheros;
		private System.Windows.Forms.StatusStrip barraEstado;
		private System.Windows.Forms.ToolStripStatusLabel lblBarraAvisoClave;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
		private System.Windows.Forms.Label lblArrastrar;
		private System.Windows.Forms.ContextMenuStrip menuListaFicheros;
		private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cifrarToolStripMenuItem;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		public System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.ProgressBar barraProgreso;
		private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
	}
}

