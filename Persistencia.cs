using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab1
{
    internal class Persistencia
    {
        List<URL> direccioness = new List<URL>();
        string fileHistorial = "json.txt";
        public List<URL> leerJson()
        {
            if (File.Exists(fileHistorial))
            {
                
                string jsonString = File.ReadAllText(fileHistorial);
                direccioness = JsonConvert.DeserializeObject<List<URL>>(jsonString);

            }

            return direccioness;
        }

        public void GuardarJson(List<URL>direccioness)
        {
            string jsonString = JsonConvert.SerializeObject(direccioness);
            File.WriteAllText(fileHistorial, jsonString);
        }
    }
}
