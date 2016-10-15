//
//  Internet.cs
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
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;


namespace EasyCrypt
{
	/// <summary>
	/// Clase creada para facilitar las tareas relacionadas con la red de redes.
	/// </summary>
    class Internet
    {
		/// <summary>
		/// Obtiene el contenido de una URL pasada como argumento.
		/// </summary>
		/// <returns>Un string con el contenido en bruto de la respuesta.</returns>
		/// <param name="URL">URL de la web que se desea consultar.</param>
        public string getWebResponse(string URL){
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(URL);
            WebResponse response = http.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string content = sr.ReadToEnd();
            sr.Close();
            response.Close();
            return content;
        }

		/// <summary>
		/// Descargars un fichero de una URL pasada como argumento y lo almacena en el fichero
		/// que cuya ruta se especifica en el 2º argumento.
		/// </summary>
		/// <param name="URL">URL del ficheor que se desea descargar.</param>
		/// <param name="rutaCompleta">Ruta completa donde se almacenarán los datos descargados.</param>
        public void descargarFichero(string URL, string rutaCompleta) {
            WebClient web = new WebClient();
            web.DownloadFile(URL, rutaCompleta);
        }
    }
}
