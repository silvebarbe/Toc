using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace TocGame
{
    class Paquet : Microsoft.Xna.Framework.GameComponent
    {
        Toc Jeu { get; set; }
        IList<Carte> Paquet_ { get; set; }

        public Paquet(Toc jeu)
            :base(jeu)
        {
            Jeu = jeu;
            Paquet_ = new List<Carte>();
        }

        public override void Initialize()
        {
            for (int i = 1; i <= 52; ++i)
            {
                Paquet_.Add(new Carte(Jeu, (Carte.SorteCarte)(i % 4), i % 13));
            }

            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Brasser()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = Paquet_.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];

                do
                {
                    provider.GetBytes(box);
                }
                while (!(box[0] < n * (Byte.MaxValue / n)));

                int k = (box[0] % n);
                n--;
                Carte value = Paquet_[k];
                Paquet_[k] = Paquet_[n];
                Paquet_[n] = value;
            }
        }
    }
}
