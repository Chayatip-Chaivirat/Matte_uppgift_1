using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Matte_uppgift_1B
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Rectangle carRec;
        public Vector2 carPos;
        public Texture2D carTex;
        //public double rotation;

        Car car;
        public Texture2D circleTex;
        public Rectangle circle;
        public Vector2 circlePos;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            carRec = new Rectangle(0,0,100,100);
            carPos = new Vector2(100,100);
            carTex = Content.Load<Texture2D>("ball (1)");
            car = new Car(carTex, carRec, carPos);
            //rotation = 1 / Math.Sqrt((long)carPos.X ^2 + (long)carPos.Y ^2);

            circleTex = Content.Load<Texture2D>("ball (1)");
            circle = new Rectangle(0, 0, 50, 50);
            circlePos = new Vector2(200,200);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            do
            {
                car.CreateABall();
            }
            while (false);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            car.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
