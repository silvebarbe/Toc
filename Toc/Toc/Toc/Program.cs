using System;

namespace TocGame
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (Toc game = new Toc())
            {
                game.Run();
            }
        }
    }
#endif
}

