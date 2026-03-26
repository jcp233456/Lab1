using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class Form1 : Form
    {
        List<URL>direccioness=new List<URL>();
        public Form1()
        {
            direccioness = new List<URL>();
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            URL direccion = new URL();
            string Url = comboBox1.Text;



            Boolean http = false;
            Boolean www = false;
            Boolean com = false;
            ;
            if((Url.Contains("https://")) || (Url.Contains("http://")))
            {
                http = true;
            }
            if (Url.Contains(".com"))
            {
                com = true;
            }
            if (Url.Contains("www."))
            {
                www = true;
            }

            if(!http && !com && !www)
            {
               webView21.Source= (new Uri("https://www.google.com/search?q=" + Url));
                 
                direccion.Direccion = Url;
                direccion.UltimoAcceso = DateTime.Now;
                direccion.Veces  ++;

                direccioness.Add(direccion);
                Persistencia persistencia = new Persistencia();
                persistencia.GuardarJson(direccioness);
                //Guardar("archivo.txt");
            }
            else
            {
                if (!www)
                {
                    Url = "www." + Url;

                }
                    

                if (!http)
                {
                    Url = "https://" + Url;

                }
                    

                if (!com)
                {
                    Url = Url + ".com";
                }
                    

                webView21.Source = new Uri(Url);

                
                direccion.Direccion = Url;
                direccion.UltimoAcceso = DateTime.Now;
                direccion.Veces ++;

                direccioness.Add(direccion);
                Persistencia persistencia = new Persistencia();
                    
                //Guardar("archivo.txt");
                persistencia.GuardarJson(direccioness);
                
                

            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CargarHistorial();
            Persistencia persistencia = new Persistencia();
            direccioness = persistencia.leerJson();

        }
        private void Guardar(String fileName)
        {
 
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var direccion in direccioness)
            {
                writer.WriteLine(direccion.Direccion);
                writer.WriteLine(direccion.UltimoAcceso);
                writer.WriteLine(direccion.Veces);
            }
           
            
            writer.Close();

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.Source = (new Uri("https://www.google.com"));
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.GoBack();

        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.GoForward();
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaArchivo = Path.Combine(
                Application.StartupPath,
                "archivo.txt"
            );

            comboBox1.Items.Clear();

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);

                foreach (string linea in lineas)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                        comboBox1.Items.Add(linea);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo historial.txt");
            }
        }
        private void CargarHistorial()
        {
            string nombreArchivo = @"archivo.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                URL direccion = new URL();
                direccion.Direccion = reader.ReadLine();
                
                direccion.UltimoAcceso = Convert.ToDateTime(reader.ReadLine());
                direccion.Veces = Convert.ToInt16(reader.ReadLine());
                direccioness.Add(direccion);

            }
            reader.Close();
            Mostrar();
            
        }
        private void Mostrar()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "Direccion";
            comboBox1.DataSource = direccioness;

        }


    }
}
