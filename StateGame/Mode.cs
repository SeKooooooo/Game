using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Win32;

namespace Project1
{
    class Mode
    {

        public static Texture2D Backgroung { get; set; }
        public static Texture2D Ordinary { get; set; }
        public static Texture2D Infinity { get; set; }
        public static Button ButtonOrdinary = new Button(new Vector2(200, 455));
        public static Button ButtonInfinity = new Button(new Vector2(1220, 455));
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Backgroung, Vector2.Zero, Color.White);
            spriteBatch.Draw(Ordinary, ButtonOrdinary.Pos, Color.White);
            spriteBatch.Draw(Infinity, ButtonInfinity.Pos, Color.White);
        }
        public static void Update() { }
    }
}
