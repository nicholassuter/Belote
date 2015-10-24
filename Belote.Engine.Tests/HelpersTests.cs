using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace Belote.Engine.Tests
{
    public class HelpersTests
    {
        [Test]
        public void Shuffle()
        {
            var jeu = new List<Carte>(Partie.Cartes);
            jeu.Melanger();
            Check.That(jeu).HasSize(32);

            //Validation d'unicité des cartes
            var hashSet = new HashSet<Carte>(jeu);
            Check.That(hashSet).HasSize(32);
        }
    }
}
