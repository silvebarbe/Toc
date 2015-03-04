using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace TocGame
{
   public class InputManager : Microsoft.Xna.Framework.GameComponent
   {
      Game Jeu;
      Keys[] AnciennesTouches { get; set; }
      Keys[] NouvellesTouches { get; set; }
      public KeyboardState ÉtatClavier { get; private set; }
      public MouseState AncienÉtatSouris { get; private set; }
      public MouseState ÉtatSouris { get; private set; }

      public InputManager(Game game)
         : base(game)
      {
         Jeu = game;
      }

      public override void Initialize()
      {
         AnciennesTouches = new Keys[0];
         NouvellesTouches = new Keys[0];
         ÉtatSouris = Mouse.GetState();
         AncienÉtatSouris = ÉtatSouris;
         base.Initialize();
      }

      public override void Update(GameTime gameTime)
      {
         AnciennesTouches = NouvellesTouches;
         ÉtatClavier = Keyboard.GetState();
         NouvellesTouches = ÉtatClavier.GetPressedKeys();
         if (Jeu.IsMouseVisible)
         {
            ActualiserÉtatSouris();
         }
         base.Update(gameTime);
      }

      public bool EstClavierActivé
      {
         get { return NouvellesTouches.Length > 0; }
      }

      public bool EstNouvelleTouche(Keys touche)
      {
         int NbTouches = AnciennesTouches.Length;
         bool EstNouvelleTouche = ÉtatClavier.IsKeyDown(touche);
         int i = 0;
         while (i < NbTouches && EstNouvelleTouche)
         {
            EstNouvelleTouche = AnciennesTouches[i] != touche;
            ++i;
         }
         return EstNouvelleTouche;
      }

      private void ActualiserÉtatSouris()
      {
         AncienÉtatSouris = ÉtatSouris;
         ÉtatSouris = Mouse.GetState();
         if (ÉtatSouris.LeftButton == ButtonState.Pressed)
         {
            Vector2 Position = GetPositionSouris();

         }
      }

      public bool EstNouveauClicDroit()
      {
         return ÉtatSouris.RightButton == ButtonState.Pressed && AncienÉtatSouris.RightButton == ButtonState.Released;
      }

      public bool EstNouveauClicGauche()
      {
         return ÉtatSouris.LeftButton == ButtonState.Pressed && AncienÉtatSouris.LeftButton == ButtonState.Released;
      }

      public Vector2 GetPositionSouris()
      {
         return new Vector2(ÉtatSouris.X, ÉtatSouris.Y);
      }
   }
}