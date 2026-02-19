using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class URL
    {
        String direccion;
        int veces;
        DateTime ultimoAcceso;

        public string Direccion { get => direccion; set => direccion = value; }
        public int Veces { get => veces; set => veces = value; }
        public DateTime UltimoAcceso { get => ultimoAcceso; set => ultimoAcceso = value; }
    }
}
