//
//  Principal.cs
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
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace EasyCrypt {

    /// <summary>
    /// Interfaz principal de la aplicación.
    /// </summary>
    public partial class Principal : Form {

        /// <summary>
        /// Lista de imágenes usadas.
        /// </summary>
        private ImageList lstImagenes = new ImageList();

        /// <summary>
        /// En esta colección se guardarán los fallos ocurridos durante el proceso con el fin
        /// de mostrarlos todos juntos al final y no molestar al usuario cada dos por tres con diálogos de error.
        /// </summary>
        private StringBuilder strFallos = new StringBuilder();

        /// <summary>
        /// Objeto para lidiar con ficheros y similares.
        /// </summary>
        private SysFicheros sysFicheros;

        /// <summary>
        /// Objecto que facilita la interacción con el usuario mediante ventanas de diálogo.
        /// </summary>
        private Dialogos dialogos;

        /// <summary>
        /// Almacena la clave introducida por el usuario.
        /// </summary>
        private string clave = Textos.BL;

        /// <summary>
        /// Este 'interruptor' nos permite saber en todo momento si estamos en modo cifrar o descifrar.
        /// </summary>
        private bool modoCifrado = true;

        private int anteriorX;
        private int anteriorY;
        /// <summary>
        /// Si esta en true es porque el comprobador de actualizaciones dio positivo en su búsqueda.
        /// </summary>
        private bool hayActualizacion = false;

        /// <summary>
        /// Incializa una nueva instancia de la clase <see cref="EasyCrypt.Principal"/>.
        /// </summary>
        public Principal() {
            //Inicializa los componentes.
            InitializeComponent();
            // Establece un callback en tiempo de ejecución.
            MouseWheel += new MouseEventHandler(setTransparencia_MouseWheel);
            // Modificamos el registro para asociar la extensión .ssi a esta aplicación y para crear
            // elementos en el menú contextual de exlorador de archivos de windows.
            try {
                RegistroWindows registro = new RegistroWindows(Constantes.APP_NOMBRE);
                registro.addExplorerElementoMenu(Constantes.APP_EXTENSION, "Descifrar");
                registro.addExplorerElementoMenu("*", Textos.TEXTO_CIFRAR);
            } catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }

            dlgFicheros.InitialDirectory = SysFicheros.RUTA_MIPC;

            lstImagenes.ImageSize = new Size(48, 48);
            lstImagenes.ColorDepth = ColorDepth.Depth32Bit;
            lstImagenes.Images.Add(Constantes.APP_EXTENSION, Icon);

            lstFicheros.View = View.LargeIcon;
            lstFicheros.LargeImageList = lstImagenes;
        }

        /// <summary>
        /// Callback del botón <c>btnSeleccionarFicheros</c> que abre el cuadro de diálogo que permite añadir mas ficheros a la
        /// lista de ficheros por tratar.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
        private void btnSeleccionarFicheros_Click(object sender, EventArgs e) {           
            DialogResult resultadoDlg = dlgFicheros.ShowDialog();
            if (resultadoDlg != DialogResult.Cancel && dlgFicheros.FileNames.Length > 0) {
                addFicheros(dlgFicheros.FileNames);
                lblArrastrar.Visible = false;
                if (clave.Length < 0)
                    lblBarraAvisoClave.Text = "Recuerde introducir la clave.";
            }
        }

        /// <summary>
        /// Sobrecarga del método <c>addFicheros</c> para aceptar un solo fichero como argumento.
        /// </summary>
        /// <param name="fichero">Fichero a agregar al listado.</param>
        private void addFicheros(string fichero) {
            string[] ficheros = { fichero };
            addFicheros(ficheros);
        }

        /// <summary>
        /// Agrega ficheros en "masa" al listado de archivos pendientes de tratar.
        /// </summary>
        /// <param name="ficheros">Array de string con los ficheros a agregar.</param>
        private void addFicheros(string[] ficheros) {

            foreach (string fichero in ficheros) {
                FileInfo infoFichero = new FileInfo(fichero);
                if (!lstFicheros.Items.ContainsKey(infoFichero.FullName)) {
                    // icono por defecto
                    Icon icono = SystemIcons.WinLogo;
                    lstFicheros.BeginUpdate();
                    // si la accion es cifrar
                    if (modoCifrado) {
                        // mientras no tenga extensión .ssi (ya que es un archivo cifrado)
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
                            icono = Icon;
                            if (!lstImagenes.Images.ContainsKey(infoFichero.Extension))
                                lstImagenes.Images.Add(infoFichero.Extension, icono);
                            lstFicheros.Items.Insert(lstFicheros.Items.Count, infoFichero.FullName, infoFichero.Name, infoFichero.Extension);
                        }
                    }
                    lstFicheros.EndUpdate();
                }
            }
        }

        /// <summary>
        /// Callback que se ejecuta al mover la rueda del ratón sobre la ventana, cambiando la transparencia de la misma.
        /// </summary>
        /// <param name="sernder">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.MouseEventArgs"/></param>
        void setTransparencia_MouseWheel(object sernder, MouseEventArgs e) {
            if (e.Delta > 0) {
                if (Opacity <= 1)
                    Opacity += 0.1;
            } else {
                if (Opacity >= 0.1)
                    Opacity -= 0.1;
            }
        }

        /// <summary>
        /// Callback ejecutado al mostrarse la ventana por primera vez.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
        private void Principal_Load(object sender, EventArgs e) {
            lblBarraAvisoClave.Text = "Seleccione o arrastre ficheros para comenzar.";
            sysFicheros = new SysFicheros();
            dialogos = new Dialogos();
            AllowDrop = true;
	
            // Ficheros por la línea de comandos como argumentos (desde menú contextual)
            if (Environment.GetCommandLineArgs().Length == 2) {
                string fichero = Environment.GetCommandLineArgs()[1];
                if (fichero.Contains(Constantes.APP_EXTENSION)) {
                    modoCifrado = false;
                }
                clave = dialogos.password(modoCifrado);
                addFicheros(fichero);
                realizarAccion(lstFicheros.Items);
                Close();
            }
            sysFicheros.borrarFichero(sysFicheros.combinarRuta(SysFicheros.RUTA_DIR_APP, Constantes.FICHERO_ACTUALIZADOR));
            // Se comprueba que si existen actualizaciones de forma asíncrona con Task.
            new Task(comprobarActualizaciones).Start();
        }

        /// <summary>
        /// Permite añadir ficheros a la lista usando el método drag and drop (pichar y arrastrar)
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.DragEventArgs"/></param>
        private void Principal_DragDrop(object sender, DragEventArgs e) {
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

        /// <summary>
        /// Callback que se ejecuta guando se han arrastran ficheros a la ventana del programa,
        /// en otras palabras, detecta cuando se esta intentando arrastrar ficheros.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.DragEventArgs"/></param>
        private void Principal_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Callback que se ejecuta cuando se presiona la tecla suprimir.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.KeyEventArgs"/></param>
        private void lstFicheros_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && lstFicheros.SelectedItems.Count > 0) {
                foreach (ListViewItem elemento in lstFicheros.SelectedItems) {
                    lstFicheros.Items.Remove(elemento);
                }
            }
        }

        /// <summary>
        /// Muestra el menú contextual al hacer clic derecho sobre los elementos que tenemos listados en la aplicación.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.MouseEventArgs"/></param>
        private void lstFicheros_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && lstFicheros.SelectedItems.Count > 0) {
                if (clave.Length > 0) {
                    cifrarToolStripMenuItem.Enabled = true;
                    if (modoCifrado)
                        cifrarToolStripMenuItem.Text = "Cifrar";
                    else
                        cifrarToolStripMenuItem.Text = "Descifrar";
                } else {
                    cifrarToolStripMenuItem.Enabled = false;
                }
                menuListaFicheros.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstFicheros.Focus() && lstFicheros.SelectedItems.Count > 0) {
                foreach (ListViewItem elemento in lstFicheros.SelectedItems) {
                    lstFicheros.Items.Remove(elemento);
                }
            }
        }

        /// <summary>
        /// Recorre todos los ficheros que estaban pendientes de procesar y los pasa uno a uno al método <c>procesarFichero</c>
        /// para que realize las acciones oportunas con el archivo citado.
        /// </summary>
        /// <returns><c>true</c>, si no hubo errores al procesar, si no ... <c>false</c>.</returns>
        /// <param name="ficheros">Contiene la lista de ficheros a procesar.</param>
        private bool realizarAccion(ListView.SelectedListViewItemCollection  ficheros) {
            foreach (ListViewItem elemento in ficheros) {
                procesarFichero(elemento);
            }
            return comprobarErrores();
        }

        /// <summary>
        /// Sobrecarga del método anterior pero válido para listas tipo <c>ListViewItemCollection</c>.
        /// </summary>
        /// <returns><c>true</c>, si no hubo errores al procesar, si no ... <c>false</c>.</returns>
        /// <param name="ficheros">Contiene la lista de ficheros a procesar.</param>
        private bool realizarAccion(ListView.ListViewItemCollection ficheros) {
            foreach (ListViewItem elemento in ficheros) {
                procesarFichero(elemento);
            }
            return comprobarErrores();
        }

        /// <summary>
        /// Procesa los ficheros relizando la acción correspondiente de cifrado o descifrado para cada uno
        /// de los archivos de la lista.
        /// </summary>
        /// <returns><c>true</c>, si los ficheros fue procesados correctamente, de lo contrario<c>false</c>.</returns>
        /// <param name="elemento">Objecto <c>ListViewItem</c> con el elemento a procesar.</param>
        private bool procesarFichero(ListViewItem elemento) {
            try {
                if (modoCifrado) {
                    Cifrador.CifrarAES(elemento.Name, clave);
                    if (sysFicheros.tieneDatos(elemento.Name + Constantes.APP_EXTENSION))
                    if (chkBorradoSeguro.Checked)
                        sysFicheros.borradoSeguro(elemento.Name);
                    else
                        sysFicheros.borrarFichero(elemento.Name);
                    lstFicheros.Items.Remove(elemento);
                    btnProcesar.Enabled = false;
                } else {
                    Cifrador.DescifrarAES(elemento.Name, clave);
                    string nombreFicheroOriginal = sysFicheros.quitaExtension(elemento.Name);

                    if (sysFicheros.tieneDatos(nombreFicheroOriginal)) {
                        if (chkBorradoSeguro.Checked) // si se ha elegido borrado seguro se procede a ello
                            sysFicheros.borradoSeguro(elemento.Name);
                        else
                            sysFicheros.borrarFichero(elemento.Name);
                        lstFicheros.Items.Remove(elemento);
                        btnProcesar.Enabled = false;
                    } else {
                        strFallos.Append("Error de contraseña para el fichero: " + elemento.Name);
                    }
                }
            } catch (Exception) {
                strFallos.AppendLine(elemento.Name);
            }
            return (strFallos.Length > 0);
        }

        private void cifrarToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstFicheros.Focus() && lstFicheros.SelectedItems.Count > 0) {
                if (!realizarAccion(lstFicheros.SelectedItems)) {
                    strFallos.AppendLine("Error en menu contextual.");
                }
            }
        }

        /// <summary>
        /// Comprueba si hay errores tras procesar los ficheros avisando si al usuario en caso de haberlos,
        /// y mostrando los ficheros que han fallado.
        /// </summary>
        /// <returns><c>true</c>, si no hubo ningún error, de otra manera <c>false</c>.</returns>
        private bool comprobarErrores() {
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

        /// <summary>
        /// Comprueba si el usuario ha introducido la clave ya o aún no.
        /// </summary>
        /// <returns><c>true</c>, si la clave no esta vacía, si no <c>false</c>.</returns>
        private bool hayClave() {
            return (clave.Length > 0);
        }

        /// <summary>
        /// Comprueba la existencia de nuevas actualizaciones, estableciendo el atributo <c>hayActualizacoin</c> a <c>true</c> en caso de haberlas.
        /// </summary>
        private void comprobarActualizaciones() {
            Internet web = new Internet();
            try {             
                int codigo = Convert.ToInt32(web.getWebResponse(Constantes.URL_VERSION_ACTUAL));
                if (Constantes.APP_VERSION < codigo) {
                    this.hayActualizacion = true;                    
                }
            } catch (Exception ex) {
                dialogos.error(ex.Message, Textos.TEXTO_ERROR);
            }        
        }

        /// <summary>
        /// Callback ejecutado al hacer clic en el botón "Modo", el cual permite cambiar
        /// la aplicación de modo cifrar a modo descifrar.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
        private void btnModo_Click(object sender, EventArgs e) {
            dlgFicheros.Reset();
            dlgFicheros.Multiselect = true;
            try {
                if (btnModo.Text == "C&ifrar") {
                    btnModo.Text = "D&escifrar";
                    modoCifrado = false;
                    dlgFicheros.Filter = "Ficheros cifrados con SensibleInfo|*" + Constantes.APP_EXTENSION;
                
                    btnModo.Image = Properties.Resources.CandadoAbierto;
                } else {
                    btnModo.Text = "C&ifrar";
                    modoCifrado = true;
                    dlgFicheros.Filter = "Todos los ficheros|*";
                   
                    btnModo.Image = Properties.Resources.CandadoCerrado;
                }
                lstFicheros.Items.Clear();
                lblArrastrar.Visible = true;
                lblBarraAvisoClave.Text = "Modo: '" + btnModo.Text.Replace("&", Textos.BL) + "' activado";
                btnProcesar.Enabled = false;
                clave = Textos.BL;
            } catch (Exception ex) {
                dialogos.error(ex.Message, "Error");
            }

        }

        /// <summary>
        /// Callback ejecutado al hacer clic sobre el botón <c>btnProcesar</c>, poniendo en marcha las acciones pendientes
        /// para con los ficheros elegidos.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
        private void btnProcesar_Click(object sender, EventArgs e) {
            if (clave.Length > 0) {
                if (realizarAccion(lstFicheros.Items)) {
                    lstFicheros.Items.Clear();
                    lblArrastrar.Visible = true;
                    if (modoCifrado)
                        lblBarraAvisoClave.Text = Textos.AVISO_CIFRADO_EXITO;
                    else
                        lblBarraAvisoClave.Text = Textos.AVISO_DESCIFRADO_EXITO;
                }
            } else {
                dialogos.info("Debe establecer una contraseña antes de proceder", "Error");
            }
        }

        /// <summary>
        /// Callback ejecutado al hacer click sobre el botón <c>btnClave</c>, solicitando la clave al usuario en
        /// caso de ser necesario.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
        private void btnClave_Click(object sender, EventArgs e) {
            double opacidadPrevia = Opacity;
            Opacity = 0.1;
            clave = dialogos.password(modoCifrado);
            if (clave.Length > 0) {
                btnProcesar.Enabled = true;
            } else {
                btnProcesar.Enabled = false;
            }
            lblBarraAvisoClave.Text = "";
            Opacity = opacidadPrevia;
        }

        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
        private void label1_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// Callback que llavama al método <c>moverVentana</c> cada vez que el puntero del ratón se mueve por su fachada, con
        /// el fin de que esta actualize en todo momento la situación del mouse con el fin de correcciones.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.MouseEventArgs"/></param>
        private void Principal_MouseMove(object sender, MouseEventArgs e) {
            moverVentana();
        }

        /// <summary>
        /// Callback que llavama al método <c>moverVentana</c> cada vez que el puntero del ratón se mueve por su fachada, con
        /// el fin de que esta actualize en todo momento la situación del mouse con el fin de correcciones.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.MouseEventArgs"/></param>
        private void lstFicheros_MouseMove(object sender, MouseEventArgs e) {
            moverVentana();
        }

        /// <summary>
        /// Corrige detalles al mover la ventana.
        /// </summary>
        private void moverVentana() {
            if (MouseButtons.HasFlag(MouseButtons.Left)) {
                Left = MousePosition.X - anteriorX;
                Top = MousePosition.Y - anteriorY;
                
            } else {
                anteriorX = (MousePosition.X - (Left));
                anteriorY = (MousePosition.Y - (Top));
            }
        }

        /// <summary>
        /// Callback de un objeto <c>Timer</c> que comprueba si hay actualizaciones disponibles.
        /// </summary>
        /// <param name="sender">Objeto que llama a este callback.</param>
        /// <param name="e"><see cref="System.Windows.Forms.EventArgs"/></param>
        private void tmpActualizaciones_Tick(object sender, EventArgs e) {
            try {
                if (hayActualizacion) {
                    tmpActualizaciones.Enabled = false;
                    double opacidadPrevia = Opacity;
                    Opacity = 0.1;
                    if (dialogos.desicion("Hay una nueva versión disponible.\n\n¿Desea descargarla?", "Actualizar")) {
                        Internet web = new Internet();
                        string rutaActualizador = sysFicheros.combinarRuta(SysFicheros.RUTA_DIR_APP, Constantes.FICHERO_ACTUALIZADOR);
                        web.descargarFichero(Constantes.URL_ACTUALIZADOR, rutaActualizador);
                        sysFicheros.ejecutar(rutaActualizador);
                        Close();
                    }
                    Opacity = opacidadPrevia;
                }
            } catch (Exception) {
            }
        }
    }
}
