using System;

namespace GraPlatformowa
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            bool debugging = true;
            try {
                using (Game1 game = new Game1())
                {
                    game.Run();
                }
            }
            catch (Exception e)
            {
                if (debugging)
                    System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
#endif
}

