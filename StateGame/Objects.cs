using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Project1.StateGame
{
    class Objects
    {
        public static int Width, Height;
        public static SpriteBatch SpriteBatch { get; set; }
        public static SpriteFont Font { get; set; }
        static Wave[] Waves;
        public static Duck Duck { get; set; }
        public static List<Worm> Worms;
        static Shore[] Shores { get; set; }
        public static Log Log { get; set; }
        public static Island Island { get; set; }
        public static Stone Stone { get; set; }
        public static int CountWorms;
        readonly static Vector2 Speed = new Vector2(-5, 0);
        public static bool FlagDefeat = false;

        public static void Init(SpriteBatch SpriteBatch, int Width, int Height)
        {
            Objects.Width = Width;
            Objects.Height = Height;
            Objects.SpriteBatch = SpriteBatch;
            DoWaves();
            Duck = new Duck(new Vector2(200, Objects.Height / 2));
            DoShores();
            Log = new Log(new Vector2(2000, 215), Speed);
            Island = new Island(new Vector2(2300, 655), Speed);
            Stone =new Stone(new Vector2(2400,435),Speed);
            Worms=new List<Worm> { new Worm(new Vector2(2000, 700), Speed) };
            CountWorms = 0;
        }
        public static void DoWaves()
        {
            Waves = new Wave[15];
            for (int i = 0; i < Waves.Length; i++)
            {
                var line = i % 3;
                var position = i / 3;
                Waves[i] = new Wave(new Vector2(Width + position * 400, Height * (float)(0.225 + line * 0.2)), Speed, line);
            }

        }

        public static void DoShores()
        {
            Shores = new Shore[2];
            Shores[0] =new Shore(new Vector2(0, 0), Speed);
            Shores[1] = new Shore(new Vector2(1920, 0), Speed);
        }

        public static void Draw()
        {
            foreach (Wave wave in Waves)
                wave.Draw();
            Log.Draw();
            Island.Draw();
            Stone.Draw();
            foreach (Shore shore in Shores)
                shore.Draw();
            Worms[0].Draw();
            Duck.Draw();
            SpriteBatch.DrawString(Font, "Worms " + CountWorms.ToString(), new Vector2(1553, 965),Color.Red);
        }

        public static void Update()
        {
            foreach (Wave wave in Waves)
                wave.Update();
            foreach (Shore shore in Shores)
                shore.Update();
            foreach(Worm worm in Worms)
            {
                worm.Update();
                if (worm.Eat(Duck))
                {
                    CountWorms += 1;
                    worm.Pos = new Vector2(2000, 700);
                }
            }
            Log.Update();
            Island.Update();
            Stone.Update();
            FlagDefeat = Log.Kill(Duck) || Island.Kill(Duck) || Stone.Kill(Duck);
        }
    }
}

