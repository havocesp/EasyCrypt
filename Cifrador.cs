using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.IO;

namespace SensibleInfo
{
    class Cifrador
    {
        private static Random aleatorio = new Random((int)DateTime.Now.Ticks);
        
        public Cifrador() { 
        }

        public string genClave(int longitud)
        {
            StringBuilder strConstructor = new StringBuilder();
            char ch;
            for (int i = 0; i < longitud; i++){
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * aleatorio.NextDouble() + 65)));
                strConstructor.Append(ch);
            }
            return strConstructor.ToString();
        }

        public static Boolean CifrarAES(string strFichero, string strClave)
        {
            Boolean resultado = false;
            FileStream ficheroSalida = null;
            CryptoStream flujoCripto = null;
            FileStream ficheroEntrada = null;
            try
            {
                Rfc2898DeriveBytes clave = new Rfc2898DeriveBytes(SHA1toBase64(strClave), ASCIIEncoding.UTF8.GetBytes(strFichero));
                AesManaged cifradorAES = new AesManaged();
                cifradorAES.KeySize = 256;
                ficheroSalida = new FileStream(String.Concat(strFichero, Principal.APP_EXTENSION), FileMode.Create);
                ICryptoTransform cifrador = cifradorAES.CreateEncryptor(clave.GetBytes(cifradorAES.KeySize / 8), clave.GetBytes(cifradorAES.BlockSize / 8));
                flujoCripto = new CryptoStream(ficheroSalida, cifrador, CryptoStreamMode.Write);
                ficheroEntrada = new FileStream(strFichero, FileMode.Open);
                int dato;
                while ((dato = ficheroEntrada.ReadByte()) != -1)
                {
                    flujoCripto.WriteByte((byte)dato);
                }
                flujoCripto.Flush();

                resultado = true;
            }
            catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
                resultado = false;
            }
            finally
            {
                if (ficheroEntrada != null) ficheroEntrada.Close();
                if (flujoCripto != null) flujoCripto.Close();
                
            }
            return resultado;
        }


        public static Boolean DescifrarAES(string strFicheroCifrado, string strClave)
        {
            Boolean resultado = false;
            FileStream ficheroSalida = null;
            CryptoStream flujoCripto = null;
            FileStream ficheroEntrada = null;
            string strFicheroSalida = null;
            try
            {
               
                strFicheroSalida = Path.Combine(Path.GetDirectoryName(strFicheroCifrado),Path.GetFileNameWithoutExtension(strFicheroCifrado));
                Rfc2898DeriveBytes clave = new Rfc2898DeriveBytes(SHA1toBase64(strClave), ASCIIEncoding.UTF8.GetBytes(strFicheroSalida));
                AesManaged descifradorAES = new AesManaged();
                descifradorAES.KeySize = 256;
                ficheroSalida = new FileStream(strFicheroSalida, FileMode.Create);
                ICryptoTransform descifrador = descifradorAES.CreateDecryptor(clave.GetBytes(descifradorAES.KeySize / 8), clave.GetBytes(descifradorAES.BlockSize / 8));
                flujoCripto = new CryptoStream(ficheroSalida, descifrador, CryptoStreamMode.Write);
                ficheroEntrada = new FileStream(strFicheroCifrado, FileMode.Open);
                int dato;
                while ((dato = ficheroEntrada.ReadByte()) != -1)
                {
                    flujoCripto.WriteByte((byte)dato);
                }
                flujoCripto.Flush();
                ficheroSalida.Flush();

                resultado = true;
            }
            catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
                if (ficheroEntrada != null) ficheroEntrada.Close();
                if(flujoCripto != null) flujoCripto.Close();
               
                
                resultado = false;
            }
            finally
            {
                ficheroEntrada.Close();
                try
                {
                    flujoCripto.Close();
                }
                catch (Exception ex) {
					Console.WriteLine(ex.Message);
                    ficheroSalida.Dispose();
                    ficheroSalida.Close();
                    if (File.Exists(strFicheroSalida)) File.Delete(strFicheroSalida);
           
                }
            }
            return resultado;
        }

        public static string SHA1toBase64(string texto)
        {
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] hashSHA = sha.ComputeHash(ASCIIEncoding.UTF8.GetBytes(texto));
            sha.Dispose();
            return Convert.ToBase64String(hashSHA);
        }
    }
}
