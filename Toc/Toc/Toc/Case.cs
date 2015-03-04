using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TocGame
{
    public class Case : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Vector2 Position { get; private set; }
        public bool EstOccupee { get; set; }
        public bool Bloque { get; set; }

        Texture2D Image { get; set; }
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

        protected override void LoadContent()
        {
            Image = Jeu.Content.Load<Texture2D>("Textures/Cases/Case_neutre");
            base.LoadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Jeu.SpriteBatch.Draw(Image, Position, null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
            base.Draw(gameTime);
        }
    }
}
