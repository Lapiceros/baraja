﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraja.Models
{
    internal class Baraja
    {

        private List<Carta> cartas;

        public List<Carta> Cartas { get { return cartas; } }
        public Baraja()
        {
            cartas = new List<Carta>();
            GenerarBaraja();
        }

       private void GenerarBaraja()
        {
            string[] palos = { "Corazones", "Diamantes", "Treboles", "Picas" };
            int[] valores = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            foreach (string palo in palos)
            {
                foreach (int valor in valores)
                {
                    cartas.Add(new Carta(palo, valor));
                }
            }
        }

        public void MostrarBaraja()
        {
            foreach (var carta in cartas)
            {
                Console.WriteLine($"{carta.Numero}-{carta.Palo}");
            }
        }
        public void BarajarMazo()
        {
            Random rnd = new Random();
            cartas = cartas.OrderBy(x => rnd.Next()).ToList();
        }

        public Carta RobarCarta()
        {
            return RobarPosN(0);
        }

        public Carta RobarCartaAzar()
        {
            Random rand = new Random();
            int pos = rand.Next(cartas.Count);
            return RobarPosN(pos);

        }
        public Carta RobarPosN(int posicion)
        {
            Carta cartaRobada = cartas[posicion];

            if (posicion > cartas.Count)
                Console.WriteLine("error");
            else
                cartas.Remove(cartaRobada);

            MostrarCarta(cartaRobada);
            return cartaRobada;
        }
        public List<List<Carta>> RepartirCartas(int numJugadores)
        {
            List<List<Carta>> manos = Enumerable.Range(0, numJugadores).Select( x => new List<Carta>()).ToList();
            int index = 0;
            while (cartas.Count >= numJugadores) 
            {
                manos[index % numJugadores].Add(cartas[0]);
                cartas.RemoveAt(0);
                index++;
            }
            return manos;
        }

        public Carta MostrarCarta(Carta carta)
        {
            Console.WriteLine($"{carta.Numero}-{carta.Palo}");
            return carta;

        }
    }
}
