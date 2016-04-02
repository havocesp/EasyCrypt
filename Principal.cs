using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Threading.Tasks;
using EasyCrypt;


namespace EasyCrypt
{
	public partial class Principal : Form
	{
		






		private ImageList lstImagenes = new ImageList();
		private StringBuilder strFallos = new StringBuilder();

		private SysFicheros sysFicheros;
		private Dialogos dialogos;

		public Principal()
		{

			InitializeComponent();

			try {
				RegistroWindows registro = new RegistroWindows();
				registro.crearMenuContextualUsuarioActual(".ssi", "Descifrar");
				registro.crearMenuContextualUsuarioActual("*", "Cifrar");
			} catch (Exception ex) { 
				MessageBox.Show(ex.Message);
			}

			dlgFicheros.InitialDirectory = SysFicheros.RUTA_MIPC;
			lstImagenes.ImageSize = new Size(48, 48);
			lstImagenes.ColorDepth = ColorDepth.Depth32Bit;
			lstImagenes.Images.Add(Constantes.APP_EXTENSION, this.Icon);
			lstFicheros.View = View.LargeIcon;
			lstFicheros.LargeImageList = lstImagenes;
		}

       

		private void btnSeleccionarFicheros_Click(object sender, EventArgs e)
		{
            
			DialogResult resultadoDlg = dlgFicheros.ShowDialog();
			if (resultadoDlg != DialogResult.Cancel && dlgFicheros.FileNames.Length > 0) {
				addFicheros(dlgFicheros.FileNames);
				lblArrastrar.Visible = false;
				intentarActivarBotonCifrado();
			}
		}

		private void addFicheros(string fichero)
		{ 
			String[] ficheros = { fichero };
			this.addFicheros(ficheros);
		}

		private void addFicheros(string[] ficheros)
		{

			foreach (string fichero in ficheros) {
				FileInfo infoFichero = new FileInfo(fichero);
				if (!lstFicheros.Items.ContainsKey(infoFichero.FullName)) {
					// icono por defecto
					System.Drawing.Icon icono = SystemIcons.WinLogo;
					lstFicheros.BeginUpdate();
					// si la accion es cifrar
					if (modoCifrado()) {
						// mientras no tenga extensión .cet (ya que es un archivo cifrado)
						if (infoFichero.Extension != Constantes.APP_EXTENSION) {
							// si no tenemos el icono en nuestra lista de par de valores extension / icono (lstImagenes)
							if (!lstImagenes.Images.ContainsKey(infoFichero.Extension)) {
								icono = System.Drawing.Icon.ExtractAssociatedIcon(infoFichero.FullName);
								lstImagenes.Images.Add(infoFichero.Extension, icono);
							}
							// insertamos el fichero con el FullName como nombre de clave
							lstFicheros.Items.Insert(lstFicheros.Items.Count, infoFichero.FullName, infoFichero.Name, infoFichero.Extension);
						}
					} else {
						if (infoFichero.Extension == Constantes.APP_EXTENSION) {
							icono = this.Icon;
							if (!lstImagenes.Images.ContainsKey(infoFichero.Extension))
								lstImagenes.Images.Add(infoFichero.Extension, icono);
							lstFicheros.Items.Insert(lstFicheros.Items.Count, infoFichero.FullName, infoFichero.Name, infoFichero.Extension);
						}
					}
					lstFicheros.EndUpdate();
				}
			}
		}

		private void Principal_Load(object sender, EventArgs e)
		{
			sysFicheros = new SysFicheros();
			dialogos = new Dialogos();
			this.AllowDrop = true;
			cmbAccion.SelectedIndex = 0;
			cambiarLabels();
			lblBarraAvisoClave.Text = "";
			// Ficheros por la linea de comandos como argumentos (desde menu contextual)
			if (Environment.GetCommandLineArgs().Length == 2) {
				string fichero = Environment.GetCommandLineArgs()[1];
				if (fichero.Contains(Constantes.APP_EXTENSION)) {
					cmbAccion.SelectedIndex = 1;
					txtClave.Text = dialogos.password("Introduzca la clave: ", "Descifrar");
					if (txtClave.Text != null) {
						addFicheros(Environment.GetCommandLineArgs()[1]);
						realizarAccion(lstFicheros.Items);
					}
				} else {
					string clave = dialogos.password("Introduzca la clave: ", "Aceptar");
					if (clave != dialogos.password("Vuelva a introducir la clave: ", "Aceptar")) {
						dialogos.error("Las contraseñas no coinciden");
						this.Close();

					} else {
						txtClave.Text = clave;
						addFicheros(Environment.GetCommandLineArgs()[1]);
						realizarAccion(lstFicheros.Items);
					}                    
				}
				this.Close();
			}
			sysFicheros.borrarFichero(sysFicheros.combinarRuta(SysFicheros.RUTA_DIR_APP, Constantes.FICHERO_ACTUALIZADOR));
			new Task(comprobarActualizaciones).Start();
		}

		private void cmbAccion_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!modoCifrado()) {
				dlgFicheros.Filter = "Ficheros cifrados con SensibleInfo|*" + Constantes.APP_EXTENSION;
			} else {
				dlgFicheros.Filter = "Todos los ficheros|*.*";
			}
			lstFicheros.Items.Clear();
			lblArrastrar.Visible = true;
			cambiarLabels();
			intentarActivarBotonCifrado();
		}

		private void cambiarLabels()
		{
			lblClave.Text = "Contraseña para " + cmbAccion.Text.ToLower() + ":";
			lblFicheros.Text = "Lista de ficheros a " + cmbAccion.Text.ToLower() + ":";
			cbBorrarFicheros.Text = "Borrar ficheros originales tras " + cmbAccion.Text.ToLower() + ".";
			btnCifrar.Text = cmbAccion.Text;
		}

		private void btnCifrar_Click(object sender, EventArgs e)
		{
			if (realizarAccion(lstFicheros.Items)) {
				lstFicheros.Items.Clear();
				lblArrastrar.Visible = true;
			}
		}

		private void txtClave_TextChanged(object sender, EventArgs e)
		{
			intentarActivarBotonCifrado();

			if (hayClave() && modoCifrado()) {
				lblBarraAvisoClave.ForeColor = Color.DarkRed;
				lblBarraAvisoClave.Text = Textos.AVISO_CLAVE;
			}
			if (!hayClave()) {
				lblBarraAvisoClave.Text = "";
			}
		}

		private void intentarActivarBotonCifrado()
		{
			if (lstFicheros.Items.Count > 0 && hayClave())
				btnCifrar.Enabled = true;
			else
				btnCifrar.Enabled = false;
		}


		private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AcercaDe().ShowDialog();
		}

		private void Principal_DragDrop(object sender, DragEventArgs e)
		{
			string[] lstFicheros = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (lstFicheros != null) {
				if (lstFicheros.Length > 0) {
					lblArrastrar.Visible = false;
					foreach (string elemento in lstFicheros) {
						if (sysFicheros.existeDirectorio(lstFicheros[0])) {
							addFicheros(Directory.GetFiles(elemento, "*", SearchOption.AllDirectories));
						} else {
                      
							addFicheros(elemento);
						}
					}                  
					intentarActivarBotonCifrado();
					btnCifrar.Focus();
				}
			}

		}

		private void Principal_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void lstFicheros_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && lstFicheros.SelectedItems.Count > 0) {
				foreach (ListViewItem elemento in lstFicheros.SelectedItems) {
					lstFicheros.Items.Remove(elemento);
				}
			}
		}

		private void lstFicheros_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right && lstFicheros.SelectedItems.Count > 0) {
				if (modoCifrado())
					cifrarToolStripMenuItem.Text = "Cifrar";
				else
					cifrarToolStripMenuItem.Text = "Descifrar";
				menuListaFicheros.Show(Control.MousePosition.X, Control.MousePosition.Y);
			}
		}

		private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lstFicheros.Focus() && lstFicheros.SelectedItems.Count > 0) {
				foreach (ListViewItem elemento in lstFicheros.SelectedItems) {
					lstFicheros.Items.Remove(elemento);
				}
			}
		}

		private bool realizarAccion(ListView.SelectedListViewItemCollection  ficheros)
		{
			return this.realizarAccion(ficheros);
		}

		private bool realizarAccion(ListView.ListViewItemCollection ficheros)
		{
			bool exito = false;
			barraProgreso.Maximum = ficheros.Count + 1;
			barraProgreso.Visible = true;
			try {
				foreach (ListViewItem elemento in ficheros) {
					if (modoCifrado()) {
						Cifrador.CifrarAES(elemento.Name, txtClave.Text);
						if (sysFicheros.tieneDatos(elemento.Name + Constantes.APP_EXTENSION) && cbBorrarFicheros.Checked)
							sysFicheros.borrarFichero(elemento.Name);
						lstFicheros.Items.Remove(elemento);

					} else {
						Cifrador.DescifrarAES(elemento.Name, txtClave.Text);
						string nombreFicheroOriginal = sysFicheros.quitaExtension(elemento.Name);
						if (sysFicheros.existeFichero(nombreFicheroOriginal)) {
							if (sysFicheros.tieneDatos(nombreFicheroOriginal)) { 
								if (cbBorrarFicheros.Checked)
									sysFicheros.borrarFichero(elemento.Name);
								lstFicheros.Items.Remove(elemento);
							}
						} else {
							strFallos.Append("Error de contraseña para el fichero: " + elemento.Name);
						}
					}
					barraProgreso.Value++;
				}

			} catch (Exception ex) {
				strFallos.AppendLine(ex.Message);
				exito = false;
			} finally {
				barraProgreso.Visible = false;
			}
			comprobarErrores();

			return exito;
		}

		private void cifrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lstFicheros.Focus() && lstFicheros.SelectedItems.Count > 0) {
				if (!realizarAccion(lstFicheros.SelectedItems)) {
					strFallos.AppendLine("Error en menu contextual.");
				}
			}
		}

		private void comprobarErrores()
		{

			if (hayErrores()) {
				if (modoCifrado())
					MessageBox.Show("Se ha producido error al cifrar los siguientes ficheros:\n\n" + strFallos.ToString() + "\n\nCompruebe la clave o si el fichero esta en uso.", "Se han producido errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else {
					if (strFallos.Length == lstFicheros.Items.Count)
						MessageBox.Show("Es posible que la contraseña no sea válida, por favor, intentelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					else
						MessageBox.Show("Se ha producido error al cifrar los siguientes ficheros:\n\n" + strFallos.ToString() + "\n\nCompruebe la clave o si el fichero esta en uso.", "Se han producido errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else {
				intentarActivarBotonCifrado();
                
				if (modoCifrado())
					lblBarraAvisoClave.Text = Textos.AVISO_CIFRADO_EXITO;
				else
					lblBarraAvisoClave.Text = Textos.AVISO_DESCIFRADO_EXITO;
			}

			strFallos.Clear();

		}

		public Boolean modoCifrado()
		{
			return (cmbAccion.SelectedIndex == 0);
		}

		private Boolean hayClave()
		{
			return (txtClave.Text.Length > 0);
		}

		private Boolean hayErrores()
		{
			return (strFallos.Length > 0);
		}

		private void txtClave_Leave(object sender, EventArgs e)
		{
			if (modoCifrado() && txtClave.Text.Length > 0) {
				if (txtClave.Text != dialogos.password("Repita la contraseña: ", "Aceptar")) {
					txtClave.Text = "";
					dialogos.error("Las contraseñas no coinciden"); 
				}
			}
		}

		private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Task(comprobarActualizaciones).Start();
		}

		private void comprobarActualizaciones()
		{
			Internet web = new Internet();
			try {             
				int codigo = Convert.ToInt32(web.getWebResponse(Constantes.URL_VERSION_ACTUAL));
				if (codigo > Constantes.APP_VERSION) {
					if (dialogos.desicion("Hay una nueva versión disponible.\n\n¿Desea descargarla?", "Actualizar")) {
						string rutaActualizador = sysFicheros.combinarRuta(SysFicheros.RUTA_DIR_APP, Constantes.FICHERO_ACTUALIZADOR);
						web.descargarFichero(Constantes.URL_ACTUALIZADOR, rutaActualizador);
						sysFicheros.ejecutar(rutaActualizador);
						this.Close();
					}
				}
			} catch (Exception ex) {
				dialogos.error(ex.Message);
			}        
		}
	}
}
