﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    class Stone 
    {
        public Vector2 Pos { get; private set; }
        Vector2 Dir;
        public static Texture2D Texture2D { get; set; }

        public Stone(Vector2 pos, Vector2 dir)
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
            Pos = new Vector2(Objects.Width + Texture2D.Width, Pos.Y);
        }

        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }

        public bool Kill(Duck duck)
        {
            return duck.IsIntersect(new Rectangle((int)Pos.X + 20, (int)Pos.Y + 10, Texture2D.Width - 40, Texture2D.Height - 15));
        }
    }

}
