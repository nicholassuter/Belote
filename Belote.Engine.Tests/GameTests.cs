using NUnit.Framework;

namespace Belote.Engine.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Demarrer_une_nouvelle_partie()
        {
            Joueur joueurOuest = new Joueur("Ouest", JoueurType.Ordinateur);
            Joueur joueurNord = new Joueur("Nord", JoueurType.Ordinateur);
            Joueur joueurEst = new Joueur("Est", JoueurType.Ordinateur);
            Joueur nicholas = new Joueur("Nicholas", JoueurType.Humain);
            Partie partie = new Partie(1000, joueurOuest, joueurNord, joueurEst, nicholas);
        }
    }

    
}
