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
        private int _numero;
        public enum ValorCarta
        {
            Dos = 2,
            Tres = 3,
            Cuatro = 4,
            Cinco = 5,
            Seis = 6,
            Siete = 7,
            Ocho = 8,
            Nueve = 9,
            Diez = 10,
            J = 11,
            Q = 12,
            K = 13,
            A = 14
        }

        public string Palo {  get { return _palo; } set { _palo = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }


        public Carta(String palo, int numero) 
        {
            this.Palo = palo;
            this.Numero = numero;
        }

        public ValorCarta ObtenerValor()
        {
            return (ValorCarta)this.Numero;
        }
    }
}
