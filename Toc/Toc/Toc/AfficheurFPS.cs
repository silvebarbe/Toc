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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace TocGame
{
   public class AfficheurFPS : Microsoft.Xna.Framework.DrawableGameComponent
   {
      const int MARGE_BAS = 10;
      const int MARGE_DROITE = 15;

      Toc Jeu { get; set; }
      float IntervalleMAJ { get; set; }
      float TempsÉcouléDepuisMAJ { get; set; }
      int CptFrames { get; set; }
      float ValFPS { get; set; }
      Vector2 PositionDroiteBas { get; set; }
      Vector2 PositionChaîne { get; set; }
      string ChaîneFPS { get; set; }
      Vector2 Dimension { get; set; }
      SpriteFont ArialFont { get; set; }

      public AfficheurFPS(Toc jeu, float intervalleMAJ)
         : base(jeu)
      {
         IntervalleMAJ = intervalleMAJ;
         Jeu = jeu;
      }

      public override void Initialize()
      {
         TempsÉcouléDepuisMAJ = 0;
         ValFPS = 0;
         CptFrames = 0;
         ChaîneFPS = "";
         PositionDroiteBas = new Vector2(Jeu.Window.ClientBounds.Width - MARGE_DROITE,
                                         Jeu.Window.ClientBounds.Height - MARGE_BAS);
         base.Initialize();
      }

      protected override void LoadContent()
      {
         ArialFont = Jeu.Content.Load<SpriteFont>("Fonts/Arial"); 
         base.LoadContent();
      }

      public override void Update(GameTime gameTime)
      {
          // Recalculer la position d'affichage du FPS
          PositionDroiteBas = new Vector2(Jeu.Window.ClientBounds.Width - MARGE_DROITE,
                                          Jeu.Window.ClientBounds.Height - MARGE_BAS);
          PositionChaîne = PositionDroiteBas - Dimension;

         float tempsÉcoulé = (float)gameTime.ElapsedGameTime.TotalSeconds;
         ++CptFrames;
         TempsÉcouléDepuisMAJ += tempsÉcoulé;
         if (TempsÉcouléDepuisMAJ > IntervalleMAJ)
         {
            float oldValFPS = ValFPS;
            ValFPS = CptFrames / TempsÉcouléDepuisMAJ;
            if (oldValFPS != ValFPS)
            {
               ChaîneFPS = ValFPS.ToString("0");
               Dimension = ArialFont.MeasureString(ChaîneFPS);
            }
            CptFrames = 0;
            TempsÉcouléDepuisMAJ -= IntervalleMAJ;
         }
         base.Update(gameTime);
      }

      public override void Draw(GameTime gameTime)
      {
          Jeu.SpriteBatch.DrawString(ArialFont, ChaîneFPS, PositionChaîne, Color.Red, 0,
                                      Vector2.Zero, 1.0f, SpriteEffects.None, 0);
          base.Draw(gameTime);
      }
   }
}