using System;
using System.Collections.Generic;
using System.Linq;

namespace Belote.Engine
{
    public class Partie
    {


        private readonly int _nbPointsMax;
        private readonly List<Joueur> _joueurs;
        private readonly Paire _nous, _eux;
        private Joueur _donneur;
        private Joueur _preneur;
        private Joueur _joueurCourant;
        private List<Carte> _cartes;
        private Couleur _atout;

        public Partie(int nbPointsMax, Joueur joueurOuest, Joueur joueurNord, Joueur joueurEst, Joueur joueurSud)
        {
            _nbPointsMax = nbPointsMax;
            _joueurs = new List<Joueur>
            {
                joueurOuest,
                joueurSud,
                joueurEst,
                joueurNord,
            };

            _nous = new Paire(joueurNord, joueurSud);
            _eux = new Paire(joueurOuest, joueurEst);
            _cartes = new List<Carte>(Paquet.TrenteDeuxCartes);
            _cartes.Melanger();
        }

        public void JouerPartie()
        {
            _donneur = ChoisirDonneur(_joueurs);

            while (_eux.Score < _nbPointsMax && _nous.Score < _nbPointsMax)
            {
                JouerTour();
                _donneur = GetJoueurSuivant(_donneur);
            }

        }

        private void JouerTour()
        {
            _cartes.Couper();
            DonnerPremiereMain(_cartes, _donneur);
            Carte vire = GetCartes(1, _cartes).First();
            _joueurCourant = GetJoueurSuivant(_donneur);
            Prise prise = GetPrise(vire);

            if (prise == null) return;

            _preneur = prise.Preneur;
            _atout = prise.Couleur;

            DonnerDeuxiemeMain(_cartes, _donneur);

            while (_joueurs[0].Cartes.Count > 0)
            {
                JouerPli(_preneur, _donneur);
            }
        }

        private void JouerPli(Joueur preneur, Joueur donneur)
        {
            var pli = new Dictionary<Joueur, Carte>();
            Couleur? couleurDemandee = null;
            for (int i = 0; i < 4; i++)
            {
                Carte carte = _joueurCourant.GetCarteAJouer(pli, couleurDemandee);
                pli.Add(_joueurCourant, carte);
                if (i == 0)
                {
                    couleurDemandee = carte.Couleur;
                }
                _joueurCourant = GetJoueurSuivant(_joueurCourant);
            }


        }

        private Prise GetPrise(Carte vire)
        {
            for (int i = 0; i < 4; i++)
            {
                Joueur j = GetJoueurSuivant(_donneur);
                Prise p = j.GetPrise(vire, 1);
                if (p != null) return p;
            }

            for (int i = 0; i < 4; i++)
            {
                Joueur j = GetJoueurSuivant(_donneur);
                Prise p = j.GetPrise(vire, 2);
                if (p != null) return p;
            }

            return null;
        }

        private Joueur ChoisirDonneur(List<Joueur> joueurs)
        {
            var r = new Random();
            int i = r.Next(_joueurs.Count);
            return joueurs[i];
        }

        private void DonnerPremiereMain(List<Carte> cartes, Joueur donneur)
        {
            for (int i = 0; i < 4; i++)
            {
                Joueur prochainJoueur = GetJoueurSuivant(donneur);
                IEnumerable<Carte> cartesADonner = GetCartes(3, cartes);
                prochainJoueur.Cartes.AddRange(cartesADonner);
            }

            for (int i = 0; i < 4; i++)
            {
                Joueur prochainJoueur = GetJoueurSuivant(donneur);
                IEnumerable<Carte> cartesADonner = GetCartes(2, cartes);
                prochainJoueur.Cartes.AddRange(cartesADonner);
            }
        }

        private void DonnerDeuxiemeMain(List<Carte> cartes, Joueur donneur)
        {
            for (int i = 0; i < 4; i++)
            {
                Joueur prochainJoueur = GetJoueurSuivant(donneur);

                IEnumerable<Carte> cartesADonner = GetCartes(prochainJoueur == _preneur ? 2 : 3, cartes);
                prochainJoueur.Cartes.AddRange(cartesADonner);
            }
        }

        private Joueur GetJoueurSuivant(Joueur joueurCourant)
        {
            int positionJoueurCourant = _joueurs.FindIndex(j => j == joueurCourant);
            int positionProchainJoueur = (positionJoueurCourant + 1) % _joueurs.Count;
            return _joueurs[positionProchainJoueur];
        }

        private IEnumerable<Carte> GetCartes(int nbCartes, List<Carte> cartes)
        {
            IEnumerable<Carte> cartesADonner = cartes.Take(nbCartes);
            cartes.RemoveRange(0, nbCartes);

            return cartesADonner;
        }
    }
}