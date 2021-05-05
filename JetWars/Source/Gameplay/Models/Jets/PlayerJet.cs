#region Includes
using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
#endregion

namespace JetWars.Source.Gameplay.Models
{
    public class PlayerJet : Jet, IRotatable
    {
        public PlayerJet() : base("jet", new Vector2(300, 300), new Vector2(60, 60),5.0f)
        {
        }

        public override void Update()
        {
            MoveJet();
            Rotate();
            if (Globals.mouse.LeftClick())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Bullet2D bullet =
                new StandardBullet(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), rotation);

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

            float movementForce = 600f;
            float delta = (float)Globals.gameTime.ElapsedGameTime.TotalSeconds;
            movement = new Vector2(horizontalInput, verticalInput) * delta * movementForce;
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
            rotation = Physics.RotateTowards(position, Globals.mouse.GetScreenPos(Globals.mouse.New));
        }
    }
}
