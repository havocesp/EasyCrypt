using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace EasyCrypt
{

	class RegistroWindows
	{
        
		public void crearMenuContextualUsuarioActual(string extensionFichero, string nombreElementoMenu)
		{
      
			RegistryKey regExtension = null;
			RegistryKey regAplicacion = null;
			RegistryKey regIcono = null;

			//RegistryKey regDescifrar = null;
			RegistryKey regCifrar = null;
			RegistryKey regComandoDescifrar = null;
			string strRutaRegistro = "Software\\Classes\\";
			string rutaRegistroExtension = strRutaRegistro + extensionFichero;
			string rutaRegistroAplicacion = strRutaRegistro + "DanielUmpierrez.SensibleInfo";
			string rutaRegistroIcono = rutaRegistroAplicacion + "\\DefaultIcon";
			//string rutaRegistroDescifrar = rutaRegistroAplicacion + "\\shell\\Descifrar\\command";
			string rutaRegistroCifrar = strRutaRegistro + "\\*\\" + "\\shell\\Cifrar\\command";
			string rutaRegistroComandoDescifrar = rutaRegistroAplicacion + "\\shell\\Descifrar\\command";
			regExtension = Registry.CurrentUser.CreateSubKey(rutaRegistroExtension + "\\");
			regExtension.SetValue(Textos.BL, "DanielUmpierrez.SensibleInfo", RegistryValueKind.String);
			regAplicacion = Registry.CurrentUser.CreateSubKey(rutaRegistroAplicacion);
			regAplicacion.SetValue(Textos.BL, "Ficheros cifrados por SensibleInfo");
			regIcono = Registry.CurrentUser.CreateSubKey(rutaRegistroIcono);
			regIcono.SetValue(Textos.BL, Application.ExecutablePath + ",0");
			//regDescifrar = Registry.CurrentUser.CreateSubKey(rutaRegistroDescifrar);
			regComandoDescifrar = Registry.CurrentUser.CreateSubKey(rutaRegistroComandoDescifrar);
			regComandoDescifrar.SetValue(Textos.BL, "\"" + Application.ExecutablePath + "\" \"%1\"");
			regCifrar = Registry.CurrentUser.CreateSubKey(rutaRegistroCifrar);
			regCifrar.SetValue(Textos.BL, "\"" + Application.ExecutablePath + "\" \"%1\"");

		}
	}
}
