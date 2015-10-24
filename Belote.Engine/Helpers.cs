using System;
using System.Collections.Generic;
using System.Linq;

namespace Belote.Engine
{
    public static class Helpers
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
    }
}