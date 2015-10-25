namespace Belote.Engine
{
    public class Paire
    {
        public Joueur Joueur1 { get; set; }
        public Joueur Joueur2 { get; set; }

        public int Score { get; set; }

        public Paire(Joueur joueur1, Joueur joueur2)
        {
            joueur1.Partenaire = joueur2;
            joueur2.Partenaire = joueur1;

            Joueur1 = joueur1;
            Joueur2 = joueur2;
            Score = 0;
        }
    }
}