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
        public Vector2 Echelle { get; set; }
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
            listeCases = new List<Case>(NB_CASE);
            #region Coin HAUT GAUCHE
            listeCases.Add(new Case(Jeu, 15, 15));
            listeCases.Add(new Case(Jeu, 40, 15));
            listeCases.Add(new Case(Jeu, 15, 40));
            listeCases.Add(new Case(Jeu, 40, 40));
            #endregion

            #region Coin HAUT DROIT
            listeCases.Add(new Case(Jeu, 560, 15));
            listeCases.Add(new Case(Jeu, 585, 15));
            listeCases.Add(new Case(Jeu, 560, 40));
            listeCases.Add(new Case(Jeu, 585, 40));
            #endregion

            #region Coin BAS GAUCHE
            listeCases.Add(new Case(Jeu, 15, 560));
            listeCases.Add(new Case(Jeu, 40, 560));
            listeCases.Add(new Case(Jeu, 15, 585));
            listeCases.Add(new Case(Jeu, 40, 585));
            #endregion

            #region Coin BAS DROIT
            listeCases.Add(new Case(Jeu, 560, 560));
            listeCases.Add(new Case(Jeu, 585, 560));
            listeCases.Add(new Case(Jeu, 560, 585));
            listeCases.Add(new Case(Jeu, 585, 585));
            #endregion

            #region HAUT
            listeCases.Add(new Case(Jeu, 250, 15));
            listeCases.Add(new Case(Jeu, 275, 15));
            listeCases.Add(new Case(Jeu, 300, 15));
            listeCases.Add(new Case(Jeu, 325, 15));
            listeCases.Add(new Case(Jeu, 350, 15));

            listeCases.Add(new Case(Jeu, 300, 40));
            listeCases.Add(new Case(Jeu, 300, 65));
            listeCases.Add(new Case(Jeu, 300, 90));
            listeCases.Add(new Case(Jeu, 300, 115));
            #endregion

            #region HAUT vers DROIT
            listeCases.Add(new Case(Jeu, 350, 40));
            listeCases.Add(new Case(Jeu, 352, 67));
            listeCases.Add(new Case(Jeu, 355, 93));
            listeCases.Add(new Case(Jeu, 363, 118));
            listeCases.Add(new Case(Jeu, 373, 143));
            listeCases.Add(new Case(Jeu, 388, 168));
            listeCases.Add(new Case(Jeu, 410, 190));
            listeCases.Add(new Case(Jeu, 432, 212));
            listeCases.Add(new Case(Jeu, 457, 227));
            listeCases.Add(new Case(Jeu, 482, 237));
            listeCases.Add(new Case(Jeu, 507, 245));
            listeCases.Add(new Case(Jeu, 533, 248));
            listeCases.Add(new Case(Jeu, 560, 250));
            #endregion

            #region DROIT
            listeCases.Add(new Case(Jeu, 585, 250));
            listeCases.Add(new Case(Jeu, 585, 275));
            listeCases.Add(new Case(Jeu, 585, 300));
            listeCases.Add(new Case(Jeu, 585, 325));
            listeCases.Add(new Case(Jeu, 585, 350));

            listeCases.Add(new Case(Jeu, 560, 300));
            listeCases.Add(new Case(Jeu, 535, 300));
            listeCases.Add(new Case(Jeu, 510, 300));
            listeCases.Add(new Case(Jeu, 485, 300));
            #endregion

            #region BAS
            listeCases.Add(new Case(Jeu, 250, 585));
            listeCases.Add(new Case(Jeu, 275, 585));
            listeCases.Add(new Case(Jeu, 300, 585));
            listeCases.Add(new Case(Jeu, 325, 585));
            listeCases.Add(new Case(Jeu, 350, 585));

            listeCases.Add(new Case(Jeu, 300, 485));
            listeCases.Add(new Case(Jeu, 300, 510));
            listeCases.Add(new Case(Jeu, 300, 535));
            listeCases.Add(new Case(Jeu, 300, 560));
            #endregion

            #region GAUCHE
            listeCases.Add(new Case(Jeu, 15, 250));
            listeCases.Add(new Case(Jeu, 15, 275));
            listeCases.Add(new Case(Jeu, 15, 300));
            listeCases.Add(new Case(Jeu, 15, 325));
            listeCases.Add(new Case(Jeu, 15, 350));

            listeCases.Add(new Case(Jeu, 40, 300));
            listeCases.Add(new Case(Jeu, 65, 300));
            listeCases.Add(new Case(Jeu, 90, 300));
            listeCases.Add(new Case(Jeu, 115, 300));
            #endregion

            foreach (Case caseJeu in listeCases)
                Jeu.Components.Add(caseJeu);
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
            base.Draw(gameTime);
        }

        #region Case
        public class Case : Microsoft.Xna.Framework.DrawableGameComponent
        {
            public Vector2 Position { get; private set; }
            public bool EstOccupee { get; set; }
            public bool Bloque { get; set; }

            Texture2D ImageCase { get; set; }
            Toc Jeu { get; set; }
            int X { get; set; }
            int Y { get; set; }
            float Echelle { get; set; }

            public Case(Toc jeu, int x, int y)
                : base(jeu)
            {
                Jeu = jeu;
                X = x;
                Y = y;
            }

            public override void Initialize()
            {
                Echelle = 0.4f;
                EstOccupee = false;
                Bloque = false;

                base.Initialize();
            }

            protected override void LoadContent()
            {
                ImageCase = Jeu.Content.Load<Texture2D>("Textures/Cases/Case_neutre");
                Position = new Vector2(X - (ImageCase.Width / 2.0f) * Echelle, Y - (ImageCase.Height / 2.0f) * Echelle);

                base.LoadContent();
            }

            public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
            {
                base.Update(gameTime);
            }

            public override void Draw(GameTime gameTime)
            {
                Jeu.SpriteBatch.Draw(ImageCase, Position, null, Color.White, 0, Vector2.Zero, Echelle, SpriteEffects.None, 1);
                base.Draw(gameTime);
            }
        }
        #endregion
    }
}