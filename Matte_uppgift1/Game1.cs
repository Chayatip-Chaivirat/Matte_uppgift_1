using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Matte_uppgift1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D circleTex;
        public Rectangle circleRec;
        public int Diameter;
        public Vector2 circleCenter;
        public Vector2 circleRecPos;
        public MouseState MousePos;
        public Color circleColor;
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
            circleTex = Content.Load<Texture2D>("ball");
            Diameter = 100;
            circleRecPos = new Vector2(Window.ClientBounds.Width / 2 - Diameter/ 2, Window.ClientBounds.Height / 2 - Diameter / 2);
            circleRec = new Rectangle((int)circleRecPos.X,(int)circleRecPos.Y,Diameter,Diameter);
            circleCenter = new Vector2(Window.ClientBounds.Width/2, Window.ClientBounds.Height/2);
            circleColor = Color.Red;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MousePos = Mouse.GetState();
            float vectorX = MousePos.Position.X - circleCenter.X;
            float vectorY = MousePos.Position.Y - circleCenter.Y;

            double vectorLenght = Math.Sqrt( vectorX * vectorX + vectorY*vectorY );
            float radius = Diameter / 2;
            if (vectorLenght <= radius)
            {
                circleColor = Color.White;
            }
            else
            {
                circleColor = Color.Red;
            }
            Debug.WriteLine(vectorLenght);
            Debug.WriteLine(radius);

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(circleTex, circleRec, circleColor);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
