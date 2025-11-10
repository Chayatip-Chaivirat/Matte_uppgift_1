using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Matte_uppgift1
{
    public class Game1 : Game
    {
        //Here we deklare all the varables we use

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //loading in the texture for the circle
            circleTex = Content.Load<Texture2D>("ball");

            //Setting the diameter we want the circle to have
            Diameter = 100;

            //Setting the position for the circle
            circleRecPos = new Vector2(Window.ClientBounds.Width / 2 - Diameter/ 2, Window.ClientBounds.Height / 2 - Diameter / 2);

            //Making a Vector2 varable to describe the center of the circkle
            circleCenter = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);

            //Creating a rectangle to use in the draw method for the circle. (We use a rectangle so that we could easily scale it acording to our desired diameter)
            circleRec = new Rectangle((int)circleRecPos.X,(int)circleRecPos.Y,Diameter,Diameter);

            //Setting the Color variable for the circkle
            circleColor = Color.Red;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Setting MousePos =Mouse.GetState(); in order to get the position of the mouse at every moment
            MousePos = Mouse.GetState();

            //Here we the difference in between the mouse position and the center of the circkle, in both the X-axle and Y-axle separately.
            float vectorX = MousePos.Position.X - circleCenter.X;
            float vectorY = MousePos.Position.Y - circleCenter.Y;

            //Here we calculate the length of the vector between the mouse and the center of the circle
            double vectorLenght = Math.Sqrt( vectorX * vectorX + vectorY*vectorY );

            //Here we calculate the radius of the circle
            float radius = Diameter / 2;

            // Here we write an if-statement where we check if the vector between the mouse and the center if the circle is shorter in length than the circle's radius. If it is, the mouse has to be within the circle
            if (vectorLenght <= radius)
            {
                circleColor = Color.White;
            }
            else
            {
                circleColor = Color.Red;
            }

            //Code we added to check the positions in Debug
            Debug.WriteLine(vectorLenght);
            Debug.WriteLine(radius);

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            //Here we draw out the circle
            _spriteBatch.Draw(circleTex, circleRec, circleColor);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
