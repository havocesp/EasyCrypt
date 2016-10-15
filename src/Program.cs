//
//  Program.cs
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
using System.Linq;
using System.Windows.Forms;

namespace EasyCrypt
{
	/// <summary>
	/// Clase estática inicial.
	/// </summary>
	static class Program
	{
		/// <summary>
		/// Inicio de la magia.
		/// </summary>
		public static Principal principal;

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			principal = new Principal();
			Application.Run(principal);
		}
	}
}
