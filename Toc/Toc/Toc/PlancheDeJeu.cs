using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace TocGame
{
    public class PlancheDeJeu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public static Vector2 Echelle { get; set; }

        public List<Case> listeCases { get; set; }

        const int NB_CASE = 104;
        Texture2D Image { get; set; }
        Toc Jeu { get; set; }
        float IntervalleMAJ { get; set; }
        float Temps…coulÈDepuisMAJ { get; set; }
        string NomImage { get; set; }

        public PlancheDeJeu(Toc jeu, string nomImage, float intervalleMAJ)
            : base(jeu)
        {
            IntervalleMAJ = intervalleMAJ;
            Jeu = jeu;
            NomImage = nomImage;
        }

        public override void Initialize()
        {
            listeCases = new List<Case>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Image = Jeu.Content.Load<Texture2D>("Textures/" + NomImage);
            Echelle = new Vector2(Jeu.Window.ClientBounds.Width / (float)Image.Width,
                                    Jeu.Window.ClientBounds.Height / (float)Image.Height);
        }

        public override void Update(GameTime gameTime)
        {
            Echelle = new Vector2(Jeu.Window.ClientBounds.Width / (float)Image.Width,
                                    Jeu.Window.ClientBounds.Height / (float)Image.Height);

            float temps…coulÈ = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Temps…coulÈDepuisMAJ += temps…coulÈ;
            if (Temps…coulÈDepuisMAJ > IntervalleMAJ)
            {

                Temps…coulÈDepuisMAJ -= IntervalleMAJ;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Jeu.SpriteBatch.Draw(Image, Vector2.Zero, null, Color.White, 0, Vector2.Zero, Echelle, SpriteEffects.None, 1);
            //Jeu.SpriteBatch.Draw(Image, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 1);
            base.Draw(gameTime);
        }
    }
}