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

        public void JugarRonda() 
        {
            var ganadores = Ronda(jugadores);
            if (ganadores.Count > 1)
                RondaDesempate(ganadores);
            else
                Console.WriteLine($"{ganadores[0].Name} ha ganado la ronda");
            

            jugadores = jugadores.Where(jugador => jugador.TieneCartas()).ToList();
        }
        public void RondaDesempate(List<Jugador> jugadoresEmpatados)
        {
            var ganadores = Ronda(jugadoresEmpatados);

            if (ganadores.Count == 1)
                Console.WriteLine($"{ganadores[0].Name} Ha ganado la ronda de desempate");
            else
            {
                Console.WriteLine("Empate otra vez!!");
                Console.WriteLine("Pulsa una tecla para seguir desempatar");
                Console.ReadKey();
                RondaDesempate(ganadores);  
            }
        }

        private List<Jugador> Ronda(List<Jugador> participantes)
        {
            Console.Clear();
            var mesa = new List<(Jugador, Carta)>();

            foreach (var jugador in participantes)
            {
                if(jugador.TieneCartas())
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

            int maxvalor = mesa.Max(carta => carta.Item2.Numero);
            var ganadores = mesa.Where(carta => carta.Item2.Numero == maxvalor).Select(carta => carta.Item1).ToList();

            if(ganadores.Count == 1)
                ganadores[0].RecibirCartas(mesa.Select(cartas => cartas.Item2).ToList());
            
            else
            {
                Console.WriteLine("Empate, pulsa una tecla para seguir con la ronda de desempate");
                Console.ReadKey();
            }

            return ganadores;
        }

    }
}
