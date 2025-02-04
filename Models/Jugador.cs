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
        private List<Carta> _mano;

        public string Name { get { return _name; }}
        public List<Carta> Mano { get { return _mano; } }

        public Jugador(string nombre, List<Carta> mano) 
        {
            this._name = nombre;
            this._mano = new List<Carta> (mano);
        }

        public Carta RobarCarta() 
        {
            if (Mano.Count == 0)
                return null;
            Carta carta = Mano[0];
            Mano.RemoveAt(0);

            return carta;
                
            
        }
        public void RecibirCartas(List<Carta> mazo) 
        {
            _mano.AddRange(mazo);
        }
        public bool TieneCartas()
        {
            return _mano.Count > 0;
        }
    }
}
