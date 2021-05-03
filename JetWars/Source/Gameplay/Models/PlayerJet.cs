#region Includes
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetWars.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars.Source.Gameplay.Models
{
    public class PlayerJet : Jet
    {
        float friction = 0.08f;
        KeyboardState presentKey;
        KeyboardState pastKey;
        float maxVelocity = 10f;
        bool isMoving = false;
        public PlayerJet() : base("jet", new Vector2(300, 300), new Vector2(50, 50))
        {

        }

        public override void Update(GameTime gameTime)
        {
            MoveJet(gameTime);
            RotateJet();
        }

        public override void RotateJet()
        {
            rotation = Physics.RotateTowards(position, Globals.mouse.GetScreenPos(Globals.mouse.New));
        }

        private void MoveJet(GameTime gameTime)
        {

            presentKey = Keyboard.GetState();

            Vector2 oldPosition = position;

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += velocity*acceleration * delta * 10;


            if (position == oldPosition)
            {
                velocity = Vector2.Zero;
                acceleration = Vector2.Zero;
            }
            bool currentMovement = false;

            if (acceleration.X < 10)
            {
                acceleration.X += 1f;
            }
            if(acceleration.Y < 10)
            {
                acceleration.Y += 1f;
            }

            if (presentKey.IsKeyDown(Keys.W) && velocity.Y > -maxVelocity)
            {

                velocity.Y = velocity.Y - acceleration.Y * delta;
                currentMovement = true;
            }

            if (presentKey.IsKeyDown(Keys.S) && velocity.Y < maxVelocity)
            {
  
                velocity.Y = velocity.Y +  acceleration.Y * delta;
                currentMovement = true;
            }
            if (presentKey.IsKeyDown(Keys.A) && velocity.X > -maxVelocity)
            {
                velocity.X = velocity.X - acceleration.X * delta;
                currentMovement = true;
            }
            if (presentKey.IsKeyDown(Keys.D) && velocity.X < maxVelocity)
            {
                velocity.X = velocity.X + acceleration.X * delta;
                currentMovement = true;
            }

            if (!currentMovement)
            {
                isMoving = false;
                acceleration.X -= 0.5f;
                acceleration.Y -= 0.5f;
                float i = velocity.X;
                float j = velocity.Y;
                velocity.X = i -= i * friction;
                velocity.Y = j -= j * friction;
            }

            if (acceleration.X < 0)
                acceleration.X = 0;

            if (acceleration.Y < 0)
                acceleration.Y = 0;
            //if (_jetPosition.X > _graphics.PreferredBackBufferWidth - _jetTexture.Width / 2)
            //    _jetPosition.X = _graphics.PreferredBackBufferWidth - _jetTexture.Width / 2;
            //else if (_jetPosition.X < _jetTexture.Width / 2)
            //    _jetPosition.X = _jetTexture.Width / 2;

            //if (_jetPosition.Y > _graphics.PreferredBackBufferHeight - _jetTexture.Height / 2)
            //    _jetPosition.Y = _graphics.PreferredBackBufferHeight - _jetTexture.Height / 2;
            //else if (_jetPosition.Y < _jetTexture.Height / 2)
            //    _jetPosition.Y = _jetTexture.Height / 2;



            //if (Globals.keyboard.GetPress("A"))
            //{
            //    position.X -= speed;
            //}
            //if (Globals.keyboard.GetPress("D"))
            //{
            //    position.X += speed;
            //}
            //if (Globals.keyboard.GetPress("W"))
            //{
            //    position.Y -= speed;
            //}
            //if (Globals.keyboard.GetPress("S"))
            //{
            //    position.Y += speed;
            //}
        }
    }
}
