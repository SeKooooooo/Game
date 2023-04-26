using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static Log[] Logs { get; set; }
        public static Island[] Islands { get; set; }
        public static Stone[] Stones { get; set; }
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
            DoLogs();
            DoIslands();
            DoStones();
            DoWorms();
            CountWorms = 0;
        }
        public static void DoWorms()
        {
            Worms = new List<Worm>();
            for (var i = 0; i < 10; i++)
            {
                Worms.Add(new Worm(new Vector2(1920 + i * 100, 200), Speed));
            }
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

        public static void DoLogs()
        {
            Logs = new Log[3];
            for (var i = 0; i < Logs.Length; i++)
            {
                Logs[i] = new Log(new Vector2(1920 + i * 300, 200), Speed);
            }
        }

        public static void DoIslands()
        {
            Islands = new Island[5];
            for (var i = 0; i < Islands.Length; i++)
            {
                Islands[i] = new Island(new Vector2(1920 + i * 300, 500), Speed);
            }
        }

        public static void DoStones()
        {
            Stones=new Stone[5];
            for (var i = 0; i < Stones.Length; i++)
            {
                Stones[i] = new Stone(new Vector2(1920+i*300,500) ,Speed);
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
            foreach(Log log in Logs)
                log.Draw();
            foreach (Island island in Islands)
                island.Draw();
            foreach (Stone stone in Stones)
                stone.Draw();
            foreach (Shore shore in Shores)
                shore.Draw();
            foreach(Worm worm in Worms)
                worm.Draw();
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
                    var newPos = GenerationObjects.GeneratePos(68);
                    while (Collision(newPos, new Vector2(16,68)))
                    { 
                        newPos = GenerationObjects.GeneratePos(68);
                    }
                    worm.Pos = newPos;
                }
            }
            foreach(Log log in Logs)
            {
                log.Update();
                if(log.Kill(Duck))
                    FlagDefeat=true;
            }
            foreach (Island island in Islands)
            {
                island.Update();
                if (island.Kill(Duck))
                    FlagDefeat = true;
            }
            foreach (Stone stone in Stones)
            {
                stone.Update();
                if (stone.Kill(Duck))
                    FlagDefeat = true;
            }
        }

        public static bool Collision(Vector2 newPos,Vector2 size)
        {
            int width = (int)size.X;
            var height= (int)size.Y;
            var newObj = new Rectangle((int)newPos.X-100,(int)newPos.Y-50,width+200,height+100 );
            foreach (var obj in Stones)
            {
                if (!new Rectangle(obj.Pos.ToPoint(),obj.Size.ToPoint()).Intersects(newObj))
                    continue;
                return true;
            }
            foreach(var obj in Islands)
            {
                if (!new Rectangle(obj.Pos.ToPoint(), obj.Size.ToPoint()).Intersects(newObj))
                    continue;
                return true;
            }
            foreach (var obj in Logs)
            {
                if (!new Rectangle(obj.Pos.ToPoint(), obj.Size.ToPoint()).Intersects(newObj))
                    continue;
                return true;
            }
            foreach (var obj in Worms)
            {
                if (!new Rectangle(obj.Pos.ToPoint(), obj.Size.ToPoint()).Intersects(newObj))
                    continue;
                return true;
            }
            return false; 
        }
    }
}

