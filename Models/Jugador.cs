using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraja.Models
{
    internal class Jugador
    {
        private string _name;
        private List<Carta> _mazo;

        public string Name { get { return _name; }}
        public List<Carta> Mazo { get { return _mazo; } }

        public Jugador(string nombre, List<Carta> mazo) 
        {
            this._name = nombre;
            this._mazo = new List<Carta> (mazo);
        }

        public Carta RobarCarta() 
        {
            if (Mazo.Count == 0)
                return null;
            Carta carta = Mazo[0];
            Mazo.RemoveAt(0);

            return carta;
        }
        public void RecibirCartas(IEnumerable<Carta> mazo) 
        {
            _mazo.AddRange(mazo);
        }
        public bool TieneCartas()
        {
            return _mazo.Count > 0;
        }
        public List<Carta> MostrarMazo()
        {
            foreach (var carta in Mazo)
            {
                Console.WriteLine($"{carta.Numero} de {carta.Palo}");
            }
            return Mazo;
        }
    }
}
