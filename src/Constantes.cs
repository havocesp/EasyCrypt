//
//  Ctes.cs
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

namespace EasyCrypt
{
	/// <summary>
	/// Constantes.
	/// </summary>
	public class Constantes
	{
		/// <summary>
		/// Version de la aplicación.
		/// </summary>
		public static int APP_VERSION = 103;
		/// <summary>
		/// Estensión usada en los ficheros cifrados por esta aplicación.
		/// </summary>
		public static string APP_EXTENSION = ".ssi";
		/// <summary>
		/// Titulo de la aplicación.
		/// </summary>
		public static string APP_NOMBRE = "EasyCrypt";

		/// <summary>
		/// Ejecutable encargado de realizar las actualizaciones.
		/// </summary>
		public static string FICHERO_ACTUALIZADOR = "actualizador.exe";
		public static string FICHERO_VERSION_ACTUAL = "update.txt";

		/// <summary>
		/// Url del blog del creador de este software.
		/// </summary>
		public static string URL_ACTUALIZACIONES = "http://danielumpierrez.es/";
		/// <summary>
		/// Software actualizador automático para la app.
		/// </summary>
		public static string URL_ACTUALIZADOR = URL_ACTUALIZACIONES + FICHERO_ACTUALIZADOR;
		/// <summary>
		/// Ruta a la versión actual del software para su descarga.
		/// </summary>
		public static string URL_VERSION_ACTUAL = URL_ACTUALIZACIONES + FICHERO_VERSION_ACTUAL;
	}
}

