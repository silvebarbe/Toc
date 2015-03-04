using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TocGame
{
    class Carte : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public enum SorteCarte { COEUR, CARREAU, TREFLE, PIQUE }
        Toc Jeu { get; set; }
        
        SorteCarte Sorte_ { get; set; }
        int Valeur_ { get; set; }
        public Carte(Toc jeu, SorteCarte sorte, int valeur)
            :base(jeu)
        {
            Jeu = jeu;
            Sorte_ = sorte;
            Valeur_ = valeur;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
