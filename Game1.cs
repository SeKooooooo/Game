using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System.Collections;

namespace Project1
{
    enum Stat{
        SplashScreen,
        Game,
        Defeat,
        Win,
        Pause,
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Stat state=Stat.SplashScreen;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen=true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SplashScreen.Backgroung = Content.Load<Texture2D>("Background");
            Nest.Texture2D = Content.Load<Texture2D>("nest");
            Objects.Init(spriteBatch,graphics.PreferredBackBufferWidth,graphics.PreferredBackBufferHeight);
            Wave.Texture2D = Content.Load<Texture2D>("Wave");
            Duck.DuckDefault = Content.Load<Texture2D>("duck");
            Duck.Duck1 = Content.Load<Texture2D>("duck_1");
            Duck.Duck2 = Content.Load<Texture2D>("duck_2");
            Duck.DuckDive = Content.Load<Texture2D>("dive");
            Shore.Texture2D = Content.Load<Texture2D>("shores");
            Log.Texture2D=Content.Load<Texture2D>("log");
            Island.Texture2D = Content.Load<Texture2D>("island");
            Defeat.Backgroung = Content.Load<Texture2D>("defeat");
            Stone.Texture2D = Content.Load<Texture2D>("stone");
            Worm.Texture2D = Content.Load<Texture2D>("worm");
            Objects.Font = Content.Load<SpriteFont>("GameFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
             switch (state)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    if (Keyboard.GetState().IsKeyDown (Keys.T)) state = Stat.Game;
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
                    break;
                case Stat.Game:
                    Objects.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.W)) Objects.Duck.Up();
                    if (Keyboard.GetState().IsKeyDown(Keys.S)) Objects.Duck.Down();
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape)) state = Stat.SplashScreen;
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) && !Duck.PushSpace) {Duck.Dive=true; Duck.PushSpace = true;}
                    if (Keyboard.GetState().IsKeyUp(Keys.Space)) Duck.PushSpace = false;
                    if (Objects.FlagDefeat) state = Stat.Defeat;
                    break;
                case Stat.Defeat:
                    Defeat.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter)) { Objects.Init(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); state = Stat.Game; }
                    break;
            }
                

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aqua);
            spriteBatch.Begin();
            switch (state)
            {
                case Stat.SplashScreen :
                    SplashScreen.Draw(spriteBatch);
                    break;
                case Stat.Game:
                    Objects.Draw();
                    break;
                case Stat.Defeat:
                    Defeat.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}