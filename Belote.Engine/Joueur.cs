using System.Collections.Generic;

namespace Belote.Engine
{
    public class Joueur
    {
        public string Nom { get; set; }
        public JoueurType Type { get; set; }

        public List<Carte> Cartes { get; set; }
        public Joueur Partenaire { get; set; }

        public Joueur(string nom, JoueurType type)
        {
            Nom = nom;
            Type = type;
            Cartes = new List<Carte>();
        }

        public Carte GetCarteAJouer(Dictionary<Joueur, Carte> pli, Couleur? couleurDemandee)
        {
            throw new System.NotImplementedException();
        }

        public Prise GetPrise(Carte vire, int tour)
        {
            throw new System.NotImplementedException();
        }
    }

    public enum JoueurType
    {
        Humain,
        Ordinateur
    }
}