using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraja.Models
{
    internal class Carta
    {
        private string palo;
        private int numero;

        public string Palo {  get { return palo; } set { palo = value; } }
        public int Numero { get { return numero; } set { numero = value; } }

        public Carta(String palo, int numero) 
        {
            this.palo = palo;
            this.numero = numero;
        }
    }
}
