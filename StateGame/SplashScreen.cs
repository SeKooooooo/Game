using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1.StateGame
{
    static class SplashScreen
    {
        public static Texture2D Backgroung { get; set; }
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Backgroung, Vector2.Zero, Color.White);
        }
        public static void Update()
        {

        }
    }
}
