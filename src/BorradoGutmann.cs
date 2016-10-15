using System;
using System.IO;

namespace EasyCrypt.src
{

	/// <summary>
	/// Clase encargada de realizar el borrado seguro de los ficheros mediante el algoritmo de Gutmann.
	/// </summary>
	class BorradoGutmann : Textos
    {
        //establece el tamaño de bloque con el que se va a trabajar. Normalmente los bloques mayores de 8192 afectan al rendimiento.
        internal const int tamBloque = 8192;

        //Inicializa la semilla de números pseudo-aleatorios.
        static Random aleatorio = new Random();

		/// <summary>
		/// Borra de forma "segura" el contenido del fichero cuya ruta se pasa como argumento.
		/// </summary>
		/// <returns><c>true</c>, si el fichero fue borrado correctamente, de lo contrario<c>false</c>.</returns>
		/// <param name="fichero">Ruta al fichero que se desea eliminar.</param>

		// TO-DO: cambiar el nombre al fichero con uno aleatorio y moverlo de sitio (varias veces)	
        public bool borradoSeguroFichero(string fichero)
        {
            bool resultado = false;
			if (fichero != Textos.BL && File.Exists(fichero))
            {
                    FileInfo infoFichero = new FileInfo(fichero);

                    byte byteSelect = 0x00;

					//Algoritmo de borrado seguro Gutman (35 pasadas)
                    for (int j = 0; j < 35; j++)
                    {
                        switch (j)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                                randomBytePass(infoFichero);
                                break;
                            case 4:
                                bytePass(infoFichero, 0x55);
                                break;
                            case 5:
                                bytePass(infoFichero, 0xaa);
                                break;
                            case 6:
                                gutmannBytePass(infoFichero, 0x92, 0x49, 0x24);
                                break;
                            case 7:
                            case 25:

                                gutmannBytePass(infoFichero, 0x49, 0x24, 0x92);
                                break;
                            case 8:
                            case 26:

                                gutmannBytePass(infoFichero, 0x24, 0x92, 0x49);
                                break;
                            case 9:
                            case 27:
                                bytePass(infoFichero, byteSelect);
                                break;
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                                byteSelect += 0x11;
                                bytePass(infoFichero, byteSelect);
                                break;
                            case 24:

                                byteSelect += 0x11;
                                bytePass(infoFichero, byteSelect);
                                byteSelect = 0x00;
                                break;
                            case 28:
                                gutmannBytePass(infoFichero, 0x6d, 0xb6, 0xdb);
                                break;
                            case 29:
                                gutmannBytePass(infoFichero, 0xb6, 0xdb, 0x6d);
                                break;
                            case 30:
                                gutmannBytePass(infoFichero, 0xdb, 0x6d, 0xb6);
                                break;
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                                randomBytePass(infoFichero);
                                break;
                        }
                    }
					// Tras realizar las pasadas borramos el fichero de forma normal.
                    File.Delete(infoFichero.FullName);
                    resultado = true;
                }
            
            return resultado;
        }

		/// <summary>
		/// Sobrescribre el fichero con el valor uByte.
		/// </summary>
		/// <param name="fileInf">Objeto FileInfo con información del fichero que se esta eliminando.</param>
		/// <param name="useByte">Valor con el que se hara la pasada sobre el fichero.</param>
		private void bytePass(FileInfo infoFichero, byte uByte)
        {          
            long tamFichero = infoFichero.Length;
            int ultimoBloque = (int)(tamFichero % tamBloque);
            byte[] bytes = new byte[tamBloque];
            byte[] bytesUltimoBloque = new byte[ultimoBloque];
            long modWrite = (int)(tamFichero / tamBloque);

			// Pasada en sentido
            for (int i = 0; i < tamBloque; i++)
            {
                bytes[i] = uByte;
            }

			// Y ahora en el inverso
            for (int i = 0; i < ultimoBloque; i++)
            {
                bytesUltimoBloque[i] = uByte;
            }

            Stream st = File.OpenWrite(infoFichero.FullName);
            for (long i = 0; i < modWrite; i++)
            {
                st.Write(bytes, 0, tamBloque);
                st.Flush();
            }
            st.Write(bytesUltimoBloque, 0, ultimoBloque);
            st.Close();
            st.Dispose();
        }

        private void gutmannBytePass(FileInfo infoFichero, byte byte2write1, byte byte2write2, byte byte2write3)
        {
            long tamFichero = infoFichero.Length;
            int ultimoBloque = (int)(tamFichero % tamBloque);
            byte[] bytes = new byte[tamBloque];
            byte[] bytesUltimoBloque = new byte[ultimoBloque];
            long modWrite = (int)(tamFichero / tamBloque);
            int selectByte = 1;
            for (int i = 0; i < tamBloque; i++)
            {
                switch (selectByte)
                {
                    case 1:
                        bytes[i] = byte2write1;
                        selectByte = 2;
                        break;
                    case 2:
                        bytes[i] = byte2write2;
                        selectByte = 3;
                        break;
                    case 3:
                        bytes[i] = byte2write3;
                        selectByte = 1;
                        break;
                }
            }
            selectByte = 1;
            for (int i = 0; i < ultimoBloque; i++)
            {
                switch (selectByte)
                {
                    case 1:
                        bytesUltimoBloque[i] = byte2write1;
                        selectByte = 2;
                        break;
                    case 2:
                        bytesUltimoBloque[i] = byte2write2;
                        selectByte = 3;
                        break;
                    case 3:
                        bytesUltimoBloque[i] = byte2write3;
                        selectByte = 1;
                        break;
                }
            }

            Stream st = File.OpenWrite(infoFichero.FullName);
            for (long i = 0; i < modWrite; i++)
            {
                st.Write(bytes, 0, tamBloque);
                st.Flush();
            }
            st.Write(bytesUltimoBloque, 0, ultimoBloque);
            st.Close();
            st.Dispose();
        }


        private void randomBytePass(FileInfo fichero)
        {
         
            long tamFichero = fichero.Length;
            int ultimoBloque = (int)(tamFichero % tamBloque);
            byte[] bytes = new byte[tamBloque];
            byte[] bytesUltimoBloque = new byte[ultimoBloque];
            long modWrite = (int)(tamFichero / tamBloque);
            for (int i = 0; i < tamBloque; i++)
            {
                bytes[i] = Convert.ToByte(aleatorio.Next(255));
            }
            for (int i = 0; i < ultimoBloque; i++)
            {
                bytesUltimoBloque[i] = Convert.ToByte(aleatorio.Next(255));
            }

          
            Stream st = File.OpenWrite(fichero.FullName);
            for (long i = 0; i < modWrite; i++)
            {
                st.Write(bytes, 0, tamBloque);
                st.Flush();
            }
            st.Write(bytesUltimoBloque, 0, ultimoBloque);
            st.Close();
            st.Dispose();
        }

    }
}
