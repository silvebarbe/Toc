using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TocGame
{
    class GameManager : Microsoft.Xna.Framework.GameComponent
    {
        Toc Jeu { get; set; }
        public GameManager(Toc jeu)
            :base(jeu)
        {
            Jeu = jeu;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
