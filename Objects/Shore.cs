using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    class Shore
    {
        Vector2 Pos;
        Vector2 Dir;

        public static Texture2D Texture2D { get; set; }

        public Shore(Vector2 pos, Vector2 dir)
        {
            Pos = pos;
            Dir = dir;
        }
        public void Update()
        {
            Dir = Objects.Speed;
            Pos += Dir;
            if (Pos.X < -Texture2D.Width && !Objects.FlagWin)
            {
                Set();
            }
        }

        public void Set()
        {
            Pos = new Vector2(1915, Pos.Y);
        }

        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }

    }
}
