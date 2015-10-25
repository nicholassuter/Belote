using System;
using System.Collections.Generic;
using System.Linq;

namespace Belote.Engine
{
    public static class CartesExtensions
    {
        public static void Melanger(this List<Carte> cartes)
        {
            Random random = new Random();

            int n = cartes.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Carte value = cartes[k];
                cartes[k] = cartes[n];
                cartes[n] = value;
            }
        }

        public static List<Carte> Couper(this List<Carte> cartes)
        {
            var random = new Random();
            int index = random.Next(4, cartes.Count - 4);
            var premierTas = cartes.Take(index);
            var deuxiemeTas = cartes.Skip(index).Take(cartes.Count);
            return deuxiemeTas.Concat(premierTas).ToList();
        }
    }
}