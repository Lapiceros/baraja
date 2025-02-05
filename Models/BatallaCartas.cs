using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace baraja.Models
{
    internal class BatallaCartas
    {
        private List<Jugador> jugadores;

        public BatallaCartas(int numJugadores) 
        {
            Baraja baraja = new Baraja();
            baraja.BarajarMazo();
            List<List<Carta>> mazos = baraja.RepartirCartas(numJugadores);
            jugadores = mazos.Select((mazo, i) => new Jugador($"Jugador{i + 1}", mazo)).ToList();
        }

        public void JugarRonda() 
        {
            Console.Clear();
            var mesa = new List<(Jugador, Carta)>();
            foreach (var jugador in jugadores)
            {
                if (jugador.TieneCartas())
                {
                    var carta = jugador.RobarCarta();
                    Console.WriteLine($"{jugador.Name} juega {carta.Numero} de {carta.Palo}");
                    mesa.Add((jugador, carta));
                }
                    
            }
            int maxValor = mesa.Max(carta => carta.Item2.Valor);
            var ganador = mesa.Where(carta => carta.Item2.Valor == maxValor).Select(carta => carta.Item1 ).ToList();

            if (ganador.Count == 1)
            {
                ganador[0].RecibirCartas(mesa.Select(m => m.Item2));
                Console.WriteLine($"{ganador[0].Name} ha ganado la ronda y se lleva las cartas");
            }
            else 
            {
                Console.WriteLine("Empate, ronda de desempate");
                Thread.Sleep(1000);
                JugarRonda();
            }

            jugadores = jugadores.Where(jugador => jugador.TieneCartas()).ToList();
        }
        public void Jugar()
        {
            while (jugadores.Count > 1)
            {
                Console.WriteLine("Nueva Ronda");
                Console.WriteLine("Pulsa una tecla para jugar la siguiente ronda");
                Console.ReadKey();
                Thread.Sleep(500);
                JugarRonda();
            }

            Console.WriteLine($"{jugadores[0].Name} Ha ganado!!");
        }
    }
}
