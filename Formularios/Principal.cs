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
using EasyCrypt.Properties;
using System.Resources;


namespace EasyCrypt
{
	public partial class Principal : Form
	{
		private ImageList lstImagenes = new ImageList();
		private StringBuilder strFallos = new StringBuilder();

		private SysFicheros sysFicheros;
		private Dialogos dialogos;
        private string clave = "";
        private bool modoCifrado = true;

        private int anteriorX;
        private int anteriorY;

		public Principal()
		{

			InitializeComponent();
            this.MouseWheel += new MouseEventHandler(this.setTransparencia);
			try {
				RegistroWindows registro = new RegistroWindows(Constantes.APP_NOMBRE);
				registro.addExplorerElementoMenu(Constantes.APP_EXTENSION , "Descifrar");
                registro.addExplorerElementoMenu("*", "Cifrar");
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
                if (clave.Length < 0) lblBarraAvisoClave.Text = "Recuerde introducir la clave.";
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
					if (modoCifrado) {
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

        void setTransparencia(object sernder, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (this.Opacity <= 1)
                    this.Opacity += 0.1;
            }  else {
                if (this.Opacity >= 0.1)
                    this.Opacity -= 0.1;
            }
             
        }

		private void Principal_Load(object sender, EventArgs e)
		{
            lblBarraAvisoClave.Text = "Seleccione o arrastre ficheros para comenzar.";
            sysFicheros = new SysFicheros();
			dialogos = new Dialogos();
			this.AllowDrop = true;
	
			// Ficheros por la linea de comandos como argumentos (desde menu contextual)
			if (Environment.GetCommandLineArgs().Length == 2) {
				string fichero = Environment.GetCommandLineArgs()[1];
                if (fichero.Contains(Constantes.APP_EXTENSION))
                {
                    this.modoCifrado = false;
                }
                this.clave = dialogos.password(this.modoCifrado);
                addFicheros(fichero);
                realizarAccion(lstFicheros.Items); 
				this.Close();
			}
			sysFicheros.borrarFichero(sysFicheros.combinarRuta(SysFicheros.RUTA_DIR_APP, Constantes.FICHERO_ACTUALIZADOR));
            new Task(comprobarActualizaciones).Start();
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
                if (clave.Length > 0)
                {
                    cifrarToolStripMenuItem.Enabled = true;
                    if (modoCifrado)
                        cifrarToolStripMenuItem.Text = "Cifrar";
                    else
                        cifrarToolStripMenuItem.Text = "Descifrar";
                }
                else
                {
                    cifrarToolStripMenuItem.Enabled = false;
                }
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
            foreach (ListViewItem elemento in ficheros) {
                procesarFichero(elemento);
            }
            return comprobarErrores();
		}

        private bool realizarAccion(ListView.ListViewItemCollection ficheros)
		{
			foreach (ListViewItem elemento in ficheros) {
                procesarFichero(elemento);
			}
            return comprobarErrores();
		}

        private bool procesarFichero(ListViewItem elemento)
        {
            try
            {
                if (modoCifrado)
                {
                    Cifrador.CifrarAES(elemento.Name, this.clave);
                    if (sysFicheros.tieneDatos(elemento.Name + Constantes.APP_EXTENSION))
                        sysFicheros.borrarFichero(elemento.Name);
                    lstFicheros.Items.Remove(elemento);
                    btnProcesar.Enabled = false;
                }
                else
                {
                    Cifrador.DescifrarAES(elemento.Name, this.clave);
                    string nombreFicheroOriginal = sysFicheros.quitaExtension(elemento.Name);

                    if (sysFicheros.tieneDatos(nombreFicheroOriginal))
                    {
                        sysFicheros.borrarFichero(elemento.Name);
                        lstFicheros.Items.Remove(elemento);
                        btnProcesar.Enabled = false;
                    }
                    else
                    {
                        strFallos.Append("Error de contraseña para el fichero: " + elemento.Name);
                    }
                }
            }
            catch (Exception)
            {
                strFallos.AppendLine(elemento.Name);
            }
            return (strFallos.Length > 0);
        }

		private void cifrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lstFicheros.Focus() && lstFicheros.SelectedItems.Count > 0) {
				if (!realizarAccion(lstFicheros.SelectedItems)) {
					strFallos.AppendLine("Error en menu contextual.");
				}
			}
		}

		private bool comprobarErrores()
		{
            bool exito = true;
			if (strFallos.Length > 0) {
                exito = false;
                if (modoCifrado)
					dialogos.error("Se ha producido error al cifrar los siguientes ficheros:\n\n" + strFallos.ToString() + "\n\nCompruebe que tiene acceso a los ficheros o que no están en uso.", "Se han producido errores");
				else {
                    dialogos.error("Se han producidor errores al descifrar los siguientes ficheros\n\n" + strFallos.ToString() + "\n\nCompruebe que tiene acceso a los ficheros o revise la contraseña usada", "Se han producido errores");
				}
			}
			strFallos.Clear();
            return exito;
		}

		private Boolean hayClave()
		{
            return (this.clave.Length > 0);
		}

		private void comprobarActualizaciones()
		{
			Internet web = new Internet();
			try {             
				int codigo = Convert.ToInt32(web.getWebResponse(Constantes.URL_VERSION_ACTUAL));
				if (Constantes.APP_VERSION < codigo) {
					if (dialogos.desicion("Hay una nueva versión disponible.\n\n¿Desea descargarla?", "Actualizar")) {
						string rutaActualizador = sysFicheros.combinarRuta(SysFicheros.RUTA_DIR_APP, Constantes.FICHERO_ACTUALIZADOR);
						web.descargarFichero(Constantes.URL_ACTUALIZADOR, rutaActualizador);
						sysFicheros.ejecutar(rutaActualizador);
						this.Close();
					}
				}
			} catch (Exception ex) {
				dialogos.error(ex.Message, Textos.TEXTO_ERROR);
			}        
		}

        private void btnModo_Click(object sender, EventArgs e)
        {
            dlgFicheros.Reset();
            dlgFicheros.Multiselect = true;
            try {
                if (btnModo.Text == "C&ifrar")
                {
                    btnModo.Text = "D&escifrar";
                    modoCifrado = false;
                    dlgFicheros.Filter = "Ficheros cifrados con SensibleInfo|*" + Constantes.APP_EXTENSION;
                
                    btnModo.Image = global::EasyCrypt.Properties.Resources.CandadoAbierto;
                }
                else
                {
                    btnModo.Text = "C&ifrar";
                    modoCifrado = true;
                    dlgFicheros.Filter = "Todos los ficheros|*";
                   
                    btnModo.Image = global::EasyCrypt.Properties.Resources.CandadoCerrado;
                }
                lstFicheros.Items.Clear();
                lblArrastrar.Visible = true;
                lblBarraAvisoClave.Text = "Modo: '" + btnModo.Text.Replace("&", "") + "' activado";
                btnProcesar.Enabled = false;
                clave = "";
            } 
            catch (Exception ex)
            {
                dialogos.error(ex.Message, "Error");
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (this.clave.Length > 0)
            {
                if (realizarAccion(lstFicheros.Items))
                {
                    lstFicheros.Items.Clear();
                    lblArrastrar.Visible = true;
                    if (modoCifrado)
                        lblBarraAvisoClave.Text = Textos.AVISO_CIFRADO_EXITO;
                    else
                        lblBarraAvisoClave.Text = Textos.AVISO_DESCIFRADO_EXITO;
                }
            }
            else
            {
                dialogos.info("Debe establecer una contraseña antes de proceder","Error");
            }
        }

        private void btnClave_Click(object sender, EventArgs e)
        {
            this.clave = dialogos.password(this.modoCifrado);
            if (clave.Length > 0)
            {
                btnProcesar.Enabled = true;
            }
            else
            {
                btnProcesar.Enabled = false ;
            }
            lblBarraAvisoClave.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Principal_MouseMove(object sender, MouseEventArgs e)
        {
            moverVentana();
        }

        private void lstFicheros_MouseMove(object sender, MouseEventArgs e)
        {
            moverVentana();
        }

        private void moverVentana() {
            if (MouseButtons.HasFlag(MouseButtons.Left))
            {
                this.Left = MousePosition.X - anteriorX;
                this.Top = MousePosition.Y - anteriorY;
                
            }
            else
            {
                anteriorX = (MousePosition.X - (this.Left));
                anteriorY = (MousePosition.Y - (this.Top));
            }
        }

	}
}
