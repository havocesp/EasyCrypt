//
//  DlgPassword.cs
//
//  Author:
//       Daniel Umpiérrez Del Río
//
//  Copyright (c) 2016 Daniel Umpiérrez Del Río
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
	/// <summary>
	/// Diálogo para temas relacionados con contraseñas.
	/// </summary>
	public partial class DlgPassword : Form
	{
		private string password = Textos.BL;
        bool solicitarConfirmacion = false;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="EasyCrypt.DlgPassword"/>.
		/// </summary>
		/// <param name="solicitarConfirmacion"><c>true</c> si se desea solicitar confirmacion.</param>
		public DlgPassword(bool solicitarConfirmacion = false)
		{
			InitializeComponent();
            this.solicitarConfirmacion = solicitarConfirmacion;
		}

		/// <summary>
		/// Callback ejecutado cuando el usuario hace clic en le botón aceptar.
		/// </summary>
		/// <param name="sender">Objeto que llama a este callback.</param>
		/// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
		private void aceptar_Click(object sender, EventArgs e)
		{
            if (txtClave.Text.Length > 0)
            {
                if (this.solicitarConfirmacion)
                {
                    if (this.password == Textos.BL)
                    {
                        this.password = txtClave.Text;
                        lblClave.Text = "Repita la contraseña:";
                        txtClave.Text = Textos.BL;
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

		/// <summary>
		/// Getter del atributo password.
		/// </summary>
		/// <returns>El atributo password.</returns>
		public string getClave()
		{
            return this.password;
		}

		/// <summary>
		/// Callback ejecutado cuando se pulsa la tecla ENTER.
		/// </summary>
		/// <param name="sender">Objeto que llama a este callback.</param>
		/// <param name="e"><see cref="System.Windows.Forms.KeyEventArgs"/> </param>
		private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {                
                aceptar_Click(sender, e);
            }
		}
		/// <summary>
		/// Callback ejecutado cuando el cuadro de texto txtClave cambia en su contenido, 
		/// habilitando o deshabiliandolo según este vacío o no.
		/// </summary>
		/// <param name="sender">Objeto que llama a este callback.</param>
		/// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
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
