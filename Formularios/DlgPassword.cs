using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyCrypt
{
	public partial class DlgPassword : Form
	{
        private string password = "";
        bool solicitarConfirmacion = false;

		public DlgPassword(bool solicitarConfirmacion = false)
		{
			InitializeComponent();
            this.solicitarConfirmacion = solicitarConfirmacion;
		}

		private void aceptar_Click(object sender, EventArgs e)
		{
            if (txtClave.Text.Length > 0)
            {
                if (this.solicitarConfirmacion)
                {
                    if (this.password == "")
                    {
                        this.password = txtClave.Text;
                        lblClave.Text = "Repita la contraseña:";
                        txtClave.Text = "";
                    }
                    else
                    {
                        if (this.password != txtClave.Text)
                        {
                            new Dialogos().error("Las contraseñas no coinciden", "Error");
                            this.DialogResult = DialogResult.Cancel;
                        }
                        else {
                            this.DialogResult = DialogResult.OK;
                        }
                        this.Close();
                    }
                } else {
                    this.password = txtClave.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }     
            }
		}

		public string getClave()
		{
            return this.password;
		}

		private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {                
                aceptar_Click(sender, e);
            }
		}

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if (txtClave.Text.Length > 0)
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }
	}
}
