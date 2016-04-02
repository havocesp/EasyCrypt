namespace EasyCrypt
{
	partial class DlgPassword
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgPassword));
			this.txtClave = new System.Windows.Forms.TextBox();
			this.lblClave = new System.Windows.Forms.Label();
			this.btnDescifrar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(12, 37);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(244, 20);
			this.txtClave.TabIndex = 0;
			this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtClave.UseSystemPasswordChar = true;
			this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
			// 
			// lblClave
			// 
			this.lblClave.AutoSize = true;
			this.lblClave.Font = new System.Drawing.Font(Textos.CONF_FUENTE_1, 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClave.Location = new System.Drawing.Point(12, 20);
			this.lblClave.Name = "lblClave";
			this.lblClave.Size = new System.Drawing.Size(183, 14);
			this.lblClave.TabIndex = 6;
			this.lblClave.Text = Textos.TEXTO_INTRO_PASS;
			// 
			// btnDescifrar
			// 
			this.btnDescifrar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnDescifrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDescifrar.Font = new System.Drawing.Font(Textos.CONF_FUENTE_1, 9F, System.Drawing.FontStyle.Bold);
			this.btnDescifrar.Location = new System.Drawing.Point(62, 62);
			this.btnDescifrar.Name = "btnDescifrar";
			this.btnDescifrar.Size = new System.Drawing.Size(133, 23);
			this.btnDescifrar.TabIndex = 1;
			this.btnDescifrar.Text = Textos.BOTON_DESCIFRAR;
			this.btnDescifrar.UseVisualStyleBackColor = true;
			this.btnDescifrar.Click += new System.EventHandler(this.btnDescifrar_Click);
			// 
			// frmClave
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(268, 97);
			this.Controls.Add(this.btnDescifrar);
			this.Controls.Add(this.lblClave);
			this.Controls.Add(this.txtClave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmClave";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = Constantes.APP_NOMBRE;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.Label lblClave;
		private System.Windows.Forms.Button btnDescifrar;

	}
}