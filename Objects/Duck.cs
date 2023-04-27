using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Project1
{
    class Duck
    {
        Vector2 Pos;
        int Speed = 4;
        public static bool Dive=false;
        public static Texture2D Texture2D { get; set; }
        public static Texture2D DiveDuck { get; set; }
        public static int Length = 300;

        public Duck(Vector2 pos)
        {
            Pos = pos;
        }
        public void Down()
        {
            if (Pos.Y < 735) Pos.Y += Speed;
        } 
        public void Up()
        {
            if (Pos.Y > 210) Pos.Y -= Speed;
        }
        public void Update()
        {
            if (Dive  )
            {
                Length -= 5;
                if (Length <= 0)
                {
                    Dive = false;
                    Length = 300;
                }
            }
        }
        public void Draw()
        {
            if (Dive)
                Objects.SpriteBatch.Draw(DiveDuck, Pos, Color.White);
            else Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }
        public bool IsIntersect(Rectangle rectangle)
        {
            return rectangle.Intersects(new Rectangle((int)Pos.X, (int)Pos.Y+ 80, Texture2D.Width-30, Texture2D.Height-80));
        }
    }
}
