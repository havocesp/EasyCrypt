using System;
using System.IO;

namespace EasyCrypt.src
{
    class BorradoGutmann
    {
        //set the block size we going to work with. Setting it higher sometimes impacts negatively on the performance.
        internal const int tamBloque = 8192;

        //Initialize random number generation
        static Random aleatorio = new Random();

        public bool borradoSeguroFichero(string fichero)
        {
            bool resultado = false;
            if (fichero != "")
            {
                if (File.Exists(fichero))
                {
                   
                    FileInfo infoFichero = new FileInfo(fichero);

                    byte byteSelect = 0x00;

                    //Algoritmo de borrado seguro Gutman
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

                    File.Delete(infoFichero.FullName);
                    resultado = true;
                }
            }
            return resultado;
        }

        private void bytePass(FileInfo fileInf, byte useByte)
        {
          
            long tamFichero = fileInf.Length;
            int ultimoBloque = (int)(tamFichero % tamBloque);
            byte[] bytes = new byte[tamBloque];
            byte[] bytesUltimoBloque = new byte[ultimoBloque];
            long modWrite = (int)(tamFichero / tamBloque);
            for (int i = 0; i < tamBloque; i++)
            {
                bytes[i] = useByte;
            }
            for (int i = 0; i < ultimoBloque; i++)
            {
                bytesUltimoBloque[i] = useByte;
            }

            Stream st = File.OpenWrite(fileInf.FullName);
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
