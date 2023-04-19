using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    class Wave
    {
        Vector2 Pos;
        Vector2 Dir;
        private int Line;

        public static Texture2D Texture2D { get; set; }

        public Wave(Vector2 pos, Vector2 dir, int line)
        {
            Pos = pos;
            Dir = dir;
            Line = line;
        }

        public Wave(Vector2 dir)
        {
            Dir = dir;
        }
        public void Update()
        {
            Pos += Dir;
            if (Pos.X < 0)
            {
                Set();
            }

        }
        public void Set()
        {
            Pos = new Vector2(Objects.Width, Objects.Height * (float)(0.225 + 0.2 * Line));
        }
        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }
    }
}
