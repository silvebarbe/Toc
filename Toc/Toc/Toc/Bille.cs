using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TocGame
{
    class Bille : Microsoft.Xna.Framework.DrawableGameComponent
    {
        enum Couleur { ROUGE, BLEU, VERT, JAUNE }

        Toc Jeu { get; set; }
        Case position_{ get ; set; }
        Couleur couleur_{ get ; set; }
        Texture2D ImageJ1 { get; set; }
        Texture2D ImageJ2 { get; set; }
        Texture2D ImageJ3 { get; set; }
        Texture2D ImageJ4 { get; set; }

        Vector2 millieu;

        public Bille(Toc jeu)
            :base(jeu)
        {
            Jeu = jeu;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ImageJ1 = Jeu.Content.Load<Texture2D>("Textures/Cases/Case_couleur_J1");
            ImageJ2 = Jeu.Content.Load<Texture2D>("Textures/Cases/Case_couleur_J2");
            ImageJ3 = Jeu.Content.Load<Texture2D>("Textures/Cases/Case_couleur_J3");
            ImageJ4 = Jeu.Content.Load<Texture2D>("Textures/Cases/Case_couleur_J4");
            base.LoadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            millieu = new Vector2((Jeu.Window.ClientBounds.Width / 2.0f) - (ImageJ1.Width / 2.0f),      // Milieu de l'image au milieu de l'ecran
                                    (Jeu.Window.ClientBounds.Height / 2.0f) - (ImageJ1.Width / 2.0f));

            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Jeu.SpriteBatch.Draw(ImageJ1, millieu, null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
            base.Draw(gameTime);
        }
    }
}
