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
        public PlayerJet() : base("jet", new Vector2(300, 300), new Vector2(50, 50))
		{
		}

        public override void Update()
        {
            MoveJet();
            RotateJet();

			if(Globals.mouse.LeftClick())
            {
				Shoot();
            }

        }

		private void Shoot()
        {
			Bullet2D projectile = 
				new StandardBullet(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y),rotation);

			GameGlobals.PassBullet(projectile);
		}

		public override void RotateJet()
        {
            rotation = Physics.RotateTowards(position, Globals.mouse.GetScreenPos(Globals.mouse.New));
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
			movement = new Vector2(horizontalInput, verticalInput) * (float)Globals.gameTime.ElapsedGameTime.TotalSeconds * movementForce;
			position += movement;

			Rectangle rect = new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);

			if (Physics.TouchesOneOfBounds(rect))
			{
				position -= movement;
			}
		}



		public override void Draw(Vector2 OFFSET)
		{
			//bullets.ForEach(bullet => bullet.Draw(Vector2.Zero));
			base.Draw(OFFSET);
		}

	}
}
