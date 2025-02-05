using baraja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero de jugadroes entre 2 y 5");
            int jugadores = int.Parse(Console.ReadLine());
            if (jugadores >= 2 && jugadores <= 5)
            {
                BatallaCartas Juego = new BatallaCartas(jugadores);
                Juego.Jugar();
            }
            else
                Console.WriteLine("Numero de jugadores no valido");

        }

        public void Menu()
        {
          
        }
    }
}
