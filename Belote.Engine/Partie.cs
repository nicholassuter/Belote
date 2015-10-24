using System;
using System.Collections;
using System.Collections.Generic;

namespace Belote.Engine
{
    public class Partie
    {
        private List<Joueur> _joueurs;
        private Joueur _donneur;
        private Tuple<Joueur, Joueur> _nous, _eux;
        

        public static List<Carte> Cartes = new List<Carte>
        {
            new Carte(Valeur.Sept, Couleur.Pique),
            new Carte(Valeur.Huit, Couleur.Pique),
            new Carte(Valeur.Neuf, Couleur.Pique),
            new Carte(Valeur.Dix, Couleur.Pique),
            new Carte(Valeur.Valet, Couleur.Pique),
            new Carte(Valeur.Dame, Couleur.Pique),
            new Carte(Valeur.Roi, Couleur.Pique),
            new Carte(Valeur.As, Couleur.Pique),
            new Carte(Valeur.Sept, Couleur.Coeur),
            new Carte(Valeur.Huit, Couleur.Coeur),
            new Carte(Valeur.Neuf, Couleur.Coeur),
            new Carte(Valeur.Dix, Couleur.Coeur),
            new Carte(Valeur.Valet, Couleur.Coeur),
            new Carte(Valeur.Dame, Couleur.Coeur),
            new Carte(Valeur.Roi, Couleur.Coeur),
            new Carte(Valeur.As, Couleur.Coeur),
            new Carte(Valeur.Sept, Couleur.Carreau),
            new Carte(Valeur.Huit, Couleur.Carreau),
            new Carte(Valeur.Neuf, Couleur.Carreau),
            new Carte(Valeur.Dix, Couleur.Carreau),
            new Carte(Valeur.Valet, Couleur.Carreau),
            new Carte(Valeur.Dame, Couleur.Carreau),
            new Carte(Valeur.Roi, Couleur.Carreau),
            new Carte(Valeur.As, Couleur.Carreau),
            new Carte(Valeur.Sept, Couleur.Trefle),
            new Carte(Valeur.Huit, Couleur.Trefle),
            new Carte(Valeur.Neuf, Couleur.Trefle),
            new Carte(Valeur.Dix, Couleur.Trefle),
            new Carte(Valeur.Valet, Couleur.Trefle),
            new Carte(Valeur.Dame, Couleur.Trefle),
            new Carte(Valeur.Roi, Couleur.Trefle),
            new Carte(Valeur.As, Couleur.Trefle),
        }; 

        public Partie(Joueur joueurOuest, Joueur joueurNord, Joueur joueurEst, Joueur joueurSud)
        {
            _joueurs = new List<Joueur>
            {
                joueurOuest,
                joueurNord,
                joueurEst,
                joueurSud
            };

            _nous = new Tuple<Joueur, Joueur>(joueurNord, joueurSud);
            _eux = new Tuple<Joueur, Joueur>(joueurOuest, joueurSud);
        }

        public void Demarrer()
        {
            Cartes.Melanger();
            DonnerPremiereMain(Cartes);
        }

        private void DonnerPremiereMain(List<Carte> cartes)
        {
            
        }
    }
}