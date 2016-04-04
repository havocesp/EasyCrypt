//
//  Dialogos.cs
//
//  Author:
//       havoc <>
//
//  Copyright (c) 2016 havoc
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
	public class Dialogos
	{

		public Dialogos()
		{
		}

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

		public void error(string strMensaje, string strTitulo)
		{
			MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

        public void info(string strMensaje, string strTitulo)
        {
            MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void aviso(string strMensaje, string strTitulo)
        {
            MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

		public bool desicion(string strMensaje, string strTitulo)
		{
			return (DialogResult.Yes == MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question));
		}
	}
}

