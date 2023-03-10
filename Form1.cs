using System;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Xml;

namespace ensayo
{
    public partial class Form1 : Form
    {
        string linea;
            string url1 = "http://rndcws.mintransporte.gov.co:8080/ws/svr008w.dll/soap/IBPMServices";
            string url2 = "http://rndcws2.mintransporte.gov.co:8080/ws/svr008w.dll/soap/IBPMServices";
            String ruta = "C:\\Users\\fmoz1\\Desktop\\Simplexity.AsTrans.RNDC.exe.config";
        String ruta2 = "C:\\Users\\fmoz1\\Desktop\\ejemplo.xml";

        string serviceDetenerIniciar = "Wcmsvc";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          //  String SERVICEURL = ConfigurationManager.AppSettings["ServicioNombre"];
          
            
         //ManejoXml eliminaNodo= new ManejoXml();
            //eliminaNodo._DeleteNodo();
            StreamReader sr = new StreamReader(ruta);
          
          
           linea= sr.ReadLine();
            while (linea != null) {
                //MessageBox.Show(linea);
                Console.WriteLine(linea); 
                if (linea.Contains("SERVICEURL"))

                {

                    lista.Items.Add(linea);

                }

                linea = sr.ReadLine();
            }
            sr.Close();
            
            //MessageBox.Show(SERVICEURL);
            XmlDocument xml = new XmlDocument();
           
            
            xml.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection("appSettings");
           // MessageBox.Show(SERVICEURL);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StopService()
        {
            ServiceController sc = new ServiceController(serviceDetenerIniciar);

            try
            {
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    MessageBox.Show("El servicio ya se encuentra denido ");
                }
                if (sc != null || sc.Status == ServiceControllerStatus.Running)
                {

                    sc.Stop();
                    MessageBox.Show("Servicio denido exitosamente");

                }

                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al detener el servicio:" + ex.Message);

            }


        }

        private void StartService()
        {
            ServiceController sc = new ServiceController(serviceDetenerIniciar);

            try
            {
                if (sc != null && sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();

                    MessageBox.Show("Servicio iniciado exitosamente");
                }
                sc.WaitForStatus(ServiceControllerStatus.Running);
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar el servicio:" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopService();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlWriter xmlWriter = XmlWriter.Create(ruta2);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Libros");
            xmlWriter.WriteStartElement("Libro");
            xmlWriter.WriteAttributeString("Autor", "Freyder");

            xmlWriter.WriteAttributeString("version", "10000");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }
    }
}