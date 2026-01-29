using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            }


                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
