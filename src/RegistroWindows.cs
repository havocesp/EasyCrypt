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
		private string strRutaRegistro = "Software\\Classes\\";
		private string progID;

		public RegistroWindows(string progID)
		{
			this.progID = progID;
			RegistryKey regProgID = Registry.CurrentUser.CreateSubKey(strRutaRegistro + progID);
			regProgID.SetValue("", "Cifrador de ficheros portable y de fácil uso.", RegistryValueKind.String); 
			regProgID.Close(); 
		}

		public void addExtensionFichero(string extension)
		{
			RegistryKey regAddExtension = Registry.CurrentUser.CreateSubKey(strRutaRegistro + extension);
			regAddExtension.SetValue("", progID); 
			regAddExtension.Close();
		}

		public void addExplorerElementoMenu(string extensionFichero, string nombreElementoMenu)
		{
			RegistryKey regElementoMenu = Registry.CurrentUser.CreateSubKey(strRutaRegistro + "\\" + extensionFichero + "\\shell\\" + nombreElementoMenu + "\\command");
			regElementoMenu.SetValue("", "\"" + Application.ExecutablePath + "\"" + "\"%1\"");
			regElementoMenu.Close();
		}

		public void asociarExtensionConIconoDeAplicacion()
		{
			RegistryKey regIcono = Registry.CurrentUser.CreateSubKey(strRutaRegistro + progID + "\\DefaultIcon");
			regIcono.SetValue("", Application.ExecutablePath + ",0"); 
		}

	}
}
