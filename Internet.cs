using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;


namespace SensibleInfo
{
    class Internet
    {

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

        public void descargarFichero(string URL, string rutaCompleta) {
            WebClient web = new WebClient();
            web.DownloadFile(URL, rutaCompleta);
        }
    }
}
