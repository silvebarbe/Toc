using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TocGame
{
    class Joueur : Microsoft.Xna.Framework.GameComponent
    {
        Toc Jeu { get; set; }
        bool Tour { get; set; }
        string Nom { get; set; }
        int Numero { get; set; }
        List<Paquet> Main { get; set; }

       Joueur(Toc jeu, bool tour, string nom, int numero)
            : base(jeu)
        {
            Jeu = jeu;
            Main = new List<Paquet>();
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }



    }
}
