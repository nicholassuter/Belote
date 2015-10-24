using System;
using System.Collections;
using System.Collections.Generic;

namespace Belote.Engine
{
    public class Carte : IEqualityComparer<Carte>
    {
        public Couleur Couleur { get; set; }
        public Valeur Valeur { get; set; }

        public Carte(Valeur valeur, Couleur couleur)
        {
            Couleur = couleur;
            Valeur = valeur;
        }

        #region IEqualityComparer members
        public bool Equals(Carte x, Carte y)
        {
            return x.Valeur == y.Valeur && x.Couleur == y.Couleur;
        }

        public int GetHashCode(Carte obj)
        {
            return obj.GetHashCode();
        }
        #endregion
    }

    public enum Valeur
    {
       Sept,
       Huit,
       Neuf,
       Dix,
       Valet,
       Dame,
       Roi,
       As
    }

    public enum Couleur
    {
        Pique,
        Coeur,
        Carreau,
        Trefle
    }
}