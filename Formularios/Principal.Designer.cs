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
            this.lstFicheros = new System.Windows.Forms.ListView();
            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.lblBarraAvisoClave = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkEnlaceWeb = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblArrastrar = new System.Windows.Forms.Label();
            this.menuListaFicheros = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cifrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPedirClave = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnModo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.barraEstado.SuspendLayout();
            this.menuListaFicheros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeleccionarFicheros
            // 
            this.btnSeleccionarFicheros.BackColor = System.Drawing.Color.White;
            this.btnSeleccionarFicheros.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSeleccionarFicheros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSeleccionarFicheros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSeleccionarFicheros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFicheros.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarFicheros.Image = global::EasyCrypt.Properties.Resources.Documentos;
            this.btnSeleccionarFicheros.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeleccionarFicheros.Location = new System.Drawing.Point(12, 29);
            this.btnSeleccionarFicheros.Name = "btnSeleccionarFicheros";
            this.btnSeleccionarFicheros.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnSeleccionarFicheros.Size = new System.Drawing.Size(80, 70);
            this.btnSeleccionarFicheros.TabIndex = 1;
            this.btnSeleccionarFicheros.Text = "&Abrir";
            this.btnSeleccionarFicheros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeleccionarFicheros.UseVisualStyleBackColor = false;
            this.btnSeleccionarFicheros.Click += new System.EventHandler(this.btnSeleccionarFicheros_Click);
            // 
            // dlgFicheros
            // 
            this.dlgFicheros.Filter = "Todos los ficheros|*";
            this.dlgFicheros.Multiselect = true;
            this.dlgFicheros.SupportMultiDottedExtensions = true;
            this.dlgFicheros.Title = "Seleccione ficheros";
            // 
            // lstFicheros
            // 
            this.lstFicheros.Location = new System.Drawing.Point(12, 105);
            this.lstFicheros.Name = "lstFicheros";
            this.lstFicheros.Size = new System.Drawing.Size(420, 315);
            this.lstFicheros.TabIndex = 11;
            this.lstFicheros.UseCompatibleStateImageBehavior = false;
            this.lstFicheros.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstFicheros_KeyUp);
            this.lstFicheros.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstFicheros_MouseClick);
            this.lstFicheros.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstFicheros_MouseMove);
            // 
            // barraEstado
            // 
            this.barraEstado.BackColor = System.Drawing.Color.White;
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBarraAvisoClave,
            this.linkEnlaceWeb});
            this.barraEstado.Location = new System.Drawing.Point(0, 428);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.barraEstado.Size = new System.Drawing.Size(443, 24);
            this.barraEstado.TabIndex = 12;
            // 
            // lblBarraAvisoClave
            // 
            this.lblBarraAvisoClave.AutoSize = false;
            this.lblBarraAvisoClave.BackColor = System.Drawing.Color.White;
            this.lblBarraAvisoClave.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblBarraAvisoClave.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblBarraAvisoClave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblBarraAvisoClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarraAvisoClave.ForeColor = System.Drawing.Color.Navy;
            this.lblBarraAvisoClave.Name = "lblBarraAvisoClave";
            this.lblBarraAvisoClave.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.lblBarraAvisoClave.Size = new System.Drawing.Size(350, 19);
            this.lblBarraAvisoClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkEnlaceWeb
            // 
            this.linkEnlaceWeb.AutoSize = false;
            this.linkEnlaceWeb.BackColor = System.Drawing.Color.White;
            this.linkEnlaceWeb.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.linkEnlaceWeb.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.linkEnlaceWeb.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEnlaceWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkEnlaceWeb.IsLink = true;
            this.linkEnlaceWeb.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkEnlaceWeb.Name = "linkEnlaceWeb";
            this.linkEnlaceWeb.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.linkEnlaceWeb.Size = new System.Drawing.Size(63, 19);
            this.linkEnlaceWeb.Text = "EasyCrypt";
            this.linkEnlaceWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArrastrar
            // 
            this.lblArrastrar.AutoSize = true;
            this.lblArrastrar.BackColor = System.Drawing.SystemColors.Window;
            this.lblArrastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrastrar.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblArrastrar.Location = new System.Drawing.Point(31, 218);
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
            this.cifrarToolStripMenuItem,
            this.toolStripSeparator1,
            this.eliminarToolStripMenuItem});
            this.menuListaFicheros.Name = "menuListaFicheros";
            this.menuListaFicheros.Size = new System.Drawing.Size(108, 54);
            // 
            // cifrarToolStripMenuItem
            // 
            this.cifrarToolStripMenuItem.Enabled = false;
            this.cifrarToolStripMenuItem.Name = "cifrarToolStripMenuItem";
            this.cifrarToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.cifrarToolStripMenuItem.Text = "Cifrar";
            this.cifrarToolStripMenuItem.Click += new System.EventHandler(this.cifrarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.eliminarToolStripMenuItem.Text = "Quitar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // btnPedirClave
            // 
            this.btnPedirClave.BackColor = System.Drawing.Color.White;
            this.btnPedirClave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPedirClave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPedirClave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPedirClave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPedirClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedirClave.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            this.btnPedirClave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnPedirClave.Image = global::EasyCrypt.Properties.Resources.clave;
            this.btnPedirClave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPedirClave.Location = new System.Drawing.Point(240, 29);
            this.btnPedirClave.Name = "btnPedirClave";
            this.btnPedirClave.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnPedirClave.Size = new System.Drawing.Size(80, 70);
            this.btnPedirClave.TabIndex = 16;
            this.btnPedirClave.Text = "&Clave";
            this.btnPedirClave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPedirClave.UseVisualStyleBackColor = false;
            this.btnPedirClave.Click += new System.EventHandler(this.btnClave_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.White;
            this.btnProcesar.BackgroundImage = global::EasyCrypt.Properties.Resources.empezar;
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnProcesar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            this.btnProcesar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnProcesar.Image = global::EasyCrypt.Properties.Resources.docCifrado;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnProcesar.Location = new System.Drawing.Point(352, 29);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(80, 70);
            this.btnProcesar.TabIndex = 17;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnModo
            // 
            this.btnModo.BackColor = System.Drawing.Color.White;
            this.btnModo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModo.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnModo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnModo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModo.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            this.btnModo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnModo.Image = global::EasyCrypt.Properties.Resources.CandadoCerrado;
            this.btnModo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModo.Location = new System.Drawing.Point(125, 29);
            this.btnModo.Name = "btnModo";
            this.btnModo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnModo.Size = new System.Drawing.Size(80, 70);
            this.btnModo.TabIndex = 18;
            this.btnModo.Text = "C&ifrar";
            this.btnModo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModo.UseVisualStyleBackColor = false;
            this.btnModo.Click += new System.EventHandler(this.btnModo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(417, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(443, 452);
            this.Controls.Add(this.barraEstado);
            this.Controls.Add(this.lblArrastrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSeleccionarFicheros);
            this.Controls.Add(this.lstFicheros);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnModo);
            this.Controls.Add(this.btnPedirClave);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyCrypt";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Principal_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Principal_DragEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Principal_MouseMove);
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
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
		private System.Windows.Forms.ListView lstFicheros;
		private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraAvisoClave;
		private System.Windows.Forms.Label lblArrastrar;
		private System.Windows.Forms.ContextMenuStrip menuListaFicheros;
		private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cifrarToolStripMenuItem;
        private System.Windows.Forms.Button btnPedirClave;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnModo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel linkEnlaceWeb;
        private System.Windows.Forms.Label label1;
	}
}

