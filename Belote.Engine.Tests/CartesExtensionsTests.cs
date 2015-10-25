using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace Belote.Engine.Tests
{
    [TestFixture]
    public class CartesExtensionsTests
    {
        [Test]
        public void Melanger()
        {
            var jeu = new List<Carte>(Paquet.TrenteDeuxCartes);
            jeu.Melanger();
            Check.That(jeu).HasSize(32);

            //Validation d'unicité des cartes
            var hashSet = new HashSet<Carte>(jeu);
            Check.That(hashSet).HasSize(32);
        }

        [Test]
        public void Couper()
        {
            var jeu = new List<Carte>(Paquet.TrenteDeuxCartes);
            jeu.Melanger();
            var anciennePremiere = jeu.First();
            var ancienneDerniere = jeu.Last();
            jeu = jeu.Couper();
            Check.That(jeu).HasSize(32);
            Check.That(jeu.First()).IsNotEqualTo(anciennePremiere);
            Check.That(jeu.Last()).IsNotEqualTo(ancienneDerniere);

            //Validation d'unicité des cartes
            var hashSet = new HashSet<Carte>(jeu);
            Check.That(hashSet).HasSize(32);
        }
    }
}
