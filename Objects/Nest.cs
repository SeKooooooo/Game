using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.StateGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Nest
    {
        public Vector2 Pos { get; set; }
        Vector2 Dir;
        public static Texture2D Texture2D { get; set; }

        public Nest(Vector2 pos, Vector2 dir)
        {
            Pos = pos;
            Dir = dir;
        }
        public void Update()
        {
            Dir = Objects.Speed;
            if (Objects.CountWorms>=10)
            {
                Pos += Dir;
                Objects.FlagWin=true;
            }
                
        }
        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }
        public bool Win(Duck duck)
        {
            return duck.IsIntersect(new Rectangle((int)Pos.X- 20, (int)Pos.Y, Texture2D.Width , Texture2D.Height ));
        }
    }
}
