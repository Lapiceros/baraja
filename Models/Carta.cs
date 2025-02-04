using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraja.Models
{
    internal class Carta
    {
        private string _palo;
        private string _numero;
        private int _valor;
        private static readonly Dictionary<string, int> Valores = new Dictionary<string, int>
        {
            { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 },
            { "8", 8 }, { "9", 9 }, { "10", 10 }, { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 }
        };

        public string Palo {  get { return _palo; } set { _palo = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public int Valor { get { return _valor; } set { _valor = value; } }


        public Carta(String palo, string numero) 
        {
            this.Palo = palo;
            this.Numero = numero;
            this.Valor = Valores[numero];
        }
    }
}
