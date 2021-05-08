#region Includes
using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using JetWars.Source.Gameplay.Models.Bullets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
#endregion

namespace JetWars.Source.Gameplay.Models
{
    public class PlayerJet : Jet, IRotatable
    {

        Random rand = new Random();

        public PlayerJet() : base("jet", new Vector2(300, 300), new Vector2(60, 60),3.0f,20.0f)
        {
            shootTimer = new METimer(100);
        }

        public override void Update()
        {
            base.Update();
            shootTimer.UpdateTimer();
            MoveJet();
            Rotate();
            if (Globals.mouse.LeftClick() && shootTimer.Test())
            {
                ShootRegularBullet();
                shootTimer.ResetToZero();
            }
            if(Globals.mouse.RightClick())
            {
                ShootMissile();
            }
        }

        private void ShootMissile()
        {
            Missile missile =
                new Missile(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), rotation, 10);
    
            GameGlobals.PassBullet(missile);
        }

        private void ShootRegularBullet()
        {
            int deflection = rand.Next(0, (int)Physics.GetDistance(position, Globals.mouse.newMousePos) / 6);

            if (rand.Next(0, 2) == 0)
                deflection = -deflection;

            Bullet2D bullet =
                new StandardBullet(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePos.X + deflection, Globals.mouse.newMousePos.Y), rotation,15.0f);

            GameGlobals.PassBullet(bullet);
        }

        private void MoveJet()
        {
            KeyboardState currentKey = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;
            float horizontalInput = 0f;
            float verticalInput = 0f;

            if (currentKey.IsKeyDown(Keys.W))
            {
                verticalInput = -1f;
            }

            if (currentKey.IsKeyDown(Keys.S))
            {
                verticalInput = 1f;
            }

            if (currentKey.IsKeyDown(Keys.A))
            {
                horizontalInput = -1f;
            }

            if (currentKey.IsKeyDown(Keys.D))
            {
                horizontalInput = 1f;
            }

            float movementForce = 100f;
            float delta = (float)Globals.gameTime.ElapsedGameTime.TotalSeconds;
            movement = new Vector2(horizontalInput, verticalInput) * delta * movementForce * speed;
            position += movement;

            Rectangle rect = new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);

            if (Physics.TouchesOneOfBounds(rect))
            {
                position -= movement;
            }
        }



        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

        public void Rotate()
        {
            rotation = Physics.RotateTowards(position, Globals.mouse.newMousePos);
        }
    }
}
