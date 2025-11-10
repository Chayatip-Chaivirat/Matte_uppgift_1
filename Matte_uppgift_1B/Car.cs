using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Matte_uppgift_1B
{
    internal class Car
    {
        protected  Texture2D carTex;
        protected Rectangle carRec;
        protected Vector2 carPos;
        public double rotation;

        public Car(Texture2D carTex, Rectangle carRec, Vector2 carPos)
        {
            this.carTex = carTex;
            this.carRec = carRec;
            this.carPos = carPos;
            rotation = 1 / Math.Sqrt((long)carPos.X ^ 2 + (long)carPos.Y ^ 2);
        }
        
        public void CreateABall()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(carTex, carPos, carRec, Color.White, (long)rotation, new Vector2(), 1, SpriteEffects.None,1);
        }
    }
}
