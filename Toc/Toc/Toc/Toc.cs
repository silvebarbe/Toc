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
    public class Toc : Microsoft.Xna.Framework.Game
    {
        public InputManager GestionDesEntrées { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }

        GraphicsDeviceManager graphics;
        Paquet PaquetDeCartes { get; set; }

        public Toc()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferHeight = 1452;
            //graphics.PreferredBackBufferWidth = 1385;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Toc";
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            IsMouseVisible = true;

            GestionDesEntrées = new InputManager(this);
            Components.Add(GestionDesEntrées);

            //TODO: 0.05?
            Components.Add(new PlancheDeJeu(this, "Board", 0.05f));
            Components.Add(new Bille(this));
            Components.Add(new AfficheurFPS(this, 1));
            
            //TODO: Necessaire pour brasser
            PaquetDeCartes = new Paquet(this);
            Components.Add(PaquetDeCartes);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GestionDesEntrées.EstNouvelleTouche(Keys.B))
            {
                PaquetDeCartes.Brasser();
            }
            if(GestionDesEntrées.EstNouvelleTouche(Keys.Escape))
            {
                Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();
            base.Draw(gameTime);
            SpriteBatch.End();
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.ApplyChanges();
        }
    }
}
