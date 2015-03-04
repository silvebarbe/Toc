using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TocGame
{
    public class Case : Microsoft.Xna.Framework.GameComponent
    {
        public Vector2 Position { get; private set; }
        public bool EstOccupee { get; set; }
        public bool Bloque { get; set; }

        Toc Jeu { get; set; }

        public Case(Toc jeu, int x, int y)
            : base(jeu)
        {
            Jeu = jeu;
            Position = new Vector2(x, y);
        }
        
        public override void Initialize()
        {
            EstOccupee = false;
            Bloque = false;

            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
