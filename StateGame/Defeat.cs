using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1.StateGame
{
    static class Defeat
    {
        public static Texture2D Backgroung { get; set; }
        public static Texture2D Restart { get; set; }
        public static Texture2D Exit { get; set; }
        public static Button ButtonRestart = new Button(new Vector2(710, 520));
        public static Button ButtonExit = new Button(new Vector2(710, 770));
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Backgroung, Vector2.Zero, Color.White);
            spriteBatch.Draw(Restart, ButtonRestart.Pos, Color.White);
            spriteBatch.Draw(Exit, ButtonExit.Pos, Color.White);
        }
        public static void Update()
        {
            Objects.FlagDefeat = false;
        }
    }
}