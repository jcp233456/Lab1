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
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Boolean http = false;
            Boolean www = false;
            Boolean com = false;
            String Url = comboBox1.Text.ToString();
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
                webView21.Source = (new Uri("https://www.google.com/search?q=+" + Url));
                Guardar("archivo.txt", comboBox1.Text);
                comboBox1.Items.Add(Url);
            }else
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
                Guardar("archivo.txt", comboBox1.Text);

            }

                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarHistorial();

        }
        private void Guardar(String fileName, String texto)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(stream);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            writer.WriteLine(texto);
            //Cerrar el archivo
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
            string rutaArchivo = Path.Combine(
                Application.StartupPath,
                "archivo.txt"
            );

            comboBox1.Items.Clear();

            if (File.Exists(rutaArchivo))
            {
                foreach (string linea in File.ReadAllLines(rutaArchivo))
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                        comboBox1.Items.Add(linea);
                }

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            else
            {
                
                File.Create(rutaArchivo).Close();
            }
        }
    }
}
