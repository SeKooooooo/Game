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
        public static List<Log> Logs { get; set; }
        public static List<Island> Islands { get; set; }
        public static List<Stone> Stones { get; set; }
        public static Nest Nest { get; set; }
        public static int CountWorms;
        public static Vector2 Speed = new Vector2(-5, 0);
        public static bool FlagDefeat = false;
        public static bool FlagWin = false;       


        public static void Init(SpriteBatch SpriteBatch, int Width, int Height)
        {
            Objects.Width = Width;
            Objects.Height = Height;
            Objects.SpriteBatch = SpriteBatch;
            Speed = new Vector2(-5, 0);
            Nest = new Nest(new Vector2(2000, 0), Speed);
            DoWaves();
            Duck = new Duck(new Vector2(200, Objects.Height / 2));
            DoShores();
            DoLogs();
            DoIslands();
            DoStones();
            DoWorms();
            CountWorms = 0;
            FlagWin = false;
            Duck.Length = 340;
        }
        public static void DoWorms()
        {
            Worms = new List<Worm>();
            var size = new Vector2(16,68);
            for (var i = 0; i < 10; i++)
            {
                var newPos = GenerationObjects.GeneratePos(68);
                while (Collision(newPos, size))
                {
                    newPos = GenerationObjects.GeneratePos(68);
                }
                Worms.Add(new Worm(newPos, Speed));
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
            Logs = new List<Log> { new Log(new Vector2(2120,200), Speed),
                new Log(new Vector2(2600,410), Speed),
                new Log(new Vector2(3500,220), Speed)
        };
       
            
        }

        public static void DoIslands()
        {
            Islands = new List<Island> { new Island(new Vector2(2800,200), Speed),
                 new Island(new Vector2(3200,400), Speed),
                 new Island(new Vector2(3900,600), Speed),


        };
        }

        public static void DoStones()
        {
            Stones=new List<Stone> { new Stone(new Vector2(2900,600), Speed),
                new Stone(new Vector2(3800,300), Speed),
                new Stone(new Vector2(4200,450), Speed),
            };
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
            foreach (Island island in Islands)
                island.Draw();
            foreach (Stone stone in Stones)
                stone.Draw();
            foreach (Shore shore in Shores)
                shore.Draw();
            foreach(Worm worm in Worms)
                worm.Draw();
            Nest.Draw();
            if (!Duck.Dive)
            {
                foreach (Log log in Logs)
                    log.Draw();
                Duck.Draw();
            }
            else
            {
                Duck.Draw();
                foreach (Log log in Logs)
                    log.Draw();
            }
            SpriteBatch.DrawString(Font, "Worms " + CountWorms.ToString(), new Vector2(1553, 965),Color.Red);
        }

        public static void Update()
        {
            Nest.Update();
            Duck.Update();
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
            if (Nest.Win(Duck))
                Speed = new Vector2(0,0);

        }

        public static bool Collision(Vector2 newPos,Vector2 size)
        {
            int width = (int)size.X;
            var height= (int)size.Y;
            var newObj = new Rectangle((int)newPos.X-150,(int)newPos.Y-100,width+300,height+200 );
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
                if (!new Rectangle(obj.Pos.ToPoint(), obj.Size.ToPoint()).Intersects(new Rectangle((int)newPos.X-50,(int)newPos.Y - 50,width+100, height+100)))
                    continue;
                return true;
            }
            return false; 
        }
    }
}

