//
//  RegistroWindows.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace EasyCrypt
{
	/// <summary>
	/// Clase creada para facilitar las operaciones con el registro de Windows.
	/// </summary>
	class RegistroWindows
	{
		/// <summary>
		/// Constante con una cadena en blanco.
		/// </summary>
		private const String BL = "";
		/// <summary>
		/// Descipción corta de EasyCrypt para ayudar a identificar la aplicación a los usuarios.
		/// </summary>
		private const String DESCRIPCION = "Cifrador de ficheros portable y de fácil uso.";
		/// <summary>
		/// Contiene la ruta base del registro que se usará.
		/// </summary>
		private string strRutaRegistro = "Software\\Classes\\";
		/// <summary>
		/// Almacena un id único de nuestro programa.
		/// </summary>
		private string progID;

		/// <summary>
		/// Initializes a new instance of the <see cref="EasyCrypt.RegistroWindows"/> class.
		/// </summary>
		/// <param name="progID">Prog I.</param>
		public RegistroWindows(string progID)
		{
			this.progID = progID;
			RegistryKey regProgID = Registry.CurrentUser.CreateSubKey(strRutaRegistro + progID);
			regProgID.SetValue(BL, DESCRIPCION, RegistryValueKind.String); 
			regProgID.Close(); 
		}

		/// <summary>
		/// Añade una extensión de fichero al registro con vistas a que sea asocida con nuestra aplicación (MIME/Type)
		/// </summary>
		/// <param name="extension">Extension que deseamos registrar (.esc en este caso)</param>
		public void addExtensionFichero(string extension)
		{
			RegistryKey regAddExtension = Registry.CurrentUser.CreateSubKey(strRutaRegistro + extension);
			regAddExtension.SetValue(BL, progID); 
			regAddExtension.Close();
		}

		/// <summary>
		/// Añade una acción al menú contextual del explorar de archivos de windows.
		/// </summary>
		/// <param name="extensionFichero">Extension fichero relacionada.</param>
		/// <param name="nombreElementoMenu">Nombre que deseamos para el elemento menu que vamos a crear.</param>
		public void addExplorerElementoMenu(string extensionFichero, string nombreElementoMenu)
		{
			RegistryKey regElementoMenu = Registry.CurrentUser.CreateSubKey(strRutaRegistro + "\\" + extensionFichero + "\\shell\\" + nombreElementoMenu + "\\command");
			regElementoMenu.SetValue(BL, "\"" + Application.ExecutablePath + "\"" + "\"%1\"");
			regElementoMenu.Close();
		}

		/// <summary>
		/// Asocia una extension con icono de aplicacion.
		/// </summary>
		public void asociarExtensionConIconoDeAplicacion()
		{
			RegistryKey regIcono = Registry.CurrentUser.CreateSubKey(strRutaRegistro + progID + "\\DefaultIcon");
			regIcono.SetValue(BL, Application.ExecutablePath + ",0"); 
		}
	}
}
