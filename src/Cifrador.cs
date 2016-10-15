//
//  Cifrador.cs
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
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.IO;

namespace EasyCrypt
{
	/// <summary>
	/// Clase encargada de las operaciones de cifrado de datos.
	/// </summary>
	class Cifrador
	{
		/// <summary>
		/// Objeto encargado de los tan necesarios números aleatorios en el mundo de la seguridad.
		/// </summary>
		private static Random aleatorio = new Random((int)DateTime.Now.Ticks);

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="EasyCrypt.Cifrador"/>.
		/// </summary>
		public Cifrador()
		{ 
		}

		/// <summary>
		/// Genera una clave aleatoria y la devuelve en formato String.
		/// </summary>
		/// <returns>String con la clave una vez generada</returns>
		/// <param name="longitud">Longitud de la contraseña medida en caracteres.</param>
		public string genClave(int longitud)
		{
			StringBuilder strConstructor = new StringBuilder();
			char ch;
			for (int i = 0; i < longitud; i++) {
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * aleatorio.NextDouble() + 65)));
				strConstructor.Append(ch);
			}
			return strConstructor.ToString();
		}

		/// <summary>
		/// Cifra el fichero que se encuentra en la ruta pasada como argumento usando el algoritmo AES.
		/// </summary>
		/// <returns><c>true</c>, si el fichero fue cigrado correctamente, de lo contrario ... <c>false</c>.</returns>
		/// <param name="strFichero">String fichero.</param>
		/// <param name="strClave">String clave usada para el cifrado.</param>
		public static Boolean CifrarAES(string strFichero, string strClave)
		{
			Boolean resultado = false;
			FileStream ficheroSalida = null;
			CryptoStream flujoCripto = null;
			FileStream ficheroEntrada = null;
			try {
				Rfc2898DeriveBytes clave = new Rfc2898DeriveBytes(SHA1toBase64(strClave), ASCIIEncoding.UTF8.GetBytes(strFichero));
				AesManaged cifradorAES = new AesManaged();
				cifradorAES.KeySize = 256;
				ficheroSalida = new FileStream(String.Concat(strFichero, Constantes.APP_EXTENSION), FileMode.Create);
				ICryptoTransform cifrador = cifradorAES.CreateEncryptor(clave.GetBytes(cifradorAES.KeySize / 8), clave.GetBytes(cifradorAES.BlockSize / 8));
				flujoCripto = new CryptoStream(ficheroSalida, cifrador, CryptoStreamMode.Write);
				ficheroEntrada = new FileStream(strFichero, FileMode.Open);
				int dato;
				while ((dato = ficheroEntrada.ReadByte()) != -1) {
					flujoCripto.WriteByte((byte)dato);
				}
				flujoCripto.Flush();

				resultado = true;
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				resultado = false;
			} finally {
				if (ficheroEntrada != null)
					ficheroEntrada.Close();
				if (flujoCripto != null)
					flujoCripto.Close();
                
			}
			return resultado;
		}

		/// <summary>
		/// Descifra un fichero del cual sabemos la ruta (primer argumento) y la clave con la que fue cifrado.
		/// </summary>
		/// <returns><c>true</c>, if AE was descifrared, <c>false</c> otherwise.</returns>
		/// <param name="strFicheroCifrado">String ruta al fichero cifrado.</param>
		/// <param name="strClave">String clave utilizada en el cifrado.</param>
		public static Boolean DescifrarAES(string strFicheroCifrado, string strClave)
		{
			Boolean resultado = false;
			FileStream ficheroSalida = null;
			CryptoStream flujoCripto = null;
			FileStream ficheroEntrada = null;
			string strFicheroSalida = null;
			try {
               
				strFicheroSalida = Path.Combine(Path.GetDirectoryName(strFicheroCifrado), Path.GetFileNameWithoutExtension(strFicheroCifrado));
				Rfc2898DeriveBytes clave = new Rfc2898DeriveBytes(SHA1toBase64(strClave), ASCIIEncoding.UTF8.GetBytes(strFicheroSalida));
				AesManaged descifradorAES = new AesManaged();
				descifradorAES.KeySize = 256;
				ficheroSalida = new FileStream(strFicheroSalida, FileMode.Create);
				ICryptoTransform descifrador = descifradorAES.CreateDecryptor(clave.GetBytes(descifradorAES.KeySize / 8), clave.GetBytes(descifradorAES.BlockSize / 8));
				flujoCripto = new CryptoStream(ficheroSalida, descifrador, CryptoStreamMode.Write);
				ficheroEntrada = new FileStream(strFicheroCifrado, FileMode.Open);
				int dato;
				while ((dato = ficheroEntrada.ReadByte()) != -1) {
					flujoCripto.WriteByte((byte)dato);
				}
				flujoCripto.Flush();
				ficheroSalida.Flush();

				resultado = true;
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				if (ficheroEntrada != null)
					ficheroEntrada.Close();
				if (flujoCripto != null)
					flujoCripto.Close();
               
                
				resultado = false;
			} finally {
				ficheroEntrada.Close();
				try {
					flujoCripto.Close();
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
					ficheroSalida.Dispose();
					ficheroSalida.Close();
					if (File.Exists(strFicheroSalida))
						File.Delete(strFicheroSalida);
           
				}
			}
			return resultado;
		}

		/// <summary>
		/// Codifica un hash SHA1 en Base64.
		/// </summary>
		/// <returns>La cadena ya codificada en base64.</returns>
		/// <param name="texto">Texto con el hash en SHA1.</param>
		public static string SHA1toBase64(string texto)
		{
			SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
			byte[] hashSHA = sha.ComputeHash(ASCIIEncoding.UTF8.GetBytes(texto));
			sha.Dispose();
			return Convert.ToBase64String(hashSHA);
		}
	}
}
