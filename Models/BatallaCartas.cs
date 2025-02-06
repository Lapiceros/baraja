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
                    Thread.Sleep(500);

                    if (carta.Numero > 10)
                        Console.WriteLine($"{jugador.Name} juega {carta.ObtenerValor()} de {carta.Palo}");
                    else
                        Console.WriteLine($"{jugador.Name} juega {carta.Numero} de {carta.Palo}");

                    mesa.Add((jugador, carta));
                }
            }

            int maxValor = mesa.Max(carta => carta.Item2.Numero);
            var ganador = mesa.Where(carta => carta.Item2.Numero == maxValor).Select(carta => carta.Item1 ).ToList();

            if (ganador.Count == 1)
            {
                Thread.Sleep(500);
                ganador[0].RecibirCartas(mesa.Select(m => m.Item2));
                Console.WriteLine($"{ganador[0].Name} ha ganado la ronda y se lleva las cartas");
            }
            else 
            {
                Console.WriteLine("Empate, pulsa una tecla para seguir con el desempate");
                Console.ReadKey();
                RondaDesempate(ganador);
            }

            jugadores = jugadores.Where(jugador => jugador.TieneCartas()).ToList();
        }
        public void RondaDesempate(List<Jugador> jugadoresEmpatados)
        {
            Console.Clear();
            var desempate = new List<(Jugador, Carta)>();

            foreach (var jugador in jugadoresEmpatados)
            {
                if(jugador.TieneCartas())
                {
                    var carta = jugador.RobarCarta();
                    Thread.Sleep(500);
                    Console.WriteLine($"{jugador.Name} juega {carta.ObtenerValor()} de {carta.Palo}");
                    desempate.Add((jugador, carta));
                }
            }
            int maxValor = desempate.Max(carta => carta.Item2.Numero);
            var jugadores = desempate.Where(carta => carta.Item2.Numero == maxValor).Select(carta => carta.Item1).ToList();

            if (jugadores.Count ==1)
            {
                jugadores[0].RecibirCartas(desempate.Select(cartas =>  cartas.Item2).ToList());
                Thread.Sleep(500);
                Console.WriteLine($"{jugadores[0].Name} ha ganado el desmepate");
            }
            else
            {
                Console.WriteLine("Empate otra vez...");
                RondaDesempate(jugadores);
            }

        }
        public void Jugar()
        {
            while (jugadores.Count > 1)
            {
                Console.WriteLine("Pulsa una tecla para jugar la siguiente ronda");
                Console.ReadKey();
                Thread.Sleep(500);
                JugarRonda();
            }

            Console.WriteLine($"{jugadores[0].Name} Ha ganado!!");
        }
    }
}
