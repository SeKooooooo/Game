using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    class Log
    {
        public Vector2 Pos { get; private set; }
        Vector2 Dir;
        public static Texture2D Texture2D { get; set; }
        public Vector2 Size = new Vector2(125, 400);
        public Log(Vector2 pos, Vector2 dir)
        {
            Pos = pos;
            Dir = dir;
        }
        public void Update()
        {
            Pos += Dir;
            if (Pos.X < -Texture2D.Width)
            {
                Set();
            }
        }

        public void Set()
        {        
            var newPos = GenerationObjects.GeneratePos(400);
            while (Objects.Collision(newPos, Size))
            {
                newPos = GenerationObjects.GeneratePos(400);
            }
            Pos = newPos;
        }

        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }

        public bool Kill(Duck duck)
        {
            return duck.IsIntersect(new Rectangle((int)Pos.X + 20, (int)Pos.Y+10, Texture2D.Width-40, Texture2D.Height-10));    
        }

    }
}
