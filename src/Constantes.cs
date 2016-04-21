//
//  Ctes.cs
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

namespace EasyCrypt
{
	public class Constantes
	{
		public static int APP_VERSION = 103;

		public static string APP_EXTENSION = ".ssi";
		public static string APP_NOMBRE = "EasyCrypt";

		public static string FICHERO_ACTUALIZADOR = "actualizador.exe";
		public static string FICHERO_VERSION_ACTUAL = "update.txt";

		public static string URL_ACTUALIZACIONES = "http://danielumpierrez.es/";
		public static string URL_ACTUALIZADOR = URL_ACTUALIZACIONES + FICHERO_ACTUALIZADOR;
		public static string URL_VERSION_ACTUAL = URL_ACTUALIZACIONES + FICHERO_VERSION_ACTUAL;
	}
}

