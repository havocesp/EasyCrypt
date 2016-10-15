//
//  Dialogos.cs
//
//  Author:
//       Daniel J. Umpiérrez Del Río
//
//  Copyright (c) 2016 Daniel J. Umpiérrez Del Río
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
using EasyCrypt;
using System.Windows.Forms;

namespace EasyCrypt
{
	/// <summary>
	/// Clase creada para facilitar la interacción con el usuario.
	/// </summary>
	public class Dialogos
	{
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="EasyCrypt.Dialogos"/>.
		/// </summary>
		public Dialogos()
		{
		}

		/// <summary>
		/// Diálogo para solicitud de contraseña al usuario.
		/// </summary>
		/// <param name="pedirConfirmacion">Si vale <c>true</c> solicita la contraseña dos veces (confirmación).</param>
		public string password(bool pedirConfirmacion)
		{
            DlgPassword dlgPass = new DlgPassword(pedirConfirmacion);
			DialogResult resultado = dlgPass.ShowDialog();
			if (resultado != DialogResult.Cancel) {
				return dlgPass.getClave();
			} else {
				return "";
			}
		}

		/// <summary>
		/// Muestra una ventada de error al usuario con el mensaje strMensaje y el titulo strTitulo.
		/// </summary>
		/// <param name="strMensaje">String con el mensaje a mostrar como error.</param>
		/// <param name="strTitulo">String con el titulo de la ventana de diálogo.</param>
		public void error(string strMensaje, string strTitulo)
		{
			MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		///  Muestra una ventada informativa al usuario con el mensaje strMensaje y con el titulo strTitulo.
		/// </summary>
		/// <param name="strMensaje">String con la información que se desea mostrar.</param>
		/// <param name="strTitulo">String con el título de la ventana de diálogo.</param>
        public void info(string strMensaje, string strTitulo)
        {
            MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		/// <summary>
		/// Muestra una ventada de aviso al usuario con el mensaje strMensaje y el titulo strTitulo.
		/// </summary>
		/// <param name="strMensaje">String con el aviso a mostrar.</param>
		/// <param name="strTitulo">String con el título de la ventana de diálogo.</param>
        public void aviso(string strMensaje, string strTitulo)
        {
            MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

		/// <summary>
		/// Muestra una ventada desición (Yes/No) al usuario con el mensaje strMensaje y el titulo strTitulo.
		/// </summary>
		/// <param name="strMensaje">String con el mensaje a mostrar como error.</param>
		/// <param name="strTitulo">String con el título de la ventana de diálogo.</param>
		/// <returns>True si el usuario ha elegido Aceptar / Yes  ... etc.</returns>
		public bool desicion(string strMensaje, string strTitulo)
		{
			return (DialogResult.Yes == MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question));
		}
	}
}

