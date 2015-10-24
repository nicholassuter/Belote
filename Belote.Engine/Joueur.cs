using System.Collections.Generic;

namespace Belote.Engine
{
    public class Joueur
    {
        public string Nom { get; set; }
        public JoueurType Type { get; set; }

        public List<Carte> Cartes { get; set; }

        public Joueur(string nom, JoueurType type)
        {
            Nom = nom;
            Type = type;
            Cartes = new List<Carte>();
        }
    }

    public enum JoueurType
    {
        Humain,
        Ordinateur
    }
}