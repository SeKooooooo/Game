using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Project1
{
    class Duck
    {
        Vector2 Pos;
        int Speed = 4;

        public static Texture2D Texture2D { get; set; }

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
        public void Dive()
        {
            var pos = Pos;
            Pos = new Vector2(-100, 0);
            Pos = pos;
        }
        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }
        public bool IsIntersect(Rectangle rectangle)
        {
            return rectangle.Intersects(new Rectangle((int)Pos.X, (int)Pos.Y+ 80, Texture2D.Width-30, Texture2D.Height-80));
        }
    }
}
