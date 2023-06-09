﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
namespace Project1
{
    class Island
    {
        public Vector2 Pos { get; private set; }
        Vector2 Dir;       
        public static Texture2D Texture2D { get; set; }
        public Vector2 Size = new Vector2(200,200);

        public Island(Vector2 pos, Vector2 dir)
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
            var newPos = GenerationObjects.GeneratePos(200);
            while (Objects.Collision(newPos, Size))
            {
                newPos = GenerationObjects.GeneratePos(200);
            }
            Pos = newPos;
        }

        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }

        public bool Kill(Duck duck)
        {
            return duck.IsIntersect(new Rectangle((int)Pos.X + 20, (int)Pos.Y+10, Texture2D.Width-50, Texture2D.Height-15));
        }

    }
}