using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    class Worm
    {
        public Vector2 Pos { get;set; }
        Vector2 Dir;
        public static Texture2D Texture2D { get; set; }
        public Vector2 Size = new Vector2(16, 68);
        public Worm(Vector2 pos, Vector2 dir)
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
            var newPos = GenerationObjects.GeneratePos(68);
            while (Objects.Collision(newPos, Size))
            {
                newPos = GenerationObjects.GeneratePos(68);
            }
            Pos = newPos;
        }

        public void Draw()
        {
            Objects.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }

        public bool Eat(Duck duck)
        {
            return duck.IsIntersect(new Rectangle((int)Pos.X, (int)Pos.Y, Texture2D.Width, Texture2D.Height));
        }
    }
}
