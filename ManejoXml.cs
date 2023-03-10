using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ensayo
{
    public class ManejoXml
    {
        XmlDocument doc;
        string rutaXml = "C:\\Users\\fmoz1\\Desktop\\Simplexity.AsTrans.RNDC.exe.config";
        public void _DeleteNodo()
        {
            try { 
            doc.Load(rutaXml);

            XmlNode empleados = doc.DocumentElement;

            XmlNodeList listaEmpleados = doc.SelectNodes("configuration/section");

            foreach (XmlNode item in listaEmpleados)
            {

                if (item.SelectSingleNode("name").InnerText == "loggingConfiguration")
                {

                    XmlNode nodoOld = item;

                    empleados.RemoveChild(nodoOld);
                }
            }

            doc.Save(rutaXml);
            }catch(FileNotFoundException ex)
            {
                MessageBox.Show(""+ex);
            }
        }
    }
}
